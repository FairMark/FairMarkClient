using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using GisMtClient.DataContracts;
using GisMtClient.Serialization;
using GisMtClient.Toolbox;
using RestSharp;
using RestSharp.Serialization;

namespace GisMtClient
{
    /// <summary>
    /// GIS MT REST API Client.
    /// </summary>
    public class MtClient
    {
        /// <summary>
        /// Sandbox API HTTPS URL.
        /// </summary>
        public const string SandboxApiHttps = "https://ismp.crpt.ru/api/v3/";

        /// <summary>
        /// Initializes a new instance of the <see cref="MtClient"/> class.
        /// </summary>
        /// <param name="baseUrl">Base API URL, see <see cref="SandboxApiHttps"/>.</param>
        /// <param name="credentials">Credentials.</param>
        public MtClient(string baseUrl, Credentials credentials)
            : this(new RestClient(baseUrl), credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MtClient"/> class.
        /// </summary>
        /// <param name="client">REST API client, see <see cref="RestSharp"/>.</param>
        /// <param name="credentials">Credentials.</param>
        public MtClient(IRestClient client, Credentials credentials)
        {
            Credentials = credentials;
            Serializer = new ServiceStackSerializer();
            BaseUrl = client.BaseUrl.ToString();
            //Limiter = new RequestRateLimiter();

            // set up REST client
            Client = client;
            Client.Authenticator = new CredentialsAuthenticator(this, credentials);
            Client.Encoding = Encoding.UTF8;
            Client.ThrowOnDeserializationError = false;
            Client.UseSerializer(() => Serializer);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (IsAuthenticated)
            {
                Logout();
            }
        }

        /// <summary>
        /// Gets base API URL.
        /// </summary>
        public string BaseUrl { get; private set; }

        private IRestSerializer Serializer { get; set; }

        /// <summary>
        /// Gets the <see cref="IRestClient"/> instance.
        /// </summary>
        public IRestClient Client { get; private set; }

        private Credentials Credentials { get; set; }

        internal bool IsAuthenticated { get; private set; }

        private X509Certificate2 userCertificate;

        /// <summary>
        /// X.509 certificate of the resident user (if applicable).
        /// </summary>
        internal X509Certificate2 UserCertificate
        {
            set { userCertificate = value; }
            get
            {
                if (userCertificate == null)
                {
                    userCertificate = GostCryptoHelpers.FindCertificate(Credentials.UserID);
                }

                return userCertificate;
            }
        }

        /// <summary>
        /// Gets or sets the approximate signature size..
        /// </summary>
        public int SignatureSize { get; set; }

        internal AuthResponse Authenticate()
        {
            throw new NotImplementedException();
        }

        internal void Logout()
        {
            throw new NotImplementedException();
        }

        internal AuthToken GetToken(AuthResponse authResponse, string signature)
        {
            throw new NotImplementedException();
        }
    }
}
