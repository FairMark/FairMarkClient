using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using FairMark.DataContracts;
using FairMark.Toolbox;
using RestSharp;

namespace FairMark.EdoLite
{
    /// <summary>
    /// EDO Lite authentication credentials.
    /// </summary>
    public class EdoLiteCredentials : CommonCredentials
    {
        /// <summary>
        /// Performs authentication, returns access token with a limited lifetime.
        /// </summary>
        /// <param name="apiClient">API client to perform API calls.</param>
        /// <returns><see cref="AuthToken"/> instance.</returns>
        public override AuthToken Authenticate(CommonApiClient apiClient)
        {
            // make sure it's an OMS client
            var edoLiteClient = apiClient as EdoLiteClient;
            if (edoLiteClient == null)
            {
                throw new InvalidOperationException("EdoLiteCredentials requires EdoLiteClient.");
            }

            // check if the token is already available
            var authToken = CheckSessionToken(edoLiteClient);
            if (authToken != null)
            {
                return authToken;
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
            var authResponse = Authenticate(edoLiteClient);

            // compute the signature and save the size
            var signedData = GostCryptoHelpers.ComputeAttachedSignature(certificate, authResponse.Data);
            apiClient.SignatureSize = Encoding.UTF8.GetByteCount(signedData);

            // get authentication token
            return GetToken(edoLiteClient, authResponse, signedData);
        }

        private AuthToken CheckSessionToken(EdoLiteClient edoLiteClient)
        {
            if (string.IsNullOrWhiteSpace(SessionToken?.Token))
            {
                // session token is not specified
                return null;
            }

            try
            {
                // try calling a simple authenticated API method
                var authHeader = FormatAuthHeader(SessionToken);
                var pong = edoLiteClient.Get("incoming-documents", new[]
                {
                    new Parameter("limit", 0, ParameterType.QueryString),
                    new Parameter(authHeader.Item1, authHeader.Item2, ParameterType.HttpHeader),
                });

                return SessionToken;
            }
            catch
            {
                // session token is not valid
                return null;
            }
        }

        /// <summary>
        /// Authentication Step 1.
        /// 2.1. Запрос авторизации
        /// </summary>
        private AuthResponse Authenticate(EdoLiteClient omsClient)
        {
            return omsClient.Get<AuthResponse>("session");
        }

        /// <summary>
        /// Authentication Step 2.
        /// 2.2. Получение ключа сессии
        /// </summary>
        private AuthToken GetToken(EdoLiteClient omsClient, AuthResponse authResponse, string signedData)
        {
            return omsClient.Post<AuthToken>("session", new
            {
                uuid = authResponse.UUID,
                data = signedData,
            });
        }

        /// <summary>
        /// Not supported by EDO Lite API.
        /// </summary>
        public override void Logout(CommonApiClient client)
        {
            //// Get("logout"); is not supported
        }

        /// <summary>
        /// Formats the authentication header.
        /// </summary>
        /// <param name="authToken">Authentication token.</param>
        public override Tuple<string, string> FormatAuthHeader(AuthToken authToken)
        {
            // EDO Lite API uses different authorization header formats for MDLP and GIS MT documents
            return Tuple.Create("Authorization", $"{authToken.Type} {authToken.Token}");
        }
    }
}
