using System.ComponentModel;
using System.Runtime.Serialization;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 5.3.1.5. Справочник «Статус массива КМ» (status)
    /// </summary>
    public enum PoolStatuses
    {
        /// <summary>
        /// Неверный формат запроса.
        /// </summary>
        [Description("Неверный формат запроса")]
        [EnumMember(Value = @"REQUEST_ERROR")]
        REQUEST_ERROR = 0,

        /// <summary>
        /// Массив (пул) КМ был запрошен в РЭ.
        /// </summary>
        [Description("Массив (пул) КМ был запрошен в РЭ")]
        [EnumMember(Value = @"REQUESTED")]
        REQUESTED = 1,

        /// <summary>
        /// В процессе обработки.
        /// </summary>
        [Description("В процессе обработки")]
        [EnumMember(Value = @"IN_PROCESS")]
        IN_PROCESS = 2,

        /// <summary>
        /// Массив (пул) КМ готов к использованию.
        /// </summary>
        [Description("Массив (пул) КМ готов к использованию")]
        [EnumMember(Value = @"READY")]
        READY = 3,

        /// <summary>
        /// Все КМ в массиве были использованы полностью.
        /// </summary>
        [Description("Все КМ в массиве были использованы полностью")]
        [EnumMember(Value = @"CLOSED")]
        CLOSED = 4,

        /// <summary>
        /// Массив КМ был исчерпан и закрыт.
        /// </summary>
        [Description("Массив КМ был исчерпан и закрыт")]
        [EnumMember(Value = @"DELETED")]
        DELETED = 5,

        /// <summary>
        /// Заказ не был выполнен (неверные параметры заказа,
        /// например, заказ содержит неуникальные серийные номера).
        /// </summary>
        [Description("Заказ не был выполнен")]
        [EnumMember(Value = @"REJECTED")]
        REJECTED = 6,
    }
}
