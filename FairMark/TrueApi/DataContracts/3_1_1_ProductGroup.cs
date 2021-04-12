using System.Runtime.Serialization;

namespace FairMark.TrueApi.DataContracts
{
    /// <summary>
    /// Товарная группа.
    /// 3.1.1. Метод создания заявки на регистрацию УОТ
    /// </summary>
    [DataContract(Name = "product_group")]
    public class ProductGroup
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "types")]
        public string[] Types { get; set; }
    }
}