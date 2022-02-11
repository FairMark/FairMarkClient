using System;
using System.Collections.Generic;
using FairMark.OmsApi.DataContracts;
using RestSharp;
using FairMark.TrueApi.DataContracts;

namespace FairMark.OmsApi
{
    partial class OmsApiClient
    {
        /// <summary>
        /// 4.5.1. Метод «Создать заказ на эмиссию кодов маркировки»
        /// </summary>
        /// <remarks>
        /// postman: SUZ milk/orders
        ///  При создании заказа предусмотреть контроль ограничений:
        ///      4.1) одна товарная позиция (код товара, GTIN) в одном заказе не должна превышать
        ///      150000 кодов маркировки, количество товарных позиций в одном заказе не должно
        ///      превышать 10 (1 заказ - 10 GTIN).
        ///      4.2) одновременно может быть не более 100 активных заказов.К активным заказам
        ///      относятся такие заказы в статусе READY, где хотя бы один подзаказ (буфер КМ) имеет
        ///      статус ACTIVE, PENDING или EXHAUSTED.
        ///      4.3) в связи с п.2 обращение к данному методу с одного источника возможно не чаще,
        ///      чем 100 раз в секунду
        ///  Примечание: для товарной группы «Табачная продукция» первично установленная
        ///      схема генерации и структура шаблона КМ для конкретного типа товара(GTIN),
        ///      определяемая атрибутом «serialNumberType», не может быть изменена в дальнейшем.
        ///  Примечание: Для шаблона молочной продукции templateId= 20 при
        ///      самостоятельном способе генерации длина серийных номеров должна быть равна 5-ти
        ///      символам. При эмиссии кодов маркировки серийный номер будет состоять из 6 символов,
        ///      включая код страны.Код страны проставляется Сервером эмиссии и указывается перед
        ///      полученным серийным номером (см.раздел 5.3.1.13).
        ///  Примечание: поле «stickerId» заполняется при создании заказа в рамках процесса дистрибуции.
        /// </remarks>
        /// <typeparam name="T">The type of the product.</typeparam>
        /// <param name="order">Code emission order.</param>
        /// <param name="signed">Sign the order automatically.</param>
        public OrderResponse CreateOrder<T>(Order<T> order, bool signed = true)
            where T : OrderProduct
        {
            // TODO: может, брать extension из типа заказа?
            // Чтобы один клиент мог отправлять заказы разных товарных групп
            // Order_Milk -> "milk", и так далее
            // Можно добавить в Order абстрактное readonly-поле Extension
            // TODO: автоматом подписывать заказ открепленной подписью,
            // передавать подпись в заголовке X-Signature (см. п. 2.3.1.)
            return Post<OrderResponse>("{extension}/orders", order, new[]
            {
                new Parameter("extension", Extension, ParameterType.UrlSegment),
                new Parameter("omsId", OmsCredentials.OmsID, ParameterType.QueryString),
            },
            signed: true);
        }

        /// <summary>
        /// 4.5.2. Метод «Отправить отчёт о выбытии/отбраковке КМ».
        /// </summary>
        /// <param name="report">
        /// Экземпляр <see cref="DropoutReport"/> для отправки 
        /// отчёта о выбытии/отбраковке КМ в СУЗ
        /// </param>
        /// <returns>Код отправленного отчета</returns>
        public string Dropout(DropoutReport report)
        {
            var result = Post<ReportResult>("{extension}/dropout", report, new[]
            {
                new Parameter("extension", Extension, ParameterType.UrlSegment),
                new Parameter("omsId", OmsCredentials.OmsID, ParameterType.QueryString),
            });

            return result.ReportID;
        }

        public string CreateAggregation(AggregationReport report)
        {
            var result = Post<ReportResult>("{extension}/aggregation", report, new[]
            {
                new Parameter("extension", Extension, ParameterType.UrlSegment),
                new Parameter("omsId", OmsCredentials.OmsID, ParameterType.QueryString),
            });

            return result.ReportID;
        }

