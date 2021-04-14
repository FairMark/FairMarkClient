using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 5.3.1.5. Справочник «Статус массива КМ» (status)    /// </summary>
    public static class PoolStatuses
    {
        /// <summary>
        /// Неверный формат запроса.
        /// </summary>
        public const string REQUEST_ERROR = nameof(REQUEST_ERROR);

        /// <summary>
        /// Массив (пул) КМ был запрошен в РЭ.
        /// </summary>
        public const string REQUESTED = nameof(REQUESTED);

        /// <summary>
        /// В процессе обработки.
        /// </summary>
        public const string IN_PROCESS = nameof(IN_PROCESS);

        /// <summary>
        /// Массив (пул) КМ готов к использованию.
        /// </summary>
        public const string READY = nameof(READY);

        /// <summary>
        /// Все КМ в массиве были использованы полностью.
        /// </summary>
        public const string CLOSED = nameof(CLOSED);

        /// <summary>
        /// Массив КМ был исчерпан и закрыт.
        /// </summary>
        public const string DELETED = nameof(DELETED);

        /// <summary>
        /// Заказ не был выполнен (неверные параметры заказа,
        /// например, заказ содержит неуникальные серийные номера).        /// </summary>
        public const string REJECTED = nameof(REJECTED);
    }
}
