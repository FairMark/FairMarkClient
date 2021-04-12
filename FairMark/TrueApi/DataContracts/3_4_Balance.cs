using System.Runtime.Serialization;

namespace FairMark.TrueApi.DataContracts
{
    [DataContract]
    public class ProductGroupBalance
    {
        [DataMember(Name = "balance")]
        public long? Balance { get; set; }

        [DataMember(Name = "contractId")]
        public long? ContractId { get; set; }

        [DataMember(Name = "organisationId")]
        public long OrganisationId { get; set; }

        [DataMember(Name = "productGroupId")]
        public long ProductGroupID { get; set; }
    }
}
