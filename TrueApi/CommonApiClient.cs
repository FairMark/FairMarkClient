namespace FairMark
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Xml;
    using TrueApi.DataContracts;//TODO Может отсда это надо убрать?
    using RestSharp;
    using RestSharp.Serialization;
    using Toolbox;

    /// <summary>
    /// True API Client.
    /// </summary>
    public abstract partial class CommonApiClient
    {
        /// <summary>
        /// Sandbox API endpoint.
        /// </summary>
        public const string SandboxApiUrl =
            //"https://demo.lp.crpt.tech/api/v3/";
            //"https://demo.lp.crpt.tech/api/v3/auth/cert/key";
            "https://int01.gismt.crpt.tech/api/v3/true-api";

        /// <summary>
        /// Production API endpoint.
        /// </summary>
        public const string ProductionApiUrl = "https://ismp.crpt.ru/api/v3/";

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonApiClient"/> class.
        /// </summary>
        /// <param name="baseUrl">Base API URL, see <see cref="SandboxApiHttps"/>.</param>
        /// <param name="credentials">Credentials.</param>
        public CommonApiClient(string baseUrl, Credentials credentials)
            : this(new RestClient(baseUrl), credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonApiClient"/> class.
        /// </summary>
        /// <param name="client">REST API client, see <see cref="RestSharp"/>.</param>
        /// <param name="credentials">Credentials.</param>
        public CommonApiClient(IRestClient client, Credentials credentials)
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

        public IRestSerializer Serializer { get; set; }

        /// <summary>
        /// Gets the <see cref="IRestClient"/> instance.
        /// </summary>
        public IRestClient Client { get; private set; }

        private Credentials Credentials { get; set; }

        internal bool IsAuthenticated { get; set; }

        private X509Certificate2 userCertificate;

        /// <summary>
        /// X.509 certificate of the resident user (if applicable).
        /// </summary>
        public X509Certificate2 UserCertificate
        {
            private set { userCertificate = value; }
            get
            {
                if (userCertificate == null)
                {
                    userCertificate = GostCryptoHelpers.FindCertificate(Credentials.CertificateThumbprint);
                    if (userCertificate == null)
                        userCertificate = GostCryptoHelpers.FindCertificate(Credentials.CertificateThumbprint, StoreName.My, StoreLocation.CurrentUser);
                }

                return userCertificate;
            }
        }

        /// <summary>
        /// Gets or sets the approximate signature size..
        /// </summary>
        public int SignatureSize { get; set; }

        private void PrepareRequest(IRestRequest request, string apiMethodName)
        {
            // use request parameters to store additional properties, not really used by the requests
            request.AddParameter(ApiTimestampParameterName, DateTime.Now.Ticks, ParameterType.UrlSegment);
            request.AddParameter(ApiTickCountParameterName, Environment.TickCount.ToString(), ParameterType.UrlSegment);
            if (!string.IsNullOrWhiteSpace(apiMethodName))
            {
                request.AddHeader(ApiMethodNameHeaderName, apiMethodName);
            }

            // trace requests and responses
            if (Tracer != null)
            {
                request.OnBeforeRequest = http => Trace(http, request);
                request.OnBeforeDeserialization = resp => Trace(resp);
            }
        }

        private void ThrowOnFailure(IRestResponse response)
        {
            if (!response.IsSuccessful)
            {
                // try to find the non-empty error message
                var errorMessage = response.ErrorMessage;
                var contentMessage = response.Content;
                var errorResponse = default(ErrorResponse);
                if (response.ContentType != null)
                {
                    // Text/plain;charset=UTF-8 => text/plain
                    var contentType = response.ContentType.ToLower().Trim();
                    var semicolonIndex = contentType.IndexOf(';');
                    if (semicolonIndex >= 0)
                    {
                        contentType = contentType.Substring(0, semicolonIndex).Trim();
                    }

                    // Try to deserialize error response DTO
                    if (Serializer.SupportedContentTypes.Contains(contentType))
                    {
                        errorResponse = Serializer.Deserialize<ErrorResponse>(response);
                        contentMessage = string.Join(". ", new[]
                        {
                            errorResponse.ErrorMessage,
                            //errorResponse.Message,
                            //errorResponse.Description,
                        }
                        .Distinct()
                        .Where(m => !string.IsNullOrWhiteSpace(m)));
                    }
                    else if (response.ContentType.ToLower().Contains("html"))
                    {
                        // Try to parse HTML
                        contentMessage = HtmlHelper.ExtractText(response.Content);
                    }
                    else
                    {
                        // Return as is assuming text/plain content
                        contentMessage = response.Content;
                    }
                }

                // HTML->XML deserialization errors are meaningless
                if (response.ErrorException is XmlException && errorMessage == response.ErrorException.Message)
                {
                    errorMessage = contentMessage;
                }

                // empty error message is meaningless
                if (string.IsNullOrWhiteSpace(errorMessage))
                {
                    errorMessage = contentMessage;
                }

                // finally, throw it
                throw new TrueApiException(response.StatusCode, errorMessage, errorResponse, response.ErrorException);
            }
        }

        /// <summary>
        /// Executes the given request and checks the result.
        /// </summary>
        /// <typeparam name="T">Response type.</typeparam>
        /// <param name="request">The request to execute.</param>
        /// <param name="apiMethodName">Strong-typed REST API method name, for tracing.</param>
        internal T Execute<T>(IRestRequest request, string apiMethodName)
        {
            PrepareRequest(request, apiMethodName);
            var response = Client.Execute<T>(request);
            ThrowOnFailure(response);
            return response.Data;
        }

        /// <summary>
        /// Executes the given request and checks the result.
        /// </summary>
        /// <param name="request">The request to execute.</param>
        /// <param name="apiMethodName">Strong-typed REST API method name, for tracing.</param>
        internal void Execute(IRestRequest request, string apiMethodName)
        {
            PrepareRequest(request, apiMethodName);
            var response = Client.Execute(request);

            // there is no body deserialization step, so we need to trace
            Trace(response);
            ThrowOnFailure(response);
        }

        /// <summary>
        /// Executes the given request and checks the result.
        /// </summary>
        /// <param name="request">The request to execute.</param>
        /// <param name="apiMethodName">Strong-typed REST API method name, for tracing.</param>
        internal string ExecuteString(IRestRequest request, string apiMethodName)
        {
            PrepareRequest(request, apiMethodName);
            var response = Client.Execute(request);

            // there is no body deserialization step, so we need to trace
            Trace(response);
            ThrowOnFailure(response);
            return response.Content;
        }

        /// <summary>
        /// Performs GET request.
        /// </summary>
        /// <typeparam name="T">Response type.</typeparam>
        /// <param name="url">Resource url.</param>
        /// <param name="parameters">IRestRequest parameters.</param>
        /// <param name="apiMethodName">Strong-typed REST API method name, for tracing.</param>
        public T Get<T>(string url, Parameter[] parameters = null, [CallerMemberName] string apiMethodName = null)
        {
            var request = new RestRequest(url, Method.GET, DataFormat.Json);
            if (!parameters.IsNullOrEmpty())
            {
                request.AddOrUpdateParameters(parameters);
            }

            return Execute<T>(request, apiMethodName);
        }

        /// <summary>
        /// Performs GET request and returns a string.
        /// </summary>
        /// <param name="url">Resource url.</param>
        /// <param name="parameters">IRestRequest parameters.</param>
        /// <param name="apiMethodName">Strong-typed REST API method name, for tracing.</param>
        public string Get(string url, Parameter[] parameters = null, [CallerMemberName] string apiMethodName = null)
        {
            var request = new RestRequest(url, Method.GET, DataFormat.Json);
            if (!parameters.IsNullOrEmpty())
            {
                request.AddOrUpdateParameters(parameters);
            }

            return ExecuteString(request, apiMethodName);
        }

        /// <summary>
        /// Performs POST request.
        /// </summary>
        /// <typeparam name="T">Response type.</typeparam>
        /// <param name="url">Resource url.</param>
        /// <param name="body">Request body, to be serialized as JSON.</param>
        /// <param name="parameters">IRestRequest parameters.</param>
        /// <param name="apiMethodName">Strong-typed REST API method name, for tracing.</param>
        public T Post<T>(string url, object body, Parameter[] parameters = null, [CallerMemberName] string apiMethodName = null)
        {
            var request = new RestRequest(url, Method.POST, DataFormat.Json);
            request.AddJsonBody(body);
            if (!parameters.IsNullOrEmpty())
            {
                request.AddOrUpdateParameters(parameters);
            }

            return Execute<T>(request, apiMethodName);
        }

        /// <summary>
        /// Performs POST request.
        /// </summary>
        /// <param name="url">Resource url.</param>
        /// <param name="body">Request body, to be serialized as JSON.</param>
        /// <param name="parameters">IRestRequest parameters.</param>
        /// <param name="apiMethodName">Strong-typed REST API method name, for tracing.</param>
        public void Post(string url, object body, Parameter[] parameters = null, [CallerMemberName] string apiMethodName = null)
        {
            var request = new RestRequest(url, Method.POST, DataFormat.Json);
            request.AddJsonBody(body);
            if (!parameters.IsNullOrEmpty())
            {
                request.AddOrUpdateParameters(parameters);
            }

            Execute(request, apiMethodName);
        }

        /// <summary>
        /// Performs PUT request.
        /// </summary>
        /// <param name="url">Resource url.</param>
        /// <param name="body">Request body, to be serialized as JSON.</param>
        /// <param name="parameters">IRestRequest parameters.</param>
        /// <param name="apiMethodName">Strong-typed REST API method name, for tracing.</param>
        public void Put(string url, object body, Parameter[] parameters = null, [CallerMemberName] string apiMethodName = null)
        {
            var request = new RestRequest(url, Method.PUT, DataFormat.Json);
            request.AddJsonBody(body);
            if (!parameters.IsNullOrEmpty())
            {
                request.AddOrUpdateParameters(parameters);
            }

            Execute(request, apiMethodName);
        }

        /// <summary>
        /// Performs PUT request.
        /// </summary>
        /// <param name="url">Resource url.</param>
        /// <param name="body">Request body, serialized as string.</param>
        /// <param name="apiMethodName">Strong-typed REST API method name, for tracing.</param>
        public void Put(string url, string body, [CallerMemberName] string apiMethodName = null)
        {
            var request = new RestRequest(url, Method.PUT, DataFormat.None);
            request.AddParameter(string.Empty, body, ParameterType.RequestBody);
            Execute(request, apiMethodName);
        }

        /// <summary>
        /// Performs DELETE request.
        /// </summary>
        /// <param name="url">Resource url.</param>
        /// <param name="body">Request body, serialized as string.</param>
        /// <param name="parameters">IRestRequest parameters.</param>
        /// <param name="apiMethodName">Strong-typed REST API method name, for tracing.</param>
        public void Delete(string url, object body, Parameter[] parameters = null, [CallerMemberName] string apiMethodName = null)
        {
            var request = new RestRequest(url, Method.DELETE, DataFormat.Json);
            if (body != null)
            {
                request.AddJsonBody(body);
            }

            if (!parameters.IsNullOrEmpty())
            {
                request.AddOrUpdateParameters(parameters);
            }

            Execute(request, apiMethodName);
        }
    }
}
