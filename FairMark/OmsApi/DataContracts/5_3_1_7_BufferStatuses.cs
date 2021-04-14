using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 5.3.1.7. Справочник «Статус буфера КМ» (bufferStatus)    /// </summary>
    public static class BufferStatuses
    {
        /// <summary>
        /// Буфер КМ находится в ожидании.
        /// </summary>
        public const string PENDING = nameof(PENDING);

        /// <summary>
        /// Буфер создан.
        /// </summary>
        public const string ACTIVE = nameof(ACTIVE);

        /// <summary>
        /// Буфер и пулы РЭ не содержат больше кодов.
        /// </summary>
        public const string EXHAUSTED = nameof(EXHAUSTED);

        /// <summary>
        /// Буфер более не доступен для работы.
        /// </summary>
        public const string REJECTED = nameof(REJECTED);

        /// <summary>
        /// Буфер закрыт.
        /// </summary>
        public const string CLOSED = nameof(CLOSED);

        /// <summary>
        /// Буфер аннулирован (по истечению срока годности не использованных КМ).
        /// </summary>
        public const string EXPIRED = nameof(EXPIRED);
    }
}
