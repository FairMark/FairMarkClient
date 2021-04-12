using System.Runtime.Serialization;

namespace FairMark.TrueApi.DataContracts
{
    /// <summary>
    /// Банковские реквизиты.
    /// 3.1.1. Метод создания заявки на регистрацию УОТ
    /// </summary>
    [DataContract(Name="bank_details")]
    public class BankDetails
    {
        [DataMember(Name = "bic")]
        public string Bic { get; set; }

        [DataMember(Name = "account")]
        public string Account { get; set; }

        [DataMember(Name = "sf_required")]
        public bool SfRequired { get; set; }
    }
}