        /// <summary>
        /// 4.5.4. Метод «Отправить отчёт об использовании (нанесении) КМ»
        /// </summary>
        /// <param name="report">
        /// Экземпляр объекта <see cref="UtilisationReport"/> 
        /// для отправки отчёта об использовании КМ в СУЗ.
        /// </param>
        /// <returns>Код отправленного отчета</returns>
        public string Utilisation(UtilisationReport report)
        {
            var result = Post<ReportResult>("{extension}/utilisation", report, new[]
            {
                new Parameter("extension", Extension, ParameterType.UrlSegment),
                new Parameter("omsId", OmsCredentials.OmsID, ParameterType.QueryString),
            });

            return result.ReportID;
        }

        /// <summary>
        /// 4.5.5. Метод «Закрыть заказ»
        /// </summary>
        /// <param name="orderId">Идентификатор заказа на эмиссию КМ СУЗ</param>
        public string CloseOrder(string orderId)
        {
            return _closeOrder(orderId, null, null);
        }
        public string CloseOrder(Guid orderId)
        {
            return CloseOrder(orderId.ToString());
        }
        /// <summary>
        /// 4.5.5. Метод «Закрыть подзаказ»
        /// Подзаказ – массив КМ в рамках одного GTIN в бизнеc-заказе. После закрытия последнего подзаказа заказ закрывается автоматически.
        /// </summary>
        /// <param name="orderId">Идентификатор заказа на эмиссию КМ СУЗ</param>
        /// <param name="gtin">GTIN товара, по которому требуется прекратить выдачу КМ</param>
        /// <param name="lastBlockId">Идентификатор последнего полученного блока кодов (значение по умолчанию: 0)</param>
        public string CloseSubOrder(string orderId, string gtin, string lastBlockId)
        {
            return _closeOrder(orderId, gtin, lastBlockId);
        }
        public string CloseSubOrder(Guid orderId, string gtin, string lastBlockId)
        {
            return _closeOrder(orderId.ToString(), gtin, lastBlockId);
        }
        public string CloseSubOrder(Guid orderId, string gtin, Guid lastBlockId)
        {
            return _closeOrder(orderId.ToString(), gtin, lastBlockId.ToString());
        }
        private string _closeOrder(string orderId, string gtin = null, string lastBlockId = null)
        {
            var parameters = new List<Parameter>
            {
                new Parameter("extension", Extension, ParameterType.UrlSegment),
                new Parameter("omsId", OmsCredentials.OmsID, ParameterType.QueryString),
                new Parameter("orderId", orderId.ToLower(), ParameterType.QueryString),//To lower is added because FM is case sensitive here. For example ADECDCA0-EA70-4B83-A7FD-A8E4E937E0C5=error; adecdca0-ea70-4b83-a7fd-a8e4e937e0c5=ok
            };

            if (!string.IsNullOrWhiteSpace(gtin))
            {
                parameters.Add(new Parameter("gtin", gtin, ParameterType.QueryString));
            }

            if (!string.IsNullOrWhiteSpace(lastBlockId))
            {
                parameters.Add(new Parameter("lastBlockId", lastBlockId.ToLower(), ParameterType.QueryString));//To lower is added because FM is case sensitive here. For example ADECDCA0-EA70-4B83-A7FD-A8E4E937E0C5=error; adecdca0-ea70-4b83-a7fd-a8e4e937e0c5=ok
            }

            var result = Post<EmptyResult>("{extension}/buffer/close",
                new object(), parameters.ToArray());

            return result.OmsID;
        }


