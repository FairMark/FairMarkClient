using System;
using System.Net;
using FairMark.OmsApi.DataContracts;
using RestSharp;

namespace FairMark.OmsApi
{
    partial class OmsApiClient
    {
        /// <summary>
        /// Creates a new CIS emission order.
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
        /// <param name="order">Code emission order.</param>
        public OrderResponse CreateOrder(Order order)
        {
            return Post<OrderResponse>("{extension}/orders", order, new[]
            {
                new Parameter("extension", Extension, ParameterType.UrlSegment),
                new Parameter("omsId", OmsCredentials.OmsID, ParameterType.QueryString),
            });
        }

        // 4.5.6. Метод «Получить КМ из заказа»
        // postman: _SUZ 4.5.6. milk/codes
        //      Запрос, кажется, готов, но статусы всех последних заказов "Создан".
        //      Видимо, они ещё не обработаны до конца и метод всё время возвращает что заказа нет, или ГТИНа в заказе нет)

        // 4.5.7. Метод «Получить статус массива КМ из заказа»
        // postman: SUZ 4.5.7. milk/buffer/status

        // 4.5.8. Метод «Получить статус заказов»
        // postman: SUZ 4.5.1. milk/orders

        // 4.5.14 Метод «Получить список идентификаторов пакетов кодов маркировки»
        // postman: _SUZ 4.5.14. milk/codes/blocks
        //      Тут муть подобная 4.4.6.

        // 4.5.15 Метод «Получить повторно коды маркировки из заказа кодов маркировки»
        // postman: _SUZ 4.5.15. milk/codes/retry
        //      Тут муть подобная 4.4.6.

        /// <summary>
        /// Ping OMS to check if it's available.
        /// 4.5.11. Метод «Проверить доступность СУЗ»
        /// </summary>
        public string Ping()
        {
            var omsId = OmsCredentials.OmsID;
            var pong = Get<Pong>($"{Extension}/ping", new[]
            {
                new Parameter("omsId", omsId, ParameterType.QueryString),
            });

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
        public Versions GetVersion()
        {
            return Get<Versions>($"{Extension}/version");
        }
    }
}
