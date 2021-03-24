using System.Runtime.Serialization;

namespace FairMark.TrueApi.DataContracts
{
    /// <summary>
    /// Пользователь с усиленной электронной подписью.
    /// 3.1.1. Метод создания заявки на регистрацию УОТ
    /// </summary>
    [DataContract(Name = "user")]
    public class User
    {
        [DataMember(Name = "name")]
        public string FirstName { get; set; }

        [DataMember(Name = "last_name")]
        public string LastName { get; set; }

        [DataMember(Name = "finger_print")]
        public string Fingerprint { get; set; }
    }
}