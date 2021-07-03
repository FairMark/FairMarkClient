namespace FairMark.TrueApi.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

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
