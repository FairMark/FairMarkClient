using System.Runtime.Serialization;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 5.3.1.8. Справочник «Статус обработки отчета» (reportStatus)
    /// </summary>
    /// <remarks>
    /// Примечание: Статус «Отчет обработан» PROCESSED используется только для
	/// отчетов об использовании (нанесении) КМ.
    /// </remarks>
    public enum ReportStatuses
    {
        /// <summary>
        /// Отчет получен СУЗ (Устаревший, не используется).
        /// </summary>
        [EnumMember(Value = @"DRAFT")]
        DRAFT = 0,

        /// <summary>
        /// Отчет находится в ожидании.
        /// </summary>
        [EnumMember(Value = @"PENDING")]
        PENDING = 1,

        /// <summary>
        /// Выполняется проверка метаданных отчёта
		/// (применимо к товарной группе «Лекарственные
		/// препараты для медицинского применения»).
        /// </summary>
        [EnumMember(Value = @"CHECK")]
        CHECK = 2,

        /// <summary>
        /// Отчет готов к отправке в РЭ.
        /// </summary>
        [EnumMember(Value = @"READY_TO_SEND")]
        READY_TO_SEND = 3,

        /// <summary>
        /// Отчет отклонен.
        /// </summary>
        [EnumMember(Value = @"REJECTED")]
        REJECTED = 4,

        /// <summary>
        /// Отчет отправлен.
        /// </summary>
        [EnumMember(Value = @"SENT")]
        SENT = 5,

        /// <summary>
        /// Отчет обработан.
        /// </summary>
        [EnumMember(Value = @"PROCESSED")]
        PROCESSED = 6,
    }
}
