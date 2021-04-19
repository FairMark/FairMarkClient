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
    /// 4.5.4.1.1 Расширения для табачной промышленности, Таблица 44.
    /// </summary>
    [DataContract]
    public partial class UtilisationReport_Tobacco : UtilisationReport
    {
        /// <summary>Product Brand Name (Наименование бренда продукции)</summary>
        [DataMember(Name = "brandcode", IsRequired = false)]
        public string Brandcode { get; set; }

        /// <summary>Production date (Дата производства. Дата указывается с учетом часового пояса. Обозначение даты в соответствии с ГОСТ ИСО 8601–2001)</summary>
        /// <remarks>Формат даты: yyyy-MMddTHH:mm:ss.SSSZ</remarks>
        [DataMember(Name = "productionDate", IsRequired = false)]
        public string ProductionDate { get; set; }

        /// <summary>Production line number (Номер производственной линии)</summary>
        [DataMember(Name = "productionLineId", IsRequired = true)]
        public string ProductionLineID { get; set; }

        /// <summary>The Id of the production order (Идентификатор производственного заказа)</summary>
        [DataMember(Name = "productionOrderId", IsRequired = false)]
        public string ProductionOrderID { get; set; }

        /// <summary>Utilisation report identifier of APCS (Идентификатор отчёта о нанесении АСУТП)</summary>
        [DataMember(Name = "sourceReportId", IsRequired = false)]
        public string SourceReportID { get; set; }
    }
}
