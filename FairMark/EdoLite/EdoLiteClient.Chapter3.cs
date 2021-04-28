using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using FairMark.EdoLite.DataContracts;
using FairMark.OmsApi.DataContracts;
using FairMark.Toolbox;
using RestSharp;

namespace FairMark.EdoLite
{
    partial class EdoLiteClient
    {
        /// <summary>
        /// 3.1. Метод загрузки файла информации продавца УПД согласно приказу 820 от 19.12.2018 № ММВ-7-15/820@ в формате XML
        /// </summary>
        /// <remarks>
        /// * Сервер принимает только документы в кодировке windows-1251.
        /// * Трассировка этого метода неполная: multipart/form-data не отображается.
        /// </remarks>
        /// <param name="fileName">Имя файла, сформированное согласно стандарту формирования</param>
        /// <param name="xmlFileContents">Содержимое XML-файла, должно быть согласовано с именем</param>
        /// <param name="signed">Подписывать документ перед отсылкой</param>
        public string SendSellerUpdDocument(string fileName, string xmlFileContents, bool signed = true)
        {
            var request = new RestRequest("outgoing-documents", Method.POST, DataFormat.Json);
            request.AlwaysMultipartFormData = true;

            // сервер принимает XML-документы только в кодировке windows-1251
            var content = Encoding.GetEncoding(1251).GetBytes(xmlFileContents);
            request.AddFile("content", content, fileName, "application/xml");

            // если документ подписывается, то в той же кодировке, что и отсылается
            if (signed)
            {
                var signature = GostCryptoHelpers.ComputeDetachedSignature(UserCertificate, content);
                request.Parameters.Add(new Parameter("signature", signature, ParameterType.GetOrPost));
            }

            var result = Execute<ResID>(request);
            return result.ID;
        }

        /// <summary>
        /// 3.2. Метод загрузки файла информации продавца УПДи согласно приказу 820 от 19.12.2018 № ММВ-7-15/820@ в формате XML
        /// </summary>
        /// <remarks>
        /// * Сервер принимает только документы в кодировке windows-1251.
        /// * Трассировка этого метода неполная: multipart/form-data не отображается.
        /// </remarks>
        /// <param name="fileName">Имя файла, сформированное согласно стандарту формирования</param>
        /// <param name="xmlFileContents">Содержимое XML-файла, должно быть согласовано с именем</param>
        /// <param name="parentId">Идентификатор родительского документа</param>
        /// <param name="signed">Подписывать документ перед отсылкой</param>
        public string SendSellerUpdiDocument(string fileName, string xmlFileContents, string parentId, bool signed = true)
        {
            var request = new RestRequest("outgoing-documents/xml/updi", Method.POST, DataFormat.Json);
            request.AlwaysMultipartFormData = true;
            request.Parameters.Add(new Parameter("parent_id", parentId, ParameterType.GetOrPost));

            // сервер принимает XML-документы только в кодировке windows-1251
            var content = Encoding.GetEncoding(1251).GetBytes(xmlFileContents);
            request.AddFile("content", content, fileName, "application/xml");

            // если документ подписывается, то в той же кодировке, что и отсылается
            if (signed)
            {
                var signature = GostCryptoHelpers.ComputeDetachedSignature(UserCertificate, content);
                request.Parameters.Add(new Parameter("signature", signature, ParameterType.GetOrPost));
            }

            var result = Execute<ResID>(request);
            return result.ID;
        }

        /// <summary>
        /// 3.3. Методы загрузки информации продавца УКД согласно приказу 189 от 13 апреля 2016 г.в формате XML
        /// </summary>
        /// <remarks>
        /// * Сервер принимает только документы в кодировке windows-1251.
        /// * Трассировка этого метода неполная: multipart/form-data не отображается.
        /// </remarks>
        /// <param name="fileName">Имя файла, сформированное согласно стандарту формирования</param>
        /// <param name="xmlFileContents">Содержимое XML-файла, должно быть согласовано с именем</param>
        /// <param name="parentId">Идентификатор родительского документа</param>
        /// <param name="signed">Подписывать документ перед отсылкой</param>
        public string SendSellerUkdDocument(string fileName, string xmlFileContents, string parentId, bool signed = true)
        {
            var request = new RestRequest("outgoing-documents/xml/ukd", Method.POST, DataFormat.Json);
            request.AlwaysMultipartFormData = true;
            request.Parameters.Add(new Parameter("parent_id", parentId, ParameterType.GetOrPost));

            // сервер принимает XML-документы только в кодировке windows-1251
            var content = Encoding.GetEncoding(1251).GetBytes(xmlFileContents);
            request.AddFile("content", content, fileName, "application/xml");

            // если документ подписывается, то в той же кодировке, что и отсылается
            if (signed)
            {
                var signature = GostCryptoHelpers.ComputeDetachedSignature(UserCertificate, content);
                request.Parameters.Add(new Parameter("signature", signature, ParameterType.GetOrPost));
            }

            var result = Execute<ResID>(request);
            return result.ID;
        }

        /// <summary>
        /// 3.4. Получение содержимого входящего XML документа
        /// </summary>
        /// <param name="docId">Идентификатор документа</param>
        public string GetIncomingDocument(string docId)
        {
            return Get("incoming-documents/{doc_id}/content", new[]
            {
                new Parameter("doc_id", docId, ParameterType.UrlSegment),
            });
        }

