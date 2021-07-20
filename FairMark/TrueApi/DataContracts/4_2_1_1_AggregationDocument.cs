namespace FairMark.TrueApi.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// 4.2.1.1. Агрегация
    /// </summary>
    [DataContract]
    public class AggregationDocument : IUniformDocumentBase
    {
        public string DocumentApiName { get; } = "AGGREGATION_DOCUMENT";
        public ProductGroupsTrueApi ProductGroup { get; set; } = ProductGroupsTrueApi.milk;

        /// <summary>
        /// ИНН участника оборота товаров
        /// </summary>
        [DataMember(Name = "participantId")]
        public string ParticipantInn { get; set; }

        /// <summary>
        /// Список формируемых агрегатов
        /// </summary>
        [DataMember(Name = "aggregationUnits")]
        public List<AggregationUnit> AggregationUnits { get; set; }
    }
}
