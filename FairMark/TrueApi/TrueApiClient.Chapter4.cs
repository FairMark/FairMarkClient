namespace FairMark.TrueApi
{
    using System;
    using System.Text;
    using DataContracts;
    using RestSharp;
    using Toolbox;

    public partial class TrueApiClient
    {
        /// <summary>
        /// 4.2.2.1 Аггрегация
        /// </summary>
        //TODO Можно сделать единый метод отправки доументов
        public string Aggregation(AggregationDocument Document)
        {
            var json = Serializer.Serialize(Document);
            var signature = GostCryptoHelpers.ComputeDetachedSignature(UserCertificate, json);
            var jsonBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            var response = Post("/lk/documents/create", new DocumentBase()
            {
                DocumentFormat = Registration.DocumentFormatJson,
                Document = jsonBase64,
                Signature = signature,
                Type = Document.DocumentName
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
