using FairMark.DataContracts;

namespace FairMark.TrueApi
{

    public partial class TrueApiClient
    {
        /// <summary>
        /// Authentication Step 1.
        /// 1.5.1. Запрос авторизации при единой аутентификации
        /// </summary>
        internal override AuthResponse Authenticate()
        {
            return Get<AuthResponse>("auth/key");
        }

        /// <summary>
        /// Authentication Step 2.
        /// 1.5.2. Получение ключа сессии при единой аутентификации
        /// </summary>
        internal override AuthToken GetToken(AuthResponse authResponse, string signedData)
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
        internal override void Logout()
        {
            // Get("logout"); is not supported
            (Client.Authenticator as CredentialsAuthenticator)?.Logout();
            IsAuthenticated = false;
        }
    }
}
