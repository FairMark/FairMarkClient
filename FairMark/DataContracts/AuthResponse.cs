namespace FairMark.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Fair Mark API authentication key.
    /// True API 1.5.1. Запрос авторизации при единой аутентификации
    /// OMS API 10.3.2.1. Запрос авторизации при единой аутентификации
    /// Edo Lite API 2.1. Запрос авторизации
    /// </summary>
    [DataContract]
    public class AuthResponse
    {
        [DataMember(Name = "uuid")]
        public string UUID { get; set; }

        [DataMember(Name = "data")]
        public string Data { get; set; }
    }
}
