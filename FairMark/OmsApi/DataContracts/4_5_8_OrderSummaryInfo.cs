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
    /// 4.5.8.2. Ответ на запрос, Таблица 61.
    /// </summary>
    [DataContract]
    public class OrderSummaryInfo
    {
        /// <summary>
        /// Идентификатор заказа на эмиссию КМ.
        /// </summary>
        [DataMember(Name = "orderId")]
        public string OrderID { get; set; }

        /// <summary>
        /// Статус заказа. Справочное значение «Статус заказа»
        /// см. раздел 5.3.1.10.
        /// </summary>
        [DataMember(Name = "orderStatus")]
        public string OrderStatus { get; set; }

        // TODO: add the rest
    }
}
