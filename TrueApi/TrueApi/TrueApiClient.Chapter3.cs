namespace FairMark.TrueApi
{
    using System;
    using System.Text;
    using DataContracts;
    using DataContracts._3_1;
    using RestSharp;
    using Toolbox;

    public partial class TrueApiClient
    {
        /// <summary>
        /// 3.1.1. Метод создания заявки на регистрацию УОТ
        /// </summary>
        public string Register(ProductDocument organizationInfo)
        {
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

        /// <summary>
        /// 3.1.2. Метод проверки статуса заявки УОТ на регистрацию по ID заявки
        /// </summary>
        public RegistrationStatusResponse GetRegistrationStatus(int registrationDocId)
        {
            return Get<RegistrationStatusResponse>("/elk/documents/status/{documentId}", new[]
            {
                new Parameter("documentId", registrationDocId, ParameterType.UrlSegment),
            });
        }

        /// <summary>
        /// Invalidating the authentication token is not supported.
        /// </summary>
        internal void dLogout()
        {
            // Get("logout"); is not supported
            (Client.Authenticator as CredentialsAuthenticator)?.Logout();
            IsAuthenticated = false;
        }
    }
}
