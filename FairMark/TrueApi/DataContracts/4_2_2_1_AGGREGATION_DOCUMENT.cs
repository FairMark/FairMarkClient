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

    [DataContract]
    public class AggregationUnit
    {
        /// <summary>
        /// Код идентификации агрегата
        /// Примечание: КИ может содержать от 18 до 74 символов включительно: цифры, буквы латинского алфавита, спецсимволы(A-Z a-z 0-9 % & ' " ( ) * + , - _ . / : ; < = > ? !)
        /// </summary>
        [DataMember(Name = "unitSerialNumber")]
        public string UnitSerialNumber { get; set; }

        /// <summary>
        /// Код типа агрегации
        /// Примечание: Значение может быть только "AGGREGATION"
        /// </summary>
        [DataMember(Name = "aggregationType")]
        public string AggregationType { get; set; } = "AGGREGATION";

        /// <summary>
        /// Список КИ, входящих в агрегат
        /// Примечание: Статусы КИ, входящих в агрегат, должны быть идентичны
        /// </summary>
        [DataMember(Name = "sntins")]
        public List<string> Sntins { get; set; }
    }

}
