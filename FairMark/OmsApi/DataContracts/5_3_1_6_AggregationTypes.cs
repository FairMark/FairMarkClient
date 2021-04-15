using System.Runtime.Serialization;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 5.3.1.6. Справочник «Тип агрегации» (aggregationType)
    /// </summary>
    public enum AggregationTypes
    {
        /// <summary>
        /// Новая агрегация.
        /// </summary>
        [EnumMember(Value = @"AGGREGATION")]
        AGGREGATION = 0,

        /// <summary>
        /// Обновление существующей агрегации.
        /// </summary>
        /// <remarks>
        /// Примечание: выбор данного значения означает
        /// переупаковку (к указанному коду агрегата будут
        /// относиться только переданные в рамках текущего
        /// запроса коды маркировки).
        /// Значение UPDATE считается уставревшим (не
        /// рекомендуется использовать и не исключается для
        /// совместимости старых версий), для обновления
        /// существующей агрегации, рекомендуется
        /// использовать значение AGGREGATION.
        /// </remarks>
        [EnumMember(Value = @"UPDATE")]
        UPDATE = 1,
    }
}
