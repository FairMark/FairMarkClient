﻿using System;
using System.Security;
using System.Text;
using FairMark.DataContracts;
using FairMark.Toolbox;

namespace FairMark.TrueApi
{
    /// <summary>
    /// True API credentials.
    /// </summary>
    public class TrueApiCredentials : CommonCredentials
    {
        /// <summary>
        /// Performs authentication, returns access token with a limited lifetime.
        /// </summary>
        /// <param name="apiClient">True API client to perform API calls.</param>
        /// <returns><see cref="AuthToken"/> instance.</returns>
        public override AuthToken Authenticate(CommonApiClient apiClient)
        {
            // make sure it's a True API client
            var trueApiClient = apiClient as TrueApiClient;
            if (trueApiClient == null)
            {
                throw new InvalidOperationException("TrueApiCredentials requires TrueApiClient.");
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
            var authResponse = apiClient.Authenticate();

            // compute the signature and save the size
            var signedData = GostCryptoHelpers.ComputeAttachedSignature(certificate, authResponse.Data);
            apiClient.SignatureSize = Encoding.UTF8.GetByteCount(signedData);

            // get authentication token
            return apiClient.GetToken(authResponse, signedData);
        }

        /// <summary>
        /// Authentication Step 1.
        /// 1.5.1. Запрос авторизации при единой аутентификации
        /// </summary>
        private AuthResponse Authenticate(TrueApiClient apiClient)
        {
            return apiClient.Get<AuthResponse>("auth/key");
        }

        /// <summary>
        /// Authentication Step 2.
        /// 1.5.2. Получение ключа сессии при единой аутентификации
        /// </summary>
        private AuthToken GetToken(TrueApiClient apiClient, AuthResponse authResponse, string signedData)
        {
            return apiClient.Post<AuthToken>("auth/simpleSignIn", new
            {
                uuid = authResponse.UUID,
                data = signedData,
            });
        }

        /// <summary>
        /// Not supported by True API.
        /// </summary>
        public override void Logout(CommonApiClient client)
        {
            //// Get("logout"); is not supported
        }
    }
}