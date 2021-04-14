namespace FairMark.OmsApi.Dictionaries
{
    /// <summary>
    /// Возможные значения справочника «Способ формирования индивидуального серийного номера» serialNumberType
    /// </summary>
    public static class SerialNumberTypes
    {
        /// <summary>
        /// Самостоятельно
        /// </summary>
        public const string SELF_MADE = nameof(SELF_MADE);

        /// <summary>
        /// Оператором ГИС МТ
        /// </summary>
        public const string OPERATOR = nameof(OPERATOR);
    }
}
