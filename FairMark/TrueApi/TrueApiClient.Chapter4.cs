namespace FairMark.TrueApi
{
    using System;
    using System.Text;
    using DataContracts;
    using RestSharp;
    using Toolbox;

    public partial class TrueApiClient
    {
        public UniformDocument PrepareUniformDocument(IUniformDocumentBase document)
        {
            var Serializer = new ServiceStackSerializer();
            var json = Serializer.Serialize(document);
            var signature = GostCryptoHelpers.ComputeDetachedSignature(UserCertificate, json);
            var jsonBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            return new UniformDocument() { DocumentBase64 = jsonBase64, Signature = signature, Type = document.DocumentApiName };
        }

        /// <summary>
        /// 4.1. Send unified document method
        /// </summary>
        public string SendUniformDocument(IUniformDocumentBase document)
        {
            var response = Post("/lk/documents/create",
                PrepareUniformDocument(document),
                new Parameter[] { new RestSharp.Parameter("pg", document.ProductGroup, ParameterType.QueryString) });

            return response;
        }


        /// <summary>
        /// 4.2.2.1 Аггрегация
        /// </summary>
        [Obsolete("Use SendUniformDocument() method")]
        public string Aggregation(AggregationDocument Document)
        {
            var json = Serializer.Serialize(Document);
            var signature = GostCryptoHelpers.ComputeDetachedSignature(UserCertificate, json);
            var jsonBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            var response = Post("/lk/documents/create", new UniformDocument()
            {
                DocumentBase64 = jsonBase64,
                Signature = signature,
                Type = "AGGREGATION_DOCUMENT"
            },
            new Parameter[] { new RestSharp.Parameter("pg", "milk", ParameterType.QueryString) });

            return response;
        }


        /// <summary>
        /// 4.2.5.1 Ввод в оборот
        /// </summary>
        public string IntroduceGoodsRF(LP_INTRODUCE_GOODS organizationInfo)
        {
            throw new NotImplementedException();
            var json = Serializer.Serialize(organizationInfo);
            var signature = GostCryptoHelpers.ComputeDetachedSignature(UserCertificate, json);
            var jsonBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            var response = Post<RegistrationResponse>("/elk/registration", new Registration
            {
                DocumentFormat = Registration.DocumentFormatJson,
                ProductDocument = jsonBase64,
                Signature = signature,
            });

            return response.RegistrationRequestDocID;
        }
    }
}
