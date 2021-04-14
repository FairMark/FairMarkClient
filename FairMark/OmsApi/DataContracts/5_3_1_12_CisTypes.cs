namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 5.3.1.12. Справочник «Типы КМ» (cisType)
    /// </summary>
    public static class CisTypes
    {
        /// <summary>
        /// Единица товара
        /// </summary>
        public const string UNIT = nameof(UNIT);

        /// <summary>
        /// Комплект
        /// </summary>
        public const string BUNDLE = nameof(UNIT);

        /// <summary>
        /// Групповая потребительская упаковка
        /// </summary>
        public const string GROUP = nameof(UNIT);

        /// <summary>
        /// Набор
        /// </summary>
        public const string SET = nameof(UNIT);
    }
}
