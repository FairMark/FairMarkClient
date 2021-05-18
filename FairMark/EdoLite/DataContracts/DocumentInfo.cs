using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.EdoLite.DataContracts
{
    using System;

    /// <summary>
    /// 3.8. Получение списка документов.
    /// Информация о документе.
    /// </summary>
    [DataContract]
    public class DocumentInfo
    {
        /// <summary>
        /// Идентификатор документа в системе ЭДО оператора
        /// </summary>
        [DataMember(Name = "id", IsRequired = false)]
        public string ID { get; set; } // "66ecae1e-5ff6-41c5-be29-5e1162237b8c",

        /// <summary>
        /// Дата создания документа в формате timestamp
        /// </summary>
        [DataMember(Name = "created_at", IsRequired = false)]
        public long CreatedAt { get; set; } // 1582090925

        /// <summary>
        /// Дата документа в формате timestamp
        /// </summary>
        [DataMember(Name = "date", IsRequired = false)]
        public int Date { get; set; } // 1582059600

        /// <summary>
        /// Номер документа
        /// </summary>
        [DataMember(Name = "number", IsRequired = false)]
        public string Number { get; set; }

        /// <summary>
        /// Дата последней обработки документа в формате timestamp
        /// </summary>
        [DataMember(Name = "processed_at", IsRequired = false)]
        public long ProcessedAt { get; set; } // 1582059600

        /// <summary>
        /// Числовой статус документа
        /// см. Справочник "Статусы документов"
        /// </summary>
        [DataMember(Name = "status", IsRequired = false)]
        public int Status { get; set; } // 0

        /// <summary>
        /// Цена с НДС
        /// </summary>
        [DataMember(Name = "total_price", IsRequired = false)]
        public int TotalPrice { get; set; } // 1930500

        /// <summary>
        /// Цена с НДС
        /// </summary>
        [DataMember(Name = "total_vat_amount", IsRequired = false)]
        public int TotalVatAmount { get; set; } // 279500

        /// <summary>
        /// Код типа документа
        /// см. Справочник "Типы документов"
        /// </summary>
        [DataMember(Name = "type", IsRequired = false)]
        public int Type { get; set; } // 504
    }
}