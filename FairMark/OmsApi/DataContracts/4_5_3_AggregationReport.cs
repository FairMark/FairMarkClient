namespace FairMark.OmsApi.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// 4.5.3. Метод «Отправить отчёт об агрегации КМ»
    /// </summary>
    [DataContract]
    public class AggregationReport
    {
        /// <summary>
        /// Идентификационный номер налогоплательщика
        /// </summary>
        [DataMember(Name = "participantId")]
        public string ParticipantId { get; set; }

        /// <summary>
        /// Массив единиц агрегации
        /// </summary>
        [DataMember(Name = "aggregationUnits")]
        public List<AggregationUnit> AggregationUnits { get; set; }
    }


}
