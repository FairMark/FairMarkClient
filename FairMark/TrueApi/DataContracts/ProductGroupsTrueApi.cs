namespace FairMark.TrueApi.DataContracts
{
    using System.Runtime.Serialization;

    [DataContract]
    public enum ProductGroupsTrueApi
    {
        /// <summary>
        ///Предметы одежды, бельё постельное, столовое, туалетное и кухонное
        /// </summary>
        [EnumMember(Value = @"lp")]
        lp = 1,
        /// <summary>
        /// Обувные товары
        /// </summary>
        [EnumMember(Value = @"shoes")]
        shoes = 2,
        /// <summary>
        /// Табачная продукция
        /// </summary>
        [EnumMember(Value = @"tobacco")]
        tobacco = 3,
        /// <summary>
        /// Духи и туалетная вода
        /// </summary>
        [EnumMember(Value = @"perfumery")]
        perfumery = 4,
        /// <summary>
        /// Шины и покрышки пневматические резиновые новые
        /// </summary>
        [EnumMember(Value = @"tires")]
        tires = 5,
        /// <summary>
        /// Фотокамеры (кроме кинокамер), фотовспышки и лампы-вспышки
        /// </summary>
        [EnumMember(Value = @"electronics")]
        electronics = 6,
        /// <summary>
        /// Молочная продукция
        /// </summary>
        [EnumMember(Value = @"milk")]
        milk = 8,
        /// <summary>
        /// Велосипеды и велосипедные рамы
        /// </summary>
        [EnumMember(Value = @"bicycle")]
        bicycle = 9,
        /// <summary>
        /// Кресла-коляски
        /// </summary>
        [EnumMember(Value = @"wheelchairs")]
        wheelchairs = 10,
        /// <summary>
        /// Альтернативная табачная продукция
        /// </summary>
        [EnumMember(Value = @"otp")]
        otp = 12,
        /// <summary>
        /// Упакованная вода
        /// </summary>
        [EnumMember(Value = @"water")]
        water = 13,
        /// <summary>
        /// Товары из натурального меха
        /// </summary>
        [EnumMember(Value = @"furs")]
        furs = 14,
        /// <summary>
        /// Пиво, напитки, изготавливаемые на основе пива, слабоалкогольные напитки
        /// </summary>
        [EnumMember(Value = @"beer")]
        beer = 15,
        /// <summary>
        /// Никотиносодержащая продукция
        /// </summary>
        [EnumMember(Value = @"ncp")]
        ncp = 16,
        /// <summary>
        /// Биологические активные добавки к пище
        /// </summary>
        [EnumMember(Value = @"bio")]
        bio = 17
    }
}
