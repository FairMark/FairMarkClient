using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// Current orders and their statuses.
    /// 4.5.8. Метод «Получить статус заказов»
    /// 4.5.8.2. Ответ на запрос, Таблица 60.
    /// </summary>
    [DataContract]
    public class OrderSummaries
    {
        [DataMember(Name = "omsId")]
        public string OmsID { get; set; }

        [DataMember(Name = "orderInfos")]
        public List<OrderSummaryInfo> OrderInfos { get; set; }
    }
}
