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
    /// 4.5.9.2. Ответ на запрос, Таблица 38.
    /// </summary>
    [DataContract]
    public class AggregationUnit
    {
        /// <summary>Number of goods actually aggregated in the unit (Фактически упаковано)</summary>
        [DataMember(Name = "aggregatedItemsCount", IsRequired = true)]
        public int AggregatedItemsCount { get; set; }

        /// <summary>Aggregation operation type (Тип агрегации)</summary>
        [DataMember(Name = "aggregationType", IsRequired = true)]
        public AggregationTypes AggregationType { get; set; }

        /// <summary>Aggregation Unit Capacity (Емкость упаковки)</summary>
        [DataMember(Name = "aggregationUnitCapacity", IsRequired = true)]
        public int AggregationUnitCapacity { get; set; }

        /// <summary>List of the Aggregated Identification Codes (Список агрегированных КМ)</summary>
        [DataMember(Name = "sntins", IsRequired = true)]
        public List<string> Sntins { get; set; } = new List<string>();

        /// <summary>Identification Code of Aggregation Unit (КМ агрегата)</summary>
        [DataMember(Name = "unitSerialNumber", IsRequired = true)]
        public string UnitSerialNumber { get; set; }
    }
}