        /// <summary>
        /// 4.5.6. Метод «Получить КМ из заказа»
        /// </summary>
        /// <param name="orderId">Идентификатор заказа на эмиссию КМ СУЗ</param>
        /// <param name="gtin">GTIN товара, по которому требуется прекратить выдачу КМ</param>
        /// <param name="quantity">Количество запрашиваемых кодов</param>
        /// <param name="lastBlockId">
        /// Идентификатор блока кодов, выданных в предыдущем запросе. 
        /// Может быть равен 0 при первом запросе КМ из пула. Далее должен
        /// передаваться идентификатор предыдущего пакета. Значение по
        /// умолчанию: 0
        /// </param>
        /// <remarks>
        /// postman: _SUZ 4.5.6. milk/codes
        ///      Запрос, кажется, готов, но статусы всех последних заказов "Создан".
        ///      Видимо, они ещё не обработаны до конца и метод всё время возвращает что заказа нет, или ГТИНа в заказе нет)
        /// </remarks>
        public CodesDto GetCodes(string orderId, string gtin, int quantity, string lastBlockId = null)
        {
            var parameters = new List<Parameter>
            {
                new Parameter("extension", Extension, ParameterType.UrlSegment),
                new Parameter("omsId", OmsCredentials.OmsID, ParameterType.QueryString),
                new Parameter("orderId", orderId.ToLower(), ParameterType.QueryString),//To lower is added because FM is case sensitive here. For example ADECDCA0-EA70-4B83-A7FD-A8E4E937E0C5=error; adecdca0-ea70-4b83-a7fd-a8e4e937e0c5=ok
                new Parameter("gtin", gtin, ParameterType.QueryString),
                new Parameter("quantity", quantity, ParameterType.QueryString),
            };

            if (!string.IsNullOrWhiteSpace(lastBlockId))
            {
                parameters.Add(new Parameter("lastBlockId", lastBlockId.ToLower(), ParameterType.QueryString));//To lower is added because FM is case sensitive here. For example ADECDCA0-EA70-4B83-A7FD-A8E4E937E0C5=error; adecdca0-ea70-4b83-a7fd-a8e4e937e0c5=ok
            }

            return Get<CodesDto>("{extension}/codes", parameters.ToArray());
        }
        public CodesDto GetCodes(Guid orderId, string gtin, int quantity, Guid lastBlockId)
        {
            return GetCodes(orderId.ToString(), gtin, quantity, lastBlockId.ToString());
        }

        /// <summary>
        /// 4.5.7. Метод «Получить статус массива КМ из заказа»
        /// </summary>
        /// <remarks>
        /// postman: SUZ 4.5.7. milk/buffer/status
        /// </remarks>
        /// <param name="orderId">Идентификатор заказа на эмиссию КМ</param>
        /// <param name="gtin">GTIN товара, по которому нужно получить статус заказа</param>
        public BufferInfo GetBufferStatus(string orderId, string gtin)
        {
            return Get<BufferInfo>("{extension}/buffer/status", new[]
            {
                new Parameter("extension", Extension, ParameterType.UrlSegment),
                new Parameter("omsId", OmsCredentials.OmsID, ParameterType.QueryString),
                new Parameter("orderId", orderId.ToLower(), ParameterType.QueryString),//To lower is added because FM is case sensitive here. For example ADECDCA0-EA70-4B83-A7FD-A8E4E937E0C5=error; adecdca0-ea70-4b83-a7fd-a8e4e937e0c5=ok
                new Parameter("gtin", gtin, ParameterType.QueryString),
            });
        }

        /// <summary>
        /// 4.5.8. Метод «Получить статус заказов»
        /// </summary>
        /// <remarks>
        /// Примечания:
        /// 1) метод предназначен для восстановления АСУТП после полной потери данных,
        /// использование предоставляемых им возможностей в штатных процессах работы с
        /// СУЗ запрещено.
        /// 2) Обращение к данному методу с одного источника, как и к методу создания
        /// заказов, возможно не чаще, чем 100 раз в секунду
        /// postman: SUZ 4.5.1. milk/orders
        /// </remarks>
        public OrderSummaries GetOrders()
        {
            return Get<OrderSummaries>("{extension}/orders", new[]
            {
                new Parameter("extension", Extension, ParameterType.UrlSegment),
                new Parameter("omsId", OmsCredentials.OmsID, ParameterType.QueryString),
            });
        }

