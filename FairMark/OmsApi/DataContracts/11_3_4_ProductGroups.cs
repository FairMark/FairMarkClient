using System.ComponentModel;
using System.Runtime.Serialization;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 11.3.4. Справочник «Категории товарных групп» (ProductGroupCrptType)
    /// </summary>
    [DataContract]
    public enum ProductGroupsOMS
    {
        /// <summary>
        /// Предметы одежды, белье постельное, столовое, туалетное и кухонное.
        /// </summary>
        [Description("Предметы одежды")]
        [EnumMember(Value = @"lp")]
        lp = 0,

        /// <summary>
        /// Обувные товары.
        /// </summary>
        [Description("Обувные товары")]
        [EnumMember(Value = @"shoes")]
        shoes = 1,

        /// <summary>
        /// Табачная продукция.
        /// </summary>
        [Description("Табачная продукция")]
        [EnumMember(Value = @"tobacco")]
        tobacco = 2,

        /// <summary>
        /// Духи и туалетная вода.
        /// </summary>
        [Description("Духи и туалетная вода")]
        [EnumMember(Value = @"perfumery")]
        perfumery = 3,

        /// <summary>
        /// Шины и покрышки пневматические резиновые новые.
        /// </summary>
        [Description("Шины и покрышки")]
        [EnumMember(Value = @"tires")]
        tires = 4,

        /// <summary>
        /// Фотокамеры (кроме кинокамер), фотовспышки и лампы-вспышки.
        /// </summary>
        [Description("Фотокамеры")]
        [EnumMember(Value = @"electronics")]
        electronics = 5,

        /// <summary>
        /// Лекарственные препараты для медицинского применения.
        /// </summary>
        [Description("Лекарственные препараты")]
        [EnumMember(Value = @"pharma")]
        pharma = 6,

        /// <summary>
        /// Молочная продукция.
        /// </summary>
        [Description("Молочная продукция")]
        [EnumMember(Value = @"milk")]
        milk = 7,

        /// <summary>
        /// Велосипеды и велосипедные рамы.
        /// </summary>
        [Description("Велосипеды и велосипедные рамы")]
        [EnumMember(Value = @"bicycle")]
        bicycle = 8,

        /// <summary>
        /// Кресла коляски.
        /// </summary>
        [Description("Кресла коляски")]
        [EnumMember(Value = @"wheelchairs")]
        wheelchairs = 9,

        /// <summary>
        /// Альтернативная табачная продукция.
        /// </summary>
        [Description("Альтернативная табачная продукция")]
        [EnumMember(Value = @"otp")]
        otp = 10,

        /// <summary>
        /// Питьевая вода.
        /// </summary>
        [Description("Питьевая вода")]
        [EnumMember(Value = @"water")]
        water = 11,

        /// <summary>
        /// Пиво.
        /// </summary>
        [Description("Пиво")]
        [EnumMember(Value = @"beer")]
        beer = 12,

        /// <summary>
        /// Никотиносодержащая продукция.
        /// </summary>
        [Description("Никотиносодержащая продукция")]
        [EnumMember(Value = @"ncp")]
        ncp = 13,
    }
}
