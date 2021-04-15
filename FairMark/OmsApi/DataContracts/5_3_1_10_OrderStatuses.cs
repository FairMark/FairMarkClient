using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 5.3.1.10. Справочник «Статус заказа» (orderStatus)
    /// </summary>
    public enum OrderStatuses
    {
        /// <summary>
        /// Заказ создан.
        /// </summary>
        [EnumMember(Value = @"CREATED")]
        CREATED = 0,

        /// <summary>
        /// Заказ ожидает подтверждения ГИС МТ.
        /// </summary>
        [EnumMember(Value = @"PENDING")]
        PENDING = 1,

        /// <summary>
        /// Заказ не подтверждён в ГИС МТ.
        /// </summary>
        [EnumMember(Value = @"DECLINED")]
        DECLINED = 2,

        /// <summary>
        /// Заказ подтверждён в ГИС МТ.
        /// </summary>
        [EnumMember(Value = @"APPROVED")]
        APPROVED = 3,

        /// <summary>
        /// Заказ готов.
        /// </summary>
        [EnumMember(Value = @"READY")]
        READY = 4,

        /// <summary>
        /// Заказ закрыт.
        /// </summary>
        [EnumMember(Value = @"CLOSED")]
        CLOSED = 5,

        /// <summary>
        /// Заказ аннулирован (по истечению срока годности не использованных КМ).
        /// </summary>
        [EnumMember(Value = @"EXPIRED")]
        EXPIRED = 6,
    }
}
