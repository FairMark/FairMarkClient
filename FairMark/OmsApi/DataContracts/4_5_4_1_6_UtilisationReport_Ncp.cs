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
    /// 4.5.4.1.6 Расширения для никотиносодержащей продукции, Таблица 50.
    /// </summary>
    [DataContract]
    public partial class UtilisationReport_Ncp : UtilisationReport
    {
        /// <summary>Наименование бренда продукции</summary>
        [DataMember(Name = "brandcode", IsRequired = false)]
        public string Brandcode { get; set; }

        /// <summary>Идентификатор производственной линии</summary>
        [DataMember(Name = "productionLineId", IsRequired = true)]
        public string ProductionLineID { get; set; }

        /// <summary>Идентификатор производственного заказа</summary>
        [DataMember(Name = "productionOrderId", IsRequired = false)]
        public string ProductionOrderID { get; set; }

        /// <summary>Идентификатор отчёта о нанесении АСУТП</summary>
        [DataMember(Name = "sourceReportId", IsRequired = false)]
        public string SourceReportID { get; set; }

        /// <summary>Production date (Дата производства. Дата указывается с учетом часового пояса. Обозначение даты в соответствии с ГОСТ ИСО 8601–2001)</summary>
        [DataMember(Name = "productionDate", IsRequired = false)]
        public string ProductionDate { get; set; }
    }
}
