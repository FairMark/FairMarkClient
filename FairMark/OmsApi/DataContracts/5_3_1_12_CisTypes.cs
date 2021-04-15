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
        [EnumMember(Value = @"UNIT")]
        UNIT = 0,

        /// <summary>
        /// Комплект
        /// </summary>
        [EnumMember(Value = @"BUNDLE")]
        BUNDLE = 1,

        /// <summary>
        /// Групповая потребительская упаковка
        /// </summary>
        [EnumMember(Value = @"GROUP")]
        GROUP = 2,

        /// <summary>
        /// Набор
        /// </summary>
        [EnumMember(Value = @"SET")]
        SET = 3,
    }
}
