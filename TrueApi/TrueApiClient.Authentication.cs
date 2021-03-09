using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairMark.TrueApi.DataContracts;
using FairMark.TrueApi.Toolbox;
using RestSharp;
using RestSharp.Serialization.Json;

namespace FairMark.TrueApi
{
    partial class TrueApiClient
    {
        /// <summary>
        /// Authentication Step 1.
        /// 1.5.1. Запрос авторизации при единой аутентификации
        /// </summary>
        internal AuthResponse Authenticate()
        {
            return Get<AuthResponse>("auth/key");
        }

        /// <summary>
        /// Authentication Step 2.
        /// 1.5.2. Получение ключа сессии при единой аутентификации
        /// </summary>
        internal AuthToken GetToken(AuthResponse authResponse, string signedData)
        {
            var token = Post<AuthToken>("auth/simpleSignIn", new
            {
                uuid = authResponse.UUID,
                data = signedData,
            });

            IsAuthenticated = true;
            return token;
        }

        /// <summary>
        /// Invalidating the authentication token is not supported.
        /// </summary>
        internal void Logout()
        {
            // Get("logout"); is not supported
            IsAuthenticated = false;
        }
    }
}
