using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.EdoLite.DataContracts
{
    /// <summary>
    /// 3.8. Получение списка документов.
    /// Цепочка документов.
    /// </summary>
    [DataContract]
    public class DocumentGroup
    {
        /// <summary>
        /// Идентификатор последнего документа цепочки
        /// </summary>
        [DataMember(Name = "id", IsRequired = false)]
        public string LastDocumentID { get; set; } // "66ecae1e-5ff6-41c5-be29-5e1162237b8c"

        /// <summary>
        /// Дата создания последнего документа цепочки в формате timestamp
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false)]
        public int CreatedAt { get; set; } // 1582090925

        /// <summary>
        /// Дата последнего документа цепочки в формате timestamp
        /// </summary>
        [DataMember(Name = "date", IsRequired = false)]
        public int Date { get; set; } // 1582059600

        /// <summary>
        /// Номер последнего документа в цепочке
        /// </summary>
        [DataMember(Name = "number", IsRequired = false)]
        public string Number { get; set; }

        /// <summary>
        /// Идентификатор группы цепочки документов
        /// </summary>
        [DataMember(Name = "group_id", IsRequired = false)]
        public string GroupID { get; set; } // "": "b89a69ce-0735-43ec-b19b-a502fd8bd28a",

        /// <summary>
        /// Числовой статус последнего документа цепочки
        /// см. Справочник "Статусы документов"
        /// </summary>
        [DataMember(Name = "status", IsRequired = false)]
        public int Status { get; set; } // 0

        /// <summary>
        /// Общая сумма c НДС
        /// </summary>
        [DataMember(Name = "total_price", IsRequired = false)]
        public int TotalPrice { get; set; } // 1930500

        /// <summary>
        /// Общая сумма НДС
        /// </summary>
        [DataMember(Name = "total_vat_amount", IsRequired = false)]
        public int TotalVatAmount { get; set; } // 279500

        /// <summary>
        /// Код типа документа последнего в цепочке
        /// см. Справочник "Типы документов"
        /// </summary>
        [DataMember(Name = "type", IsRequired = false)]
        public int Type { get; set; } // 504

        /// <summary>
        /// Информация о покупателе
        /// </summary>
        [DataMember(Name = "recipient", IsRequired = false)]
        public DocumentAgent Recipient { get; set; }

        /// <summary>
        /// Информация о покупателе
        /// </summary>
        [DataMember(Name = "sender", IsRequired = false)]
        public DocumentAgent Sender { get; set; }

        /// <summary>
        /// Дата создания документа в формате timestamp
        /// </summary>
        [DataMember(Name = "create_time_stamp", IsRequired = false)]
        public int CreateTimestamp { get; set; } // 1582059600

        /// <summary>
        /// Дата последней обработки документа в секундах
        /// </summary>
        [DataMember(Name = "export_time_stamp", IsRequired = false)]
        public int ExportTimestamp { get; set; } // 1582097248

        /// <summary>
        /// Информация о документах в системе ЭДО оператора
        /// </summary>
        [DataMember(Name = "documents", IsRequired = false)]
        public List<DocumentInfo> Documents { get; set; } = new List<DocumentInfo>();
    }
}
