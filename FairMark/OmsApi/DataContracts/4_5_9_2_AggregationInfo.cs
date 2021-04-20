using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 4.5.9. Метод «Получить информацию об агрегации»
    /// 4.5.9.2. Ответ на запрос, Таблица 63.
    /// </summary>
    [DataContract]
    public class AggregationInfo
    {
        /// <summary>Aggregation unit (Единица агрегации)</summary>
        [DataMember(Name = "aggregationUnit", IsRequired = true)]
        public AggregationUnit AggregationUnit { get; set; } = new AggregationUnit();

        /// <summary>Уникальный идентификатор СУЗ</summary>
        [DataMember(Name = "omsId", IsRequired = true)]
        public string OmsID { get; set; }

        /// <summary>Taxpayer Identification Number (Идентификационный номер налогоплательщика)</summary>
        [DataMember(Name = "participantId", IsRequired = false)]
        public string ParticipantID { get; set; }

        [DataMember(Name = "productsInfo", IsRequired = false)]
        public List<ProductInfo> ProductsInfo { get; set; }
    }
}
