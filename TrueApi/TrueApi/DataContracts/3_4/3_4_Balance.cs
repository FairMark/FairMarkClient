namespace FairMark.TrueApi.DataContracts._3_4
{
    using System.Runtime.Serialization;

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
