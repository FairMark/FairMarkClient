using FairMark.OmsApi.DataContracts;
using FairMark.Toolbox;

namespace FairMark.OmsApi
{
    /// <summary>
    /// OMS Cloud API client.
    /// </summary>
    /// <remarks>
    /// Документация по API СУЗ Облако:
    /// https://честныйзнак.рф/upload/iblock/07f/ru_API_OMS-CLOUD.pdf
    /// </remarks>
    public partial class OmsApiClient : CommonApiClient
    {
        /// <summary>
        /// Sandbox OMS API URL.
        /// </summary>
        public const string SandboxApiUrl = "https://intuot.crpt.ru:12011/api/v2";

        /// <summary>
        /// Sandbox OMS API Authentication URL.
        /// </summary>
        public const string SandboxAuthUrl = "https://demo.lp.crpt.tech/api/v3";

        /// <summary>
        /// TODO: verify: Production OMS API URL.
        /// </summary>
        public const string ProductionApiUrl = "https://suzgrid.crpt.ru/api/v2";

        /// <summary>
        /// TODO: verify: Production OMS API Authentication URL.
        /// </summary>
        public const string ProductionAuthUrl = "https://ismp.crpt.ru/api/v3";

        /// <summary>
        /// Initializes a new instance of the <see cref="OmsApiClient"/> class.
        /// </summary>
        /// <param name="apiUrl">OMS API endpoint.</param>
        /// <param name="authUrl">OMS Auth endpoint.</param>
        /// <param name="productGroup">Product group, such as milk, tobacco, etc.</param>
        /// <param name="credentials">Authentication credentials.</param>
        public OmsApiClient(string apiUrl, string authUrl, ProductGroups productGroup, OmsCredentials credentials)
            : base(apiUrl, credentials)
        {
            AuthUrl = authUrl.AppendMissing("/");
            Extension = productGroup;
        }

        /// <summary>
        /// Authentication endpoint.
        /// </summary>
        public string AuthUrl { get; set; }

        /// <summary>
        /// Product group, or extension type, such as milk, tobacco, etc.
        /// </summary>
        public ProductGroups Extension { get; set; }

        /// <summary>
        /// OMS-specific credentials.
        /// </summary>
        public OmsCredentials OmsCredentials => (OmsCredentials)Credentials;
    }
}
