using System.Runtime.Serialization;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 5.3.1.11. Справочник «Причина выбытия» (dropoutReason)
    /// </summary>
    public enum DropoutReasons
    {
        /// <summary>
        /// Брак.
        /// </summary>
        [EnumMember(Value = @"DEFECT")]
        DEFECT = 0,

        /// <summary>
        /// Истек срок годности.
        /// </summary>
        [EnumMember(Value = @"EXPIRY")]
        EXPIRY = 1,

        /// <summary>
        /// Лабораторные образцы.
        /// </summary>
        [EnumMember(Value = @"QA_SAMPLES")]
        QA_SAMPLES = 2,

        /// <summary>
        /// Отзыв с рынка.
        /// </summary>
        [EnumMember(Value = @"PRODUCT_RECALL")]
        PRODUCT_RECALL = 3,

        /// <summary>
        /// Рекламации.
        /// </summary>
        [EnumMember(Value = @"COMPLAINTS")]
        COMPLAINTS = 4,

        /// <summary>
        /// Тестирование продукта.
        /// </summary>
        [EnumMember(Value = @"PRODUCT_TESTING")]
        PRODUCT_TESTING = 5,

        /// <summary>
        /// Демонстрационные образцы.
        /// </summary>
        [EnumMember(Value = @"DEMO_SAMPLES")]
        DEMO_SAMPLES = 6,

        /// <summary>
        /// Другие причины.
        /// </summary>
        [EnumMember(Value = @"OTHER")]
        OTHER = 7,

        /// <summary>
        /// Утрата товаров.
        /// </summary>
        [EnumMember(Value = @"DAMAGE_LOSS")]
        DAMAGE_LOSS = 8,

        /// <summary>
        /// Уничтожение товаров.
        /// </summary>
        [EnumMember(Value = @"DESTRUCTION")]
        DESTRUCTION = 9,

        /// <summary>
        /// Ликвидация предприятия.
        /// </summary>
        [EnumMember(Value = @"LIQUIDATION")]
        LIQUIDATION = 10,

        /// <summary>
        /// Конфискация товаров.
        /// </summary>
        [EnumMember(Value = @"CONFISCATION")]
        CONFISCATION = 10,
    }
}
