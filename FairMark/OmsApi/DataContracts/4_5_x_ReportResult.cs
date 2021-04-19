using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 4.5.2.2. Метод «Отправить отчёт о выбытии/отбраковке КМ», Ответ на запрос Таблица 35.
    /// 4.5.4.2. Метод «Отправить отчёт об использовании (нанесении) КМ», Таблица 51.
    /// </summary>
    [DataContract]
    internal partial class ReportResult
    {
        /// <summary>Уникальный идентификатор СУЗ</summary>
        [DataMember(Name = "omsId", IsRequired = true)]
        public string OmsID { get; set; }

        /// <summary>Unique OMS Report ID (Уникальный идентификатор отчета в СУЗ)</summary>
        [DataMember(Name = "reportId", IsRequired = false)]
        public string ReportID { get; set; }
    }
}
