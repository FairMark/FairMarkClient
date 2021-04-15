using System.Runtime.Serialization;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 11.3.4. Справочник «Категории товарных групп» (ProductGroupCrptType)
    /// </summary>
    [DataContract]
    public enum ProductGroups
    {
        /// <summary>
        /// Предметы одежды, белье постельное, столовое, туалетное и кухонное.
        /// </summary>
        [EnumMember(Value = @"lp")]
        lp = 0,

        /// <summary>
        /// Обувные товары.
        /// </summary>
        [EnumMember(Value = @"shoes")]
        shoes = 1,

        /// <summary>
        /// Табачная продукция.
        /// </summary>
        [EnumMember(Value = @"tobacco")]
        tobacco = 2,

        /// <summary>
        /// Духи и туалетная вода.
        /// </summary>
        [EnumMember(Value = @"perfumery")]
        perfumery = 3,

        /// <summary>
        /// Шины и покрышки пневматические резиновые новые.
        /// </summary>
        [EnumMember(Value = @"tires")]
        tires = 4,

        /// <summary>
        /// Фотокамеры (кроме кинокамер), фотовспышки и лампы-вспышки.
        /// </summary>
        [EnumMember(Value = @"electronics")]
        electronics = 5,

        /// <summary>
        /// Лекарственные препараты для медицинского применения.
        /// </summary>
        [EnumMember(Value = @"pharma")]
        pharma = 6,

        /// <summary>
        /// Молочная продукция.
        /// </summary>
        [EnumMember(Value = @"milk")]
        milk = 7,

        /// <summary>
        /// Велосипеды и велосипедные рамы.
        /// </summary>
        [EnumMember(Value = @"bicycle")]
        bicycle = 8,

        /// <summary>
        /// Кресла коляски.
        /// </summary>
        [EnumMember(Value = @"wheelchairs")]
        wheelchairs = 9,

        /// <summary>
        /// Альтернативная табачная продукция.
        /// </summary>
        [EnumMember(Value = @"otp")]
        otp = 10,

        /// <summary>
        /// Питьевая вода.
        /// </summary>
        [EnumMember(Value = @"water")]
        water = 11,

        /// <summary>
        /// Пиво.
        /// </summary>
        [EnumMember(Value = @"beer")]
        beer = 12,

        /// <summary>
        /// Никотиносодержащая продукция.
        /// </summary>
        [EnumMember(Value = @"ncp")]
        ncp = 13,
    }
}
