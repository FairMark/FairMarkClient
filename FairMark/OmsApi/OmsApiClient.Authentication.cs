using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairMark.DataContracts;
using FairMark.Toolbox;

namespace FairMark.OmsApi
{
    public partial class OmsApiClient
    {
        /// <summary>
        /// Authentication Step 1.
        /// TODO: Ссылка на документацию СУЗ?
        /// Запрос авторизации при единой аутентификации
        /// </summary>
        internal override AuthResponse Authenticate()
        {
            return Get<AuthResponse>(AuthUrl + "auth/cert/key");
        }

        /// <summary>
        /// Authentication Step 2.
        /// TODO: Ссылка на документацию СУЗ?
        /// Получение ключа сессии при единой аутентификации
        /// </summary>
        internal override AuthToken GetToken(AuthResponse authResponse, string signedData)
        {
            var token = Post<AuthToken>(AuthUrl + "auth/cert", new
            {
                uuid = authResponse.UUID,
                data = signedData,
            });

            IsAuthenticated = true;
            return token;
        }

        /// <summary>
        /// Invalidating the authentication token is not supported.
        /// TODO: Ссылка на документацию СУЗ?
        /// </summary>
        internal override void Logout()
        {
            // Get("logout"); is not supported
            (Client.Authenticator as CredentialsAuthenticator)?.Logout();
            IsAuthenticated = false;
        }
    }
}
