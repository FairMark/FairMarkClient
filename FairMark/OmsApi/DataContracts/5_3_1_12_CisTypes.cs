using System.ComponentModel;
using System.Runtime.Serialization;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 5.3.1.12. Справочник «Типы КМ» (cisType)
    /// </summary>
    public enum CisTypes
    {
        /// <summary>
        /// Единица товара
        /// </summary>
        [Description("Единица товара")]
        [EnumMember(Value = @"UNIT")]
        UNIT = 0,

        /// <summary>
        /// Комплект
        /// </summary>
        [Description("Комплект")]
        [EnumMember(Value = @"BUNDLE")]
        BUNDLE = 1,

        /// <summary>
        /// Групповая потребительская упаковка
        /// </summary>
        [Description("Групповая потребительская упаковка")]
        [EnumMember(Value = @"GROUP")]
        GROUP = 2,

        /// <summary>
        /// Набор
        /// </summary>
        [Description("Набор")]
        [EnumMember(Value = @"SET")]
        SET = 3,
    }
}
