namespace FairMark.TrueApi
{
    using RestSharp;

    public partial class TrueApiClient : CommonApiClient
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
        /// Initializes a new instance of the <see cref="TrueApiClient"/>.
        /// </summary>
        /// <param name="baseUrl">Base URL of the True API.</param>
        /// <param name="credentials">Authentication credentials.</param>
        public TrueApiClient(string baseUrl, Credentials credentials)
            : base(baseUrl, credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrueApiClient"/>.
        /// </summary>
        /// <param name="restClient">REST client.</param>
        /// <param name="credentials">Authentication credentials.</param>
        public TrueApiClient(IRestClient restClient, Credentials credentials)
            : base(restClient, credentials)
        {
        }
    }
}
