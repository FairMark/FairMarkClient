using FairMark.OmsApi.DataContracts;
using FairMark.Toolbox;

namespace FairMark.EdoLite
{
    /// <summary>
    /// EDO Lite API client.
    /// </summary>
    /// <remarks>
    /// Документация по API ЭДО Лайт:
    /// https://честныйзнак.рф/upload/API ЭДО lite.pdf
    /// </remarks>
    public partial class EdoLiteClient : CommonApiClient
    {
        /// <summary>
        /// Sandbox EDO Lite API URL. Интеграционный стенд ЭДО Лайт для ГИС МТ (маркировка промтоваров).
        /// </summary>
        public const string SandboxApiUrl = "https://int.edo.crpt.tech/api/v1";

        /// <summary>
        /// Production EDO Lite for GIS MT API URL. Промышленный стенд ЭДО Лайт для ГИС МТ (маркировка промтоваров).
        /// </summary>
        public const string ProductionApiGisMtUrl = "https://elk.edo.crpt.tech/api/v1";

        /// <summary>
        /// Production EDO Lite for MDLP API URL. Промышленный стенд ЭДО Лайт для МДЛП (маркировка лекарств).
        /// </summary>
        public const string ProductionApiMdlpUrl = "https://mdlp.edo.crpt.tech/api/v1";

        /// <summary>
        /// Initializes a new instance of the <see cref="EdoLiteClient"/> class.
        /// </summary>
        /// <param name="apiUrl">OMS API endpoint.</param>
        /// <param name="credentials">Authentication credentials.</param>
        public EdoLiteClient(string apiUrl, EdoLiteCredentials credentials)
            : base(apiUrl, credentials)
        {
        }

        /// <summary>
        /// EDO Lite-specific credentials.
        /// </summary>
        public EdoLiteCredentials EdoLiteCredentials => (EdoLiteCredentials)Credentials;
    }
}
