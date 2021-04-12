using FairMark.Toolbox;

namespace FairMark.OmsApi
{
    /// <summary>
    /// OMS Cloud API client.
    /// </summary>
    public partial class OmsApiClient : CommonApiClient
    {
        public const string SandboxApiUrl = "https://intuot.crpt.ru:12011/api/v2";
        public const string SandboxAuthUrl = "https://demo.lp.crpt.tech/api/v3";
        public const string ProductionApiUrl = "";
        //public const string ProductionAuthUrl = "";

        // Придумать как сделать отдельные адреса для авторизации в СУЗ
        // Я бы сделал абстрактного клиента с методами Get, Get<>, Post и т.д. Дать каждому клиенту наследие от этого класса
        // Клиентский токен передаётся в хидере запроса

        // Наладить получение токена СУЗ
        // Метод получение данных по заказу
        // postman: SUZ auth/cert/key + SUZ auth/cert

        /// <summary>
        /// Initializes a new instance of the <see cref="OmsApiClient"/> class.
        /// </summary>
        /// <param name="apiUrl">OMS API endpoint.</param>
        /// <param name="authUrl">OMS Auth endpoint.</param>
        /// <param name="credentials">Authentication credentials.</param>
        public OmsApiClient(string apiUrl, string authUrl, Credentials credentials)
            : base(apiUrl, credentials)
        {
            AuthUrl = authUrl.AppendMissing("/");
        }

        /// <summary>
        /// Authentication endpoint.
        /// </summary>
        public string AuthUrl { get; set; }
    }
}
