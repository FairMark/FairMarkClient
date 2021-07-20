namespace FairMark.TrueApi.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// 4.2.1.3. Расформирование агрегата
    /// </summary>
    [DataContract]
    public class DisaggregationDocument : IUniformDocumentBase
    {
        public string DocumentApiName { get; } = "DISAGGREGATION_DOCUMENT";
        public ProductGroupsTrueApi ProductGroup { get; set; } = ProductGroupsTrueApi.milk;

        /// <summary>
        /// ИНН участника оборота товаров
        /// </summary>
        [DataMember(Name = "participant_inn")]
        public string ParticipantInn { get; set; }

        /// <summary>
        /// Список расформируемых агрегатов
        /// </summary>
        [DataMember(Name = "products_list")]
        public List<DisaggregationUnit> DisaggregationUnits { get; set; }
    }
}
