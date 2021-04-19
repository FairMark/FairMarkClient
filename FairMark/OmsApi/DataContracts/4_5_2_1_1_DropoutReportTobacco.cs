using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 4.5.2.1. Метод «Отправить отчёт о выбытии/отбраковке КМ»
    /// 4.5.2.1.1 Расширения для табачной промышленности, Таблица 33.
    /// </summary>
    /// <remarks>
    /// Примечание*: В случае отсутствия полей sourceDocDate и sourceDocNum СУЗ
    /// заполняет их автоматически следующими значениями:
    /// 1) sourceDocDate – текущая дата в unixTime UTC:0 в миллисекундах;
    /// 2) sourceDocNum – текущая дата в unixTime UTC:0 в миллисекундах.
    /// </remarks>
    [DataContract]
    public partial class DropoutReportTobacco : DropoutReport
    {
        /// <summary>Address where the write-off was made (Адрес, где было произведено списание)</summary>
        [DataMember(Name = "address", IsRequired = true)]
        public string Address { get; set; }

        /// <summary>Taxpayer Identification Number (Идентификационный номер налогоплательщика)</summary>
        [DataMember(Name = "participantId", IsRequired = true)]
        public string ParticipantID { get; set; }

        /// <summary>Production Line Number (Идентификатор производственной линии)</summary>
        [DataMember(Name = "productionLineId", IsRequired = false)]
        public string ProductionLineID { get; set; }

        /// <summary>The Id of the production order (Идентификатор производственного заказа)</summary>
        [DataMember(Name = "productionOrderId", IsRequired = false)]
        public string ProductionOrderID { get; set; }

        /// <summary>Dropout document date (Дата первичного документа)</summary>
        [DataMember(Name = "sourceDocDate", IsRequired = false)]
        public string SourceDocDate { get; set; }

        /// <summary>Dropout document number (Номер первичного документа)</summary>
        [DataMember(Name = "sourceDocNum", IsRequired = false)]
        public string SourceDocNum { get; set; }

        /// <summary>Specifies whether to write off all nested items (Признак списания всех вложенных элементов)</summary>
        [DataMember(Name = "withChild", IsRequired = true)]
        public bool WithChild { get; set; }
    }
}
