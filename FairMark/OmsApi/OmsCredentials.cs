using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using FairMark.DataContracts;
using FairMark.Toolbox;

namespace FairMark.OmsApi
{
    /// <summary>
    /// OMS API authentication credentials.
    /// </summary>
    public class OmsCredentials : CommonCredentials
    {
        /// <summary>
        /// Gets or sets the OMS Connection Identity, taken from the user's profile,
        /// see https://intuot.crpt.ru:12011/configuration/profile
        /// </summary>
        public string OmsConnectionID { get; set; }

        /// <summary>
        /// Performs authentication, returns access token with a limited lifetime.
        /// </summary>
        /// <param name="apiClient">GIS MT client to perform API calls.</param>
        /// <returns><see cref="AuthToken"/> instance.</returns>
        public override AuthToken Authenticate(CommonApiClient apiClient)
        {
            // make sure it's an OMS client
            var omsClient = apiClient as OmsApiClient;
            if (omsClient == null)
            {
                throw new InvalidOperationException("OmsCredentials requires OmsApiClient.");
            }

            // load the certificate with a private key by userId
            var certificate = apiClient.UserCertificate;
            if (certificate == null)
            {
                throw new SecurityException("GOST-compliant certificate not found. " +
                    "Make sure that the certificate is properly installed and has the associated private key. " +
                    "Thumbprint or subject name: " + CertificateThumbprint);
            }

            // get authentication code
            var authResponse = Authenticate(omsClient);

            // compute the signature and save the size
            var signedData = GostCryptoHelpers.ComputeAttachedSignature(certificate, authResponse.Data);
            apiClient.SignatureSize = Encoding.UTF8.GetByteCount(signedData);

            // get authentication token
            return apiClient.GetToken(authResponse, signedData);
        }

        /// <summary>
        /// Authentication Step 1.
        /// 10.3.2.1. Запрос авторизации при единой аутентификации
        /// </summary>
        private AuthResponse Authenticate(OmsApiClient omsClient)
        {
            var url = omsClient.AuthUrl + "auth/cert/key";
            return omsClient.Get<AuthResponse>(url);
        }

        /// <summary>
        /// Authentication Step 2.
        /// 10.3.2.2. Получение аутентификационного токена
        /// </summary>
        private AuthToken GetToken(OmsApiClient omsClient, AuthResponse authResponse, string signedData)
        {
            var url = omsClient.AuthUrl + "auth/cert/6242a186-970c-4260-9bd9-b8f19ed66d4d";

            return omsClient.Post<AuthToken>(url, new
            {
                uuid = authResponse.UUID,
                data = signedData,
            });
        }

        /// <summary>
        /// Not supported by OMS Cloud API.
        /// </summary>
        public override void Logout(CommonApiClient client)
        {
            //// Get("logout"); is not supported
        }
    }
}
