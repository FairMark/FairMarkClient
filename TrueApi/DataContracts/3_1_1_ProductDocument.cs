using System.Runtime.Serialization;

namespace FairMark.TrueApi.DataContracts
{
    /// <summary>
    /// Заявка на регистрацию.
    /// 3.1.1. Метод создания заявки на регистрацию УОТ    /// </summary>
    [DataContract(Name = "product_document")]
    public class ProductDocument
    {
        [DataMember(Name = "organisation")]
        public Organization Organization { get; set; }

        [DataMember(Name = "bank_details")]
        public BankDetails BankDetails { get; set; }

        [DataMember(Name = "product_group")]
        public ProductGroup[] ProductGroups { get; set; }

        [DataMember(Name = "user")]
        public User User { get; set; }

        [DataMember(Name = "edo_operators")]
        public EdoOperator[] EdoOperators;
    }
}
