namespace FairMark.TrueApi.DataContracts._1_5
{
    using System.Runtime.Serialization;

    /// <summary>
    /// True API authentication key.
    /// 1.5.1. Запрос авторизации при единой аутентификации
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
