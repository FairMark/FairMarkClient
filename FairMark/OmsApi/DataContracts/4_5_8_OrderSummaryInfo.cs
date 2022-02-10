using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FairMark.OmsApi.DataContracts
{
    using System;

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
        [DataMember(Name = "orderId", IsRequired = true)]
        public Guid OrderID { get; set; }

        /// <summary>
        /// Статус заказа. Справочное значение «Статус заказа»
        /// см. раздел 5.3.1.10: <see cref="OrderStatuses"/>.
        /// </summary>
        [DataMember(Name = "orderStatus", IsRequired = true)]
        public OrderStatuses OrderStatus { get; set; }

        /// <summary>
        /// Массив информации о статусе буферов.
        /// </summary>
        [DataMember(Name = "buffers", IsRequired = true)]
        public List<BufferInfo> Buffers { get; set; } = new List<BufferInfo>();

        /// <summary>
        /// Время создания заказа.
        /// </summary>
        [DataMember(Name = "createdTimestamp", IsRequired = true)]
        public long CreatedTimestamp { get; set; }

        /// <summary>
        /// Причина отклонения заказа.
        /// </summary>
        [DataMember(Name = "declineReason", IsRequired = false)]
        public string DeclineReason { get; set; }

        /// <summary>
        /// Идентификатор производственного заказа.
        /// </summary>
        [DataMember(Name = "productionOrderId", IsRequired = false)]
        public string ProductionOrderId { get; set; }
    }
}
