namespace FairMark
{
    using DataContracts;
    using RestSharp;
    using RestSharp.Authenticators;

    /// <summary>
    /// True API authenticator using credentials.
    /// </summary>
    internal class CredentialsAuthenticator : IAuthenticator
    {
        public CredentialsAuthenticator(CommonApiClient apiClient, CommonCredentials credentials)
        {
            State = AuthState.NotAuthenticated;
            Client = apiClient;
            Credentials = credentials;
        }

        private CommonApiClient Client { get; set; }

        private CommonCredentials Credentials { get; set; }

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

        public virtual void Authenticate(IRestClient client, IRestRequest request)
        {
            // perform authentication request
            if (State == AuthState.NotAuthenticated)
            {
                State = AuthState.InProgress;
                AuthToken = Credentials.Authenticate(Client);
                SetAuthToken(AuthToken.Token);
                State = AuthState.Authenticated;
                Client.IsAuthenticated = true;
            }

            // add authorization header if any
            if (!string.IsNullOrWhiteSpace(AuthHeader))
            {
                request.AddOrUpdateParameter("Authorization", AuthHeader, ParameterType.HttpHeader);
            }
        }

        public virtual void Logout()
        {
            Credentials.Logout(Client);
            State = AuthState.NotAuthenticated;
            AuthToken = null;
            Client.IsAuthenticated = false;
        }
    }
}
