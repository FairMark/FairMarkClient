namespace FairMark.TrueApi.DataContracts
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using RestSharp;
    using Toolbox;

    /// <summary>
    /// 4.2.2.1. Агрегация
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
        public string ParticipantId { get; set; }

        /// <summary>
        /// Список формируемых агрегатов
        /// </summary>
        [DataMember(Name = "aggregationUnits")]
        public List<AggregationUnit> AggregationUnits { get; set; }
    }
}
