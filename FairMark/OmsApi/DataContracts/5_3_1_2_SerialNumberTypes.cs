using System.ComponentModel;
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
        [Description("Самостоятельно")]
        [EnumMember(Value = @"SELF_MADE")]
        SELF_MADE = 0,

        /// <summary>
        /// Оператором ГИС МТ.
        /// </summary>
        [Description("Оператором ГИС МТ")]
        [EnumMember(Value = @"OPERATOR")]
        OPERATOR = 1,
    }
}
