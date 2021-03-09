using FairMark.TrueApi.DataContracts;
using RestSharp;
using RestSharp.Authenticators;

namespace FairMark.TrueApi
{
    /// <summary>
    /// True API authenticator using credentials.
    /// </summary>
    internal class CredentialsAuthenticator : IAuthenticator
    {
        public CredentialsAuthenticator(TrueApiClient apiClient, Credentials credentials)
        {
            State = AuthState.NotAuthenticated;
            Client = apiClient;
            Credentials = credentials;
        }

        private TrueApiClient Client { get; set; }

        private Credentials Credentials { get; set; }

        private AuthState State { get; set; }

        private enum AuthState
        {
            NotAuthenticated, InProgress, Authenticated
        }

        internal AuthToken AuthToken { get; set; }

        private string AuthHeader { get; set; }

        public void SetAuthToken(string authToken)
        {
            AuthHeader = string.IsNullOrWhiteSpace(authToken) ?
                null : "Bearer " + authToken;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            // perform authentication request
            if (State == AuthState.NotAuthenticated)
            {
                State = AuthState.InProgress;
                AuthToken = Credentials.Authenticate(Client);
                SetAuthToken(AuthToken.Token);
                State = AuthState.Authenticated;
            }

            // add authorization header if any
            if (!string.IsNullOrWhiteSpace(AuthHeader))
            {
               request.AddOrUpdateParameter("Authorization", AuthHeader, ParameterType.HttpHeader);
            }
        }

        public void Logout()
        {
            State = AuthState.NotAuthenticated;
            AuthToken = null;
        }
    }
}
