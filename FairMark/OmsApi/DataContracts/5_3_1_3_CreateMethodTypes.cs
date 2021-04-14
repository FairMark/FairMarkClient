namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// Список возможных значений справочника «Способ изготовления» createMethodType
    /// </summary>
    public static class CreateMethodTypes
    {
        /// <summary>
        /// Самостоятельно
        /// </summary>
        public const string SELF_MADE = nameof(SELF_MADE);

        /// <summary>
        /// ЦЭМ
        /// </summary>
        public const string CEM = nameof(CEM);

        /// <summary>
        /// Контрактное производство
        /// </summary>
        public const string CM = nameof(CM);

        /// <summary>
        /// Логистический склад
        /// </summary>
        public const string CL = nameof(CL);

        /// <summary>
        /// Комиссионная площадка
        /// </summary>
        public const string CA = nameof(CA);
    }
}
