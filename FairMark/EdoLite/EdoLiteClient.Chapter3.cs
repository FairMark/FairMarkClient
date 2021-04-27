using System;
using System.Collections.Generic;
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
    }
}
