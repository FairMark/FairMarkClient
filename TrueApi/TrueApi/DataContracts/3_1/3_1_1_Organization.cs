namespace FairMark.TrueApi.DataContracts._3_1
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Организация.
    /// 3.1.1. Метод создания заявки на регистрацию УОТ
    /// </summary>
    [DataContract(Name = "organisation")]
    public class Organization
    {
        [DataMember(Name = "inn")]
        public string Inn { get; set; }

        [DataMember(Name = "ogrn")]
        public string Ogrn { get; set; }

        [DataMember(Name = "organisation_name")]
        public string OrganizationName { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "ifns")]
        public string Ifns { get; set; }

        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        [DataMember(Name = "kpp")]
        public string Kpp { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }
    }
}
