namespace FairMark.TrueApi.DataContracts._3_1
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Ответ на заявку на регистрацию УОТ.
    /// 3.1.1. Метод создания заявки на регистрацию УОТ
    /// </summary>
    [DataContract(Name="registration_response")]
    internal class RegistrationResponse
    {
        [DataMember(Name = "registrationRequestDocId")]
        public string RegistrationRequestDocID { get; set; }
    }
}
