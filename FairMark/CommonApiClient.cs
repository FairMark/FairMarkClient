using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using RestSharp;
using RestSharp.Serialization;
using FairMark.Toolbox;
using FairMark.DataContracts;

namespace FairMark
{
    /// <summary>
    /// Common FairMark client used as a base class for True API, OMS API client, etc.
    /// </summary>
    public abstract partial class CommonApiClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommonApiClient"/> class.
        /// </summary>
        /// <param name="baseUrl">Base API URL, see <see cref="SandboxApiHttps"/>.</param>
        /// <param name="credentials">Credentials.</param>
        public CommonApiClient(string baseUrl, CommonCredentials credentials)
            : this(new RestClient(baseUrl), credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonApiClient"/> class.
        /// </summary>
        /// <param name="client">REST API client, see <see cref="RestSharp"/>.</param>
        /// <param name="credentials">Credentials.</param>
        public CommonApiClient(IRestClient client, CommonCredentials credentials)
        {
            Credentials = credentials;
            Authenticator = new CredentialsAuthenticator(this, credentials);
            Serializer = new ServiceStackSerializer();
            BaseUrl = client.BaseUrl.ToString();
            //Limiter = new RequestRateLimiter();

            // set up REST client
            Client = client;
            Client.Authenticator = Authenticator;
            Client.Encoding = Encoding.UTF8;
            Client.ThrowOnDeserializationError = false;
            Client.UseSerializer(() => Serializer);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (Authenticator.IsAuthenticated)
            {
                Authenticator.Logout();
            }
        }

        /// <summary>
        /// Gets the client library name and version.
        /// </summary>
        private string ClientLibraryName { get; } =
            $"FairMarkClient, v{typeof(CommonApiClient).Assembly.GetName().Version}";

        /// <summary>
        /// Gets or sets the application name.
        /// </summary>
        public string ApplicationName { get; set; }

        /// <summary>
        /// Gets base API URL.
        /// </summary>
        public string BaseUrl { get; private set; }

        public IRestSerializer Serializer { get; set; }

        /// <summary>
        /// Gets the <see cref="IRestClient"/> instance.
        /// </summary>
        public IRestClient Client { get; private set; }

        internal CommonCredentials Credentials { get; set; }

        internal CredentialsAuthenticator Authenticator { get; set; }

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

        private void AddHeaderIfNotEmpty(IRestRequest request, string headerName, string headerValue)
        {
            if (!string.IsNullOrWhiteSpace(headerValue))
            {
                request.AddHeader(headerName, headerValue);
            }
        }

        private void PrepareRequest(IRestRequest request, string apiMethodName, bool signed)
        {
            // use request parameters to store additional properties, not really used by the requests
            request.AddParameter(ApiTimestampParameterName, DateTime.Now.Ticks, ParameterType.UrlSegment);
            request.AddParameter(ApiTickCountParameterName, Environment.TickCount.ToString(), ParameterType.UrlSegment);
            AddHeaderIfNotEmpty(request, ApiMethodNameHeaderName, apiMethodName);
            AddHeaderIfNotEmpty(request, ApiClientLibraryHeaderName, ClientLibraryName);
            AddHeaderIfNotEmpty(request, ApiApplicationHeaderName, ApplicationName);

            // sign the request using detached signature
            if (signed)
            {
                SignRequest(request);
            }

            // trace requests and responses
            if (Tracer != null)
            {
                request.OnBeforeRequest += http => Trace(http, request);
                request.OnBeforeDeserialization += resp => Trace(resp);
            }
        }

        protected virtual void SignRequest(IRestRequest request)
        {
            // we can sign the request when it's already prepared
            // because otherwise we don't have the serialized body
            // that's why we have to do it in OnBeforeRequest handler
            request.OnBeforeRequest += (IHttp http) =>
            {
                var data = request.Method == Method.GET ? request.Resource : GetBodyText(request.Body);
                var cert = UserCertificate;
                var signature = GostCryptoHelpers.ComputeDetachedSignature(cert, data);

                // won't be added to headers because the request is already prepared
                // we add parameter just for the tracing:
                request.Parameters.Add(new Parameter("X-Signature", signature, ParameterType.HttpHeader));

                var header = new HttpHeader("X-Signature", signature);
                http.Headers.Add(header);
            };

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
                throw new FairMarkException(response.StatusCode, errorMessage, errorResponse, response.ErrorException);
            }
        }

        /// <summary>
        /// Executes the given request and checks the result.
        /// </summary>
        /// <typeparam name="T">Response type.</typeparam>
        /// <param name="request">The request to execute.</param>
        /// <param name="signed">Sign the request path or body (for POST requests).</param>
        /// <param name="apiMethodName">Strong-typed REST API method name, for tracing.</param>
        internal T Execute<T>(IRestRequest request, bool signed = false, [CallerMemberName] string apiMethodName = null)
        {
            PrepareRequest(request, apiMethodName, signed);
            var response = Client.Execute<T>(request);
            ThrowOnFailure(response);
            return response.Data;
        }

        /// <summary>
        /// Executes the given request and checks the result.
        /// </summary>
        /// <param name="request">The request to execute.</param>
        /// <param name="apiMethodName">Strong-typed REST API method name, for tracing.</param>
        /// <param name="signed">Sign the request path or body automatically.</param>
        internal void Execute(IRestRequest request, string apiMethodName, bool signed)
        {
            PrepareRequest(request, apiMethodName, signed);
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
        /// <param name="signed">Sign the request path or body automatically.</param>
        internal string ExecuteString(IRestRequest request, string apiMethodName, bool signed)
        {
            PrepareRequest(request, apiMethodName, signed);
            var response = Client.Execute(request);

            // there is no body deserialization step, so we need to trace
            Trace(response);
            ThrowOnFailure(response);

            // try to handle windows-1251 encoding
            if (response.ContentType.IndexOf("xml", StringComparison.OrdinalIgnoreCase) >= 0 ||
                response.ContentType.IndexOf("octet", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var responseContent = response.Content;
                if (responseContent.StartsWith("<?xml", StringComparison.OrdinalIgnoreCase) &&
                    responseContent.IndexOf("encoding=\"windows-1251\"", 0, 200, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    var encoding = Encoding.GetEncoding(1251);
                    response.Content = encoding.GetString(response.RawBytes);
                }
            }

            return response.Content;
        }

        /// <summary>
        /// Performs GET request.
        /// </summary>
        /// <typeparam name="T">Response type.</typeparam>
        /// <param name="url">Resource url.</param>
        /// <param name="parameters">IRestRequest parameters.</param>
        /// <param name="signed">Sign the request path automatically.</param>
        /// <param name="apiMethodName">Strong-typed REST API method name, for tracing.</param>
        public T Get<T>(string url, Parameter[] parameters = null, bool signed = false, [CallerMemberName] string apiMethodName = null)
        {
            var request = new RestRequest(url, Method.GET, DataFormat.Json);
            if (!parameters.IsNullOrEmpty())
            {
                request.AddOrUpdateParameters(parameters);
            }

            return Execute<T>(request, signed, apiMethodName);
        }

        /// <summary>
        /// Performs GET request and returns a string.
        /// </summary>
        /// <param name="url">Resource url.</param>
        /// <param name="parameters">IRestRequest parameters.</param>
        /// <param name="apiMethodName">Strong-typed REST API method name, for tracing.</param>
        /// <param name="signed">Sign the request path automatically.</param>
        public string Get(string url, Parameter[] parameters = null, bool signed = false, [CallerMemberName] string apiMethodName = null)
        {
            var request = new RestRequest(url, Method.GET, DataFormat.Json);
            if (!parameters.IsNullOrEmpty())
            {
                request.AddOrUpdateParameters(parameters);
            }

            return ExecuteString(request, apiMethodName, signed);
        }

        /// <summary>
        /// Performs POST request.
        /// </summary>
        /// <typeparam name="T">Response type.</typeparam>
        /// <param name="url">Resource url.</param>
        /// <param name="body">Request body, to be serialized as JSON.</param>
        /// <param name="parameters">IRestRequest parameters.</param>
        /// <param name="signed">Sign the request body automatically.</param>
        /// <param name="apiMethodName">Strong-typed REST API method name, for tracing.</param>
        public T Post<T>(string url, object body, Parameter[] parameters = null, bool signed = false, [CallerMemberName] string apiMethodName = null)
        {
            var request = new RestRequest(url, Method.POST, DataFormat.Json);
            request.AddJsonBody(body);
            if (!parameters.IsNullOrEmpty())
            {
                request.AddOrUpdateParameters(parameters);
            }

            return Execute<T>(request, signed, apiMethodName);
        }

        /// <summary>
        /// Performs POST request.
        /// </summary>
        /// <param name="url">Resource url.</param>
        /// <param name="body">Request body, to be serialized as JSON.</param>
        /// <param name="parameters">IRestRequest parameters.</param>
        /// <param name="signed">Sign the request body automatically.</param>
        /// <param name="apiMethodName">Strong-typed REST API method name, for tracing.</param>
        public void Post(string url, object body, Parameter[] parameters = null, bool signed = false, [CallerMemberName] string apiMethodName = null)
        {
            var request = new RestRequest(url, Method.POST, DataFormat.Json);
            request.AddJsonBody(body);
            if (!parameters.IsNullOrEmpty())
            {
                request.AddOrUpdateParameters(parameters);
            }

            Execute(request, apiMethodName, signed);
        }

        /// <summary>
        /// Performs PUT request.
        /// </summary>
        /// <param name="url">Resource url.</param>
        /// <param name="body">Request body, to be serialized as JSON.</param>
        /// <param name="parameters">IRestRequest parameters.</param>
        /// <param name="signed">Sign the request body automatically.</param>
        /// <param name="apiMethodName">Strong-typed REST API method name, for tracing.</param>
        public void Put(string url, object body, Parameter[] parameters = null, bool signed = false, [CallerMemberName] string apiMethodName = null)
        {
            var request = new RestRequest(url, Method.PUT, DataFormat.Json);
            request.AddJsonBody(body);
            if (!parameters.IsNullOrEmpty())
            {
                request.AddOrUpdateParameters(parameters);
            }

            Execute(request, apiMethodName, signed);
        }

        /// <summary>
        /// Performs PUT request.
        /// </summary>
        /// <param name="url">Resource url.</param>
        /// <param name="body">Request body, serialized as string.</param>
        /// <param name="signed">Sign the request body automatically.</param>
        /// <param name="apiMethodName">Strong-typed REST API method name, for tracing.</param>
        public void Put(string url, string body, bool signed = false, [CallerMemberName] string apiMethodName = null)
        {
            var request = new RestRequest(url, Method.PUT, DataFormat.None);
            request.AddParameter(string.Empty, body, ParameterType.RequestBody);
            Execute(request, apiMethodName, signed);
        }

        /// <summary>
        /// Performs DELETE request.
        /// </summary>
        /// <param name="url">Resource url.</param>
        /// <param name="body">Request body, serialized as string.</param>
        /// <param name="parameters">IRestRequest parameters.</param>
        /// <param name="signed">Sign the request body automatically.</param>
        /// <param name="apiMethodName">Strong-typed REST API method name, for tracing.</param>
        public void Delete(string url, object body, Parameter[] parameters = null, bool signed = false, [CallerMemberName] string apiMethodName = null)
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

            Execute(request, apiMethodName, signed);
        }
    }
}
