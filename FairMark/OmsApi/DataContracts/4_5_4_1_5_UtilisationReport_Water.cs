using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 4.5.4.1 Метод «Отправить отчёт об использовании (нанесении) КМ»
    /// 4.5.4.1.5 Расширения для производителей упакованной воды, Таблица 49.
    /// </summary>
    [DataContract]
    public partial class UtilisationReport_Water : UtilisationReport
    {
        /// <summary>The indication of use of ICs in production (Признак использовании КМ на производстве)</summary>
        [DataMember(Name = "usedInProduction", IsRequired = false)]
        public int? UsedInProduction { get; set; }
    }
}
