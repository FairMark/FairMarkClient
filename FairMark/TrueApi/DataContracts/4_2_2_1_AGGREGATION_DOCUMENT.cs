namespace FairMark.TrueApi.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;


    /// <summary>
    /// Заявка на регистрацию УОТ.
    /// 3.1.1. Метод создания заявки на регистрацию УОТ
    /// </summary>
    [DataContract(Name = "registration")]
    public class DocumentBase
    {
        public const string DocumentFormatXml = "XML";
        public const string DocumentFormatManual = "MANUAL";
        public const string DocumentFormatJson = DocumentFormatManual;

        [DataMember(Name = "document_format")]
        public string DocumentFormat { get; set; }

        /// <summary>
        /// Base64-encoded instance of the <see cref="Document"/> class.
        /// </summary>
        [DataMember(Name = "product_document")]
        public string Document { get; set; }

        /// <summary>
        /// Detached signature of the original <see cref="Document"/> instance.
        /// </summary>
        [DataMember(Name = "signature")]
        public string Signature { get; set; }

        /// <summary>
        /// Код типа документа
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }



    /// <summary>
    /// 4.2.2.1. Агрегация
    /// </summary>
    [DataContract(Name = "AggregationDocument")]
    public class AggregationDocument //: DocumentBase
    {
        public string DocumentName = "AggregationDocument";
        /// <summary>
        /// ИНН участника оборота товаров
        /// </summary>
        [DataMember(Name = "participantId")]
        public string ParticipantId { get; set; }

        /// <summary>
        /// Список формируемых агрегатов
        /// </summary>
        [DataMember(Name = "aggregationUnits")]
        public List<AGGREGATION_UNIT> AggregationUnits { get; set; }
    }

    [DataContract]
    public class AGGREGATION_UNIT
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
