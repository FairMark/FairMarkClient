using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 4.5.10. Метод «Получить статус обработки отчёта»
    /// 4.5.10.2. Ответ на запрос, Таблица 67.
    /// </summary>
    [DataContract]
    public class ReportStatusDto
    {
        /// <summary>Причина отклонения отчета (обнаруженная ошибка)</summary>
        [DataMember(Name = "errorReason", IsRequired = false)]
        public string ErrorReason { get; set; }

        /// <summary>Уникальный идентификатор СУЗ</summary>
        [DataMember(Name = "omsId", IsRequired = true)]
        public string OmsID { get; set; }

        /// <summary>Report ID (Идентификатор отчета)</summary>
        [DataMember(Name = "reportId", IsRequired = true)]
        public string ReportID { get; set; }

        /// <summary>Report status (Статус отчета)</summary>
        [DataMember(Name = "reportStatus", IsRequired = true)]
        public ReportStatuses ReportStatus { get; set; }
    }
}
