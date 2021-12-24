using System.ComponentModel;
using System.Runtime.Serialization;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 5.3.1.7. Справочник «Статус буфера КМ» (bufferStatus)
    /// </summary>
    public enum BufferStatuses
    {
        /// <summary>
        /// Буфер КМ находится в ожидании.
        /// </summary>
        [Description("Буфер КМ находится в ожидании")]
        [EnumMember(Value = @"PENDING")]
        PENDING = 0,

        /// <summary>
        /// Буфер создан.
        /// </summary>
        [Description("Буфер создан")]
        [EnumMember(Value = @"ACTIVE")]
        ACTIVE = 1,

        /// <summary>
        /// Буфер и пулы РЭ не содержат больше кодов.
        /// </summary>
        [Description("Буфер и пулы РЭ не содержат больше кодов")]
        [EnumMember(Value = @"EXHAUSTED")]
        EXHAUSTED = 2,

        /// <summary>
        /// Буфер более не доступен для работы.
        /// </summary>
        [Description("Буфер более не доступен для работы")]
        [EnumMember(Value = @"REJECTED")]
        REJECTED = 3,

        /// <summary>
        /// Буфер закрыт.
        /// </summary>
        [Description("Буфер закрыт")]
        [EnumMember(Value = @"CLOSED")]
        CLOSED = 4,

        /// <summary>
        /// Буфер аннулирован (по истечению срока годности не использованных КМ).
        /// </summary>
        [Description("Буфер аннулирован")]
        [EnumMember(Value = @"EXPIRED")]
        EXPIRED = 5,
    }
}
