using System.Runtime.Serialization;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 5.3.1.9. Справочник «Тип использования» (usageType)
    /// </summary>
    /// <remarks>
    /// Примечание*: значения справочника «USED_FOR_PRODUCTION»,
	/// «SENT_TO_PRINTER» и «PRINTER_LOST» в настоящее время не используются
	/// (отмечены как устаревшие) и впоследствии будут исключены из справочника
    /// </remarks>
    public enum UsageTypes
    {
        /// <summary>
        /// КМ был передан на производственную линию (данное значение не используется)*.
        /// </summary>
        [EnumMember(Value = @"USED_FOR_PRODUCTION")]
        USED_FOR_PRODUCTION = 0,

        /// <summary>
        /// Производственная линия отправила КМ на принтер (данное значение не используется)*.
        /// </summary>
        [EnumMember(Value = @"SENT_TO_PRINTER")]
        SENT_TO_PRINTER = 1,

        /// <summary>
        /// КМ был напечатан.
        /// </summary>
        [EnumMember(Value = @"PRINTED")]
        PRINTED = 2,

        /// <summary>
        /// Подтверждённая потеря КМ принтером (данное значение не используется)*.
        /// </summary>
        [EnumMember(Value = @"PRINTER_LOST")]
        PRINTER_LOST = 3,

        /// <summary>
        /// Нанесение КМ подтверждено.
        /// </summary>
        [EnumMember(Value = @"VERIFIED")]
        VERIFIED = 4,
    }
}
