namespace FairMark
{
    using System;
    using DataContracts;
    using RestSharp;
    using RestSharp.Authenticators;

    /// <summary>
    /// RestSharp client authenticator.
    /// Uses credentials to log in to the API and get the auth token.
    /// Sets the authentication headers on each REST request.
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

        public bool IsAuthenticated => State == AuthState.Authenticated;

        internal AuthToken AuthToken { get; set; }

        private Tuple<string, string> AuthHeader { get; set; }

        protected virtual void SetAuthHeader(AuthToken authToken)
        {
            AuthHeader = string.IsNullOrWhiteSpace(authToken?.Token) ? null :
                Credentials.FormatAuthHeader(authToken);
        }

        public virtual void Authenticate(IRestClient client, IRestRequest request)
        {
            // perform authentication request
            if (State == AuthState.NotAuthenticated)
            {
                State = AuthState.InProgress;
                AuthToken = Credentials.Authenticate(Client);
                SetAuthHeader(AuthToken);
                State = AuthState.Authenticated;
            }

            // add authorization header if specified
            if (AuthHeader != null)
            {
                request.AddOrUpdateParameter(AuthHeader.Item1, AuthHeader.Item2, ParameterType.HttpHeader);
            }
        }

        public virtual void Logout()
        {
            Credentials.Logout(Client);
            State = AuthState.NotAuthenticated;
            AuthToken = null;
            AuthHeader = null;
        }
    }
}
