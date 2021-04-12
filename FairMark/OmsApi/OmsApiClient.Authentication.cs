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
        // TODO: remove this
        internal override AuthResponse Authenticate()
        {
            throw new NotSupportedException();
        }

        // TODO: remove this
        internal override AuthToken GetToken(AuthResponse authResponse, string signedData)
        {
            throw new NotSupportedException();
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
