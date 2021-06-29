namespace FairMark.TrueApi
{
    using System;
    using DataContracts;
    using RestSharp;

    public partial class TrueApiClient
    {
        /// <summary>
        /// 6.4. Метод получения содержимого документа по идентификатору
        /// </summary>
        /// <param name="documentId">ID документа, формируемый в ГИС МТ</param>
        /// <param name="limit">Значение устанавливает количество записей в ответе(не более 10 000 записей, по умолчанию 10 записей)
        /// Примечание: При указании данного параметра необходимо указать товарную группу</param>
        /// <param name="productGroup">Товарная групп
        /// Примечание: Параметр обязательный для товарных групп: milk – Молочная продукция; water – Упакованная вода</param>
        /// <returns></returns>
        public string[] GetDocumentInfo(Guid docId, int limit, ProductGroupsTrueApi productGroup)
        {
            return GetDocumentInfo(docId.ToString(), limit, productGroup);
        }
        /// <summary>
        /// 6.4. Метод получения содержимого документа по идентификатору
        /// </summary>
        /// <param name="documentId">ID документа, формируемый в ГИС МТ</param>
        /// <param name="limit">Значение устанавливает количество записей в ответе(не более 10 000 записей, по умолчанию 10 записей)
        /// Примечание: При указании данного параметра необходимо указать товарную группу</param>
        /// <param name="productGroup">Товарная групп
        /// Примечание: Параметр обязательный для товарных групп: milk – Молочная продукция; water – Упакованная вода</param>
        /// <returns></returns>
        public string[] GetDocumentInfo(string docId, int limit, ProductGroupsTrueApi productGroup)
        {
            return Get<string[]>("/doc/{docId}/info", new[]
            {
                new Parameter("docId", docId, ParameterType.UrlSegment),
                new Parameter("limit", limit.ToString(), ParameterType.QueryString),
                new Parameter("pg", productGroup.ToString(), ParameterType.UrlSegment)
            });

        }



        /// <summary>
        /// 6.9. Метод получения списка КИ по номеру документа.
        /// </summary>
        /// <param name="docNum"></param>
        /// <returns>Список КИ</returns>
        public string[] GetCisesByOrderId(string docNum) // TODO Сделать поддержку второго параметра pg (товарная группа)
        {
            return Get<string[]>("/cises/doc/{docNum}", new[] { new Parameter("docNum", docNum, ParameterType.UrlSegment) });
        }


    }
}
