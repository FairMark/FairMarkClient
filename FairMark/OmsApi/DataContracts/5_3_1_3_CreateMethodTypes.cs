using System.ComponentModel;
using System.Runtime.Serialization;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 5.3.1.3. Справочник «Способ изготовления» (createMethodType)
    /// </summary>
    public enum CreateMethodTypes
    {
        /// <summary>
        /// Самостоятельно.
        /// </summary>
        [Description("Самостоятельно")]
        [EnumMember(Value = @"SELF_MADE")]
        SELF_MADE = 0,

        /// <summary>
        /// ЦЭМ.
        /// </summary>
        [Description("ЦЭМ")]
        [EnumMember(Value = @"CEM")]
        CEM = 1,

        /// <summary>
        /// Контрактное производство.
        /// </summary>
        [Description("Контрактное производство")]
        [EnumMember(Value = @"CM")]
        CM = 2,

        /// <summary>
        /// Логистический склад.
        /// </summary>
        [Description("Логистический склад")]
        [EnumMember(Value = @"CL")]
        CL = 3,

        /// <summary>
        /// Комиссионная площадка.
        /// </summary>
        [Description("Комиссионная площадка")]
        [EnumMember(Value = @"CA")]
        CA = 4,
    }
}
