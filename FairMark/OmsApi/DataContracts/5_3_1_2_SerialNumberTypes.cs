using System.Runtime.Serialization;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 5.3.1.2. Справочник «Способ формирования индивидуального серийного номера» (serialNumberType)
    /// </summary>
    public enum SerialNumberTypes
    {
        /// <summary>
        /// Самостоятельно.
        /// </summary>
        [EnumMember(Value = @"SELF_MADE")]
        SELF_MADE = 0,

        /// <summary>
        /// Оператором ГИС МТ.
        /// </summary>
        [EnumMember(Value = @"OPERATOR")]
        OPERATOR = 1,
    }
}