        /// <summary>
        /// 4.5.9. Метод «Получить информацию об агрегации»
        /// </summary>
        /// <param name="unitSerialNumber">
        /// Идентификатор агрегата. Так как код может содержать
        /// спецсимволы, значение должно быть перекодировано в
        /// действительный формат ASCII (URL Encoding)
        /// </param>
        public AggregationInfo GetAggregationInfo(string unitSerialNumber)
        {
            return Get<AggregationInfo>("{extension}/aggregation/info", new[]
            {
                new Parameter("extension", Extension, ParameterType.UrlSegment),
                new Parameter("omsId", OmsCredentials.OmsID, ParameterType.QueryString),
                new Parameter("unitSerialNumber", unitSerialNumber, ParameterType.QueryString),
            });
        }

        /// <summary>
        /// 4.5.10. Метод «Получить статус обработки отчёта»
        /// </summary>
        /// <param name="reportId">Уникальный идентификатор отчёта СУЗ</param>
        public ReportStatusDto GetReportStatus(string reportId)
        {
            return Get<ReportStatusDto>("{extension}/report/info", new[]
            {
                new Parameter("extension", Extension, ParameterType.UrlSegment),
                new Parameter("omsId", OmsCredentials.OmsID, ParameterType.QueryString),
                new Parameter("reportId", reportId.ToLower(), ParameterType.QueryString),//To lower is added because FM is case sensitive here. For example ADECDCA0-EA70-4B83-A7FD-A8E4E937E0C5=error; adecdca0-ea70-4b83-a7fd-a8e4e937e0c5=ok
            });
        }
        public ReportStatusDto GetReportStatus(Guid reportId)
        {
            return Get<ReportStatusDto>("{extension}/report/info", new[]
            {
                new Parameter("extension", Extension, ParameterType.UrlSegment),
                new Parameter("omsId", OmsCredentials.OmsID, ParameterType.QueryString),
                new Parameter("reportId", reportId.ToString(), ParameterType.QueryString),
            });
        }

        /// <summary>
        /// Ping OMS to check if it's available.
        /// 4.5.11. Метод «Проверить доступность СУЗ»
        /// </summary>
        public string Ping() => Ping(new Parameter[0]);

        /// <summary>
        /// Internal version of Ping used by <see cref="OmsCredentials"/>
        /// to check existing session token validity.
        /// </summary>
        /// <param name="parameters">Optional RestSharp parameters.</param>
        internal string Ping(params Parameter[] parameters)
        {
            var omsId = OmsCredentials.OmsID;
            var pongParameters = new List<Parameter>
            {
                new Parameter("extension", Extension, ParameterType.UrlSegment),
                new Parameter("omsId", omsId, ParameterType.QueryString),
            };

            // add more parameters if specified
            if (parameters != null && parameters.Length > 0)
            {
                pongParameters.AddRange(parameters);
            }

            var pong = Get<EmptyResult>("{extension}/ping", pongParameters.ToArray());

            // looks like OMS ID is case sensitive
            if (pong.OmsID != omsId)
            {
                throw new InvalidOperationException("OMS Service seems to be unavailable. " +
                    $"Unrecognized response: expected {omsId}, got {pong.OmsID}.");
            }

            return pong.OmsID;
        }

        /// <summary>
        /// Gets the current API and OMS versions.
        /// 4.5.13. Метод «Получить версию СУЗ и API»
        /// </summary>
        public AppVersion GetVersion() => Get<AppVersion>("{extension}/version", new[]
        {
            new Parameter("extension", Extension, ParameterType.UrlSegment),
        });

        /// <summary>
        /// 4.5.14 Метод «Получить список идентификаторов пакетов кодов маркировки»
        /// </summary>
        /// <remarks>
        /// postman: _SUZ 4.5.14. milk/codes/blocks
        /// </remarks>
        /// <param name="orderId">
        /// Идентификатор заказа кодов маркировки. Строковое значение.
        /// Значение идентификатора в соответствии с ISO/IEC 9834-8.
        /// Шаблон: [0-9a-fA-F]{ 8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fAF]{12}
        /// </param>
        /// <param name="gtin">
        /// Код товара(GTIN), по которому запрашиваются идентификаторы
        /// пакетов кодов маркировки. Шаблон: [0-9]{14}
        /// </param>
        public BlocksDto GetCodeBlocks(string orderId, string gtin)
        {
            return Get<BlocksDto>("{extension}/codes/blocks", new[]
            {
                new Parameter("extension", Extension, ParameterType.UrlSegment),
                new Parameter("omsId", OmsCredentials.OmsID, ParameterType.QueryString),
                new Parameter("orderId", orderId.ToLower(), ParameterType.QueryString),//To lower is added because FM is case sensitive here. For example ADECDCA0-EA70-4B83-A7FD-A8E4E937E0C5=error; adecdca0-ea70-4b83-a7fd-a8e4e937e0c5=ok
                new Parameter("gtin", gtin, ParameterType.QueryString),
            });
        }

