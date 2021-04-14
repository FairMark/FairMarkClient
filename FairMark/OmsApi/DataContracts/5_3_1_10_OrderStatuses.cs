using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 5.3.1.10. Справочник «Статус заказа» (orderStatus)    /// </summary>
    public static class OrderStatuses
    {
        /// <summary>
        /// Заказ создан.
        /// </summary>
        public const string CREATED = nameof(CREATED);

        /// <summary>
        /// Заказ ожидает подтверждения ГИС МТ.
        /// </summary>
        public const string PENDING = nameof(PENDING);

        /// <summary>
        /// Заказ не подтверждён в ГИС МТ.
        /// </summary>
        public const string DECLINED = nameof(DECLINED);

        /// <summary>
        /// Заказ подтверждён в ГИС МТ.
        /// </summary>
        public const string APPROVED = nameof(APPROVED);

        /// <summary>
        /// Заказ готов.
        /// </summary>
        public const string READY = nameof(READY);

        /// <summary>
        /// Заказ закрыт.
        /// </summary>
        public const string CLOSED = nameof(CLOSED);

        /// <summary>
        /// Заказ аннулирован (по истечению срока годности не использованных КМ).
        /// </summary>
        public const string EXPIRED = nameof(EXPIRED);
    }
}