        /// <summary>
        /// 3.4. Получение содержимого иcходящего XML документа
        /// </summary>
        /// <param name="docId">Идентификатор документа</param>
        public string GetOutgoingDocument(string docId)
        {
            return Get("outgoing-documents/{doc_id}/content", new[]
            {
                new Parameter("doc_id", docId, ParameterType.UrlSegment),
            });
        }

        /// <summary>
        /// 3.5. Подписание исходящего документа
        /// </summary>
        /// <param name="docId">Идентификатор документа</param>
        /// <param name="xmlFileContents">XML-содержимое документа (опционально: если не передать, документ будет запрошен через API).</param>
        public void SignOutgoingDocument(string docId, string xmlFileContents = null)
        {
            // если документ не передан, получить содержимое документа и подписать его
            xmlFileContents = xmlFileContents ?? GetOutgoingDocument(docId);
            var docBytes = Encoding.GetEncoding(1251).GetBytes(xmlFileContents);
            var signature = GostCryptoHelpers.ComputeDetachedSignature(UserCertificate, docBytes);

            var url = "outgoing-documents/{doc_id}/signature";
            var request = new RestRequest(url, Method.POST, DataFormat.Json);
            request.AddParameter(new Parameter("doc_id", docId, ParameterType.UrlSegment));
            request.AddParameter(new Parameter(string.Empty, signature, ParameterType.RequestBody));
            request.AddHeader("Content-encoding", "base64");
            request.AddHeader("Content-type", "text/plain");

            Execute(request);
        }

        private byte[] PrintDocument(string url, string docId)
        {
            var request = new RestRequest(url, Method.GET, DataFormat.Json);
            request.AddParameter(new Parameter("doc_id", docId, ParameterType.UrlSegment));

            var response = Execute(request);
            return response.RawBytes;
        }

        /// <summary>
        /// 3.6. Получение печатной формы УПД/УПДи/УКД
        /// </summary>
        /// <param name="docId">Идентификатор документа</param>
        /// <returns>Содержимое PDF-файла</returns>
        public byte[] PrintIncomingDocument(string docId) =>
            PrintDocument("incoming-documents/{doc_id}/print", docId);

        /// <summary>
        /// 3.6. Получение печатной формы УПД/УПДи/УКД
        /// </summary>
        /// <param name="docId">Идентификатор документа</param>
        /// <returns>Содержимое PDF-файла</returns>
        public byte[] PrintOutgoingDocument(string docId) =>
            PrintDocument("outgoing-documents/{doc_id}/print", docId);

        private byte[] DownloadZipArchive(string url, string docId)
        {
            var request = new RestRequest(url, Method.GET, DataFormat.Json);
            request.AddParameter(new Parameter("doc_id", docId, ParameterType.UrlSegment));
            request.AddHeader("Accept", "application/zip");

            var response = Execute(request);
            return response.RawBytes;
        }

        /// <summary>
        /// 3.7. Получение входящего ZIP архива с документооборотом УПД/УПДи/УКД.
        /// </summary>
        /// <param name="docId">Идентификатор документа</param>
        public byte[] DownloadIncomingZipArchive(string docId) =>
            DownloadZipArchive("incoming-documents/{doc_id}", docId);

        /// <summary>
        /// 3.7. Получение исходящего ZIP архива с документооборотом УПД/УПДи/УКД.
        /// </summary>
        /// <param name="docId">Идентификатор документа</param>
        public byte[] DownloadOutgoingZipArchive(string docId) =>
            DownloadZipArchive("outgoing-documents/{doc_id}", docId);

        private Parameter[] GetParameters(DocumentListFilter filter)
        {
            if (filter == null)
            {
                return new Parameter[0];
            }

            var parameters = new List<Parameter>();
            if (filter.Limit.HasValue)
            {
                parameters.Add(new Parameter("limit", filter.Limit.Value, ParameterType.QueryString));
            }

            if (filter.Offset.HasValue)
            {
                parameters.Add(new Parameter("offset", filter.Offset.Value, ParameterType.QueryString));
            }

            if (filter.CreatedFrom.HasValue)
            {
                parameters.Add(new Parameter("created_from", filter.CreatedFrom.Value.ToUnixTimeSeconds(), ParameterType.QueryString));
            }

            if (filter.CreatedTo.HasValue)
            {
                parameters.Add(new Parameter("created_to", filter.CreatedTo.Value.ToUnixTimeSeconds(), ParameterType.QueryString));
            }

            return parameters.ToArray();
        }

        private List<DocumentGroup> GetDocuments(string url, DocumentListFilter filter)
        {
            var result = Get<GetDocumentsResponse>(url, GetParameters(filter));
            return result.Items;
        }

        /// <summary>
        /// 3.8. Получение списка исходящих документов
        /// </summary>
        /// <param name="filter">Параметры фильтра</param>
        public List<DocumentGroup> GetOutgoingDocuments(DocumentListFilter filter = null) =>
            GetDocuments("outgoing-documents", filter);

        /// <summary>
        /// 3.8. Получение списка входящих документов
        /// </summary>
        /// <param name="filter">Параметры фильтра</param>
        public List<DocumentGroup> GetIncomingDocuments(DocumentListFilter filter = null) =>
            GetDocuments("incoming-documents", filter);
    }
}
