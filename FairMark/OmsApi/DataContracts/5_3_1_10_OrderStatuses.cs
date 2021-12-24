using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Description("Заказ создан")]
        [EnumMember(Value = @"CREATED")]
        CREATED = 0,

        /// <summary>
        /// Заказ ожидает подтверждения ГИС МТ.
        /// </summary>
        [Description("Заказ ожидает подтверждения ГИС МТ")]
        [EnumMember(Value = @"PENDING")]
        PENDING = 1,

        /// <summary>
        /// Заказ не подтверждён в ГИС МТ.
        /// </summary>
        [Description("Заказ не подтверждён в ГИС МТ")]
        [EnumMember(Value = @"DECLINED")]
        DECLINED = 2,

        /// <summary>
        /// Заказ подтверждён в ГИС МТ.
        /// </summary>
        [Description("Заказ подтверждён в ГИС МТ")]
        [EnumMember(Value = @"APPROVED")]
        APPROVED = 3,

        /// <summary>
        /// Заказ готов.
        /// </summary>
        [Description("Заказ готов")]
        [EnumMember(Value = @"READY")]
        READY = 4,

        /// <summary>
        /// Заказ закрыт.
        /// </summary>
        [Description("Заказ закрыт")]
        [EnumMember(Value = @"CLOSED")]
        CLOSED = 5,

        /// <summary>
        /// Заказ аннулирован (по истечению срока годности не использованных КМ).
        /// </summary>
        [Description("Заказ аннулирован")]
        [EnumMember(Value = @"EXPIRED")]
        EXPIRED = 6,
    }
}
