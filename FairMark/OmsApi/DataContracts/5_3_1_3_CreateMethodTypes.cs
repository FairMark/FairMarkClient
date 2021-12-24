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
        SELF_MADE = 0,

        /// <summary>
        /// ЦЭМ.
        /// </summary>
        [Description("ЦЭМ")]
        CEM = 1,

        /// <summary>
        /// Контрактное производство.
        /// </summary>
        [Description("Контрактное производство")]
        CM = 2,

        /// <summary>
        /// Логистический склад.
        /// </summary>
        [Description("Логистический склад")]
        CL = 3,

        /// <summary>
        /// Комиссионная площадка.
        /// </summary>
        [Description("Комиссионная площадка")]
        CA = 4,
    }
}
