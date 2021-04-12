namespace FairMark.TrueApi.DataContracts._3_1
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Сообщение об ошибке регистрации.
    /// 3.1.2. Метод проверки статуса заявки УОТ на регистрацию по ID заявки
    /// </summary>
    [DataContract]
    public class RegistrationStatusError
    {
        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "internalError")]
        public string InternalError { get; set; }
    }
}
