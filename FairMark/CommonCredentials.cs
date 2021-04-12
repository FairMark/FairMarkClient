using System;
using FairMark.DataContracts;

namespace FairMark
{
    /// <summary>
    /// Common FairMark credentials for True API, OMS API, etc.
    /// Credentials class stores the authentication data and implements
    /// the authentication protocol when connection is established.
    /// </summary>
    public abstract class CommonCredentials
    {
        /// <summary>
        /// Gets or sets the user identity, same as the cryptographic certificate thumbprint.
        /// </summary>
        public string CertificateThumbprint { get; set; }

        /// <summary>
        /// Performs authentication, returns access token with a limited lifetime.
        /// </summary>
        /// <param name="apiClient">REST API client to perform API calls.</param>
        /// <returns><see cref="AuthToken"/> instance.</returns>
        public abstract AuthToken Authenticate(CommonApiClient apiClient);

        /// <summary>
        /// Invalidates the authentication token and closes the session.
        /// </summary>
        /// <param name="apiClient">REST API clientn to perform API calls.</param>
        public abstract void Logout(CommonApiClient apiClient);

        /// <summary>
        /// Formats the authentication header for REST requests.
        /// </summary>
        /// <param name="authToken">Authentication token.</param>
        public abstract Tuple<string, string> FormatAuthHeader(string authToken);
    }
}