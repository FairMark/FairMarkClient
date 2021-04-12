using System;
using FairMark.DataContracts;

namespace FairMark.TrueApi
{

    public partial class TrueApiClient
    {
        // TODO: remove
        internal override AuthResponse Authenticate()
        {
            throw new NotSupportedException();
        }

        // TODO: remove
        internal override AuthToken GetToken(AuthResponse authResponse, string signedData)
        {
            throw new NotSupportedException();
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
