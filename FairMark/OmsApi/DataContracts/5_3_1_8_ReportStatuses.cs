using System.ComponentModel;
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
        [Description("Отчет получен СУЗ")]
        [EnumMember(Value = @"DRAFT")]
        DRAFT = 0,

        /// <summary>
        /// Отчет находится в ожидании.
        /// </summary>
        [Description("Отчет находится в ожидании")]
        [EnumMember(Value = @"PENDING")]
        PENDING = 1,

        /// <summary>
        /// Выполняется проверка метаданных отчёта
		/// (применимо к товарной группе «Лекарственные
		/// препараты для медицинского применения»).
        /// </summary>
        [Description("Выполняется проверка метаданных отчёта")]
        [EnumMember(Value = @"CHECK")]
        CHECK = 2,

        /// <summary>
        /// Отчет готов к отправке в РЭ.
        /// </summary>
        [Description("Отчет готов к отправке в РЭ")]
        [EnumMember(Value = @"READY_TO_SEND")]
        READY_TO_SEND = 3,

        /// <summary>
        /// Отчет отклонен.
        /// </summary>
        [Description("Отчет отклонен")]
        [EnumMember(Value = @"REJECTED")]
        REJECTED = 4,

        /// <summary>
        /// Отчет отправлен.
        /// </summary>
        [Description("Отчет отправлен")]
        [EnumMember(Value = @"SENT")]
        SENT = 5,

        /// <summary>
        /// Отчет обработан.
        /// </summary>
        [Description("Отчет обработан")]
        [EnumMember(Value = @"PROCESSED")]
        PROCESSED = 6,
    }
}
