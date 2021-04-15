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
        [EnumMember(Value = @"REQUEST_ERROR")]
        REQUEST_ERROR = 0,

        /// <summary>
        /// Массив (пул) КМ был запрошен в РЭ.
        /// </summary>
        [EnumMember(Value = @"REQUESTED")]
        REQUESTED = 1,

        /// <summary>
        /// В процессе обработки.
        /// </summary>
        [EnumMember(Value = @"IN_PROCESS")]
        IN_PROCESS = 2,

        /// <summary>
        /// Массив (пул) КМ готов к использованию.
        /// </summary>
        [EnumMember(Value = @"READY")]
        READY = 3,

        /// <summary>
        /// Все КМ в массиве были использованы полностью.
        /// </summary>
        [EnumMember(Value = @"CLOSED")]
        CLOSED = 4,

        /// <summary>
        /// Массив КМ был исчерпан и закрыт.
        /// </summary>
        [EnumMember(Value = @"DELETED")]
        DELETED = 5,

        /// <summary>
        /// Заказ не был выполнен (неверные параметры заказа,
        /// например, заказ содержит неуникальные серийные номера).
        /// </summary>
        [EnumMember(Value = @"REJECTED")]
        REJECTED = 6,
    }
}
