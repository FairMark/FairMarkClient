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
        /// 4.2.5.1 Ввод в оборот
        /// </summary>
        public string IntroduceGoodsRF(IntroduceGoodsDocumentRF organizationInfo)
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