        /// <summary>
        /// 4.5.15 Метод «Получить повторно коды маркировки из заказа кодов маркировки»
        /// </summary>
        /// <param name="orderId">Идентификатор заказа на эмиссию КМ СУЗ</param>
        /// <param name="gtin">GTIN товара, по которому требуется прекратить выдачу КМ</param>
        /// <param name="lastBlockId">
        /// Идентификатор блока кодов. Строковое значение. 
        /// Значение идентификатора в соответствии с ISO/IEC 9834-8.
        /// Шаблон: [0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fAF]{12}
        /// </param>
        /// <remarks>
        /// postman: _SUZ 4.5.15. milk/codes/retry
        /// </remarks>
        public CodesDto RetryCodes(string orderId, string gtin, string blockId)
        {
            return Get<CodesDto>("{extension}/codes/retry", new[]
            {
                new Parameter("extension", Extension, ParameterType.UrlSegment),
                new Parameter("omsId", OmsCredentials.OmsID, ParameterType.QueryString),
                new Parameter("orderId", orderId.ToLower(), ParameterType.QueryString),//To lower is added because FM is case sensitive here. For example ADECDCA0-EA70-4B83-A7FD-A8E4E937E0C5=error; adecdca0-ea70-4b83-a7fd-a8e4e937e0c5=ok
                new Parameter("gtin", gtin, ParameterType.QueryString),
                new Parameter("blockId", blockId.ToLower(), ParameterType.QueryString),//To lower is added because FM is case sensitive here. For example ADECDCA0-EA70-4B83-A7FD-A8E4E937E0C5=error; adecdca0-ea70-4b83-a7fd-a8e4e937e0c5=ok
            });
        }
        public CodesDto RetryCodes(Guid orderId, string gtin, Guid blockId)
        {
            return RetryCodes(orderId.ToString(), gtin, blockId.ToString());
        }

        /// <summary>
        /// 4.5.16. Метод «Получить квитанцию по уникальному идентификатору документа»
        /// </summary>
        /// <param name="docId">Уникальный идентификатор документа (заказа или отчета)</param>
        public ReceiptsDto GetReceipts(string docId)
        {
            return Get<ReceiptsDto>("{extension}/receipts", new[]
            {
                new Parameter("extension", Extension, ParameterType.UrlSegment),
                new Parameter("omsId", OmsCredentials.OmsID, ParameterType.QueryString),
                new Parameter("docId", docId, ParameterType.QueryString),
            });
        }

        /// <summary>
        /// 4.5.17. Метод «Получить список сервис-провайдеров»
        /// </summary>
        public ProvidersDto GetServiceProviders()
        {
            return Get<ProvidersDto>("{extension}/providers", new[]
            {
                new Parameter("extension", Extension, ParameterType.UrlSegment),
                new Parameter("omsId", OmsCredentials.OmsID, ParameterType.QueryString),
            });
        }

        /// <summary>
        /// 4.5.18. Метод «Получить список атрибутов продуктов заказа»
        /// </summary>
        public Dictionary<string, ProductsInfo> GetCardsInfo(string orderId)
        {
            return Get<Dictionary<string, ProductsInfo>>("{extension}/order/product", new[]
            {
                new Parameter("extension", Extension, ParameterType.UrlSegment),
                new Parameter("omsId", OmsCredentials.OmsID, ParameterType.QueryString),
                new Parameter("orderId", orderId.ToLower(), ParameterType.QueryString)
            });
        }
    }
}
