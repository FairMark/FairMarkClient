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
    /// Отправитель или получатель цепочки документов.
    /// </summary>
    [DataContract]
    public class DocumentAgent
    {
        /// <summary>
        /// Идентификатор получателя в системе ЭДО оператора
        /// </summary>
        [DataMember(Name = "id", IsRequired = false)]
        public int ID { get; set; } // 600061573,

        /// <summary>
        /// Дополнительный идентификатор получателя в системе ЭДО оператора
        /// </summary>
        [DataMember(Name = "extra_id", IsRequired = false)]
        public string ExtraID { get; set; } // "00000000-23c4-3685-0000-000000000000",

        /// <summary>
        /// ИНН получателя
        /// </summary>
        [DataMember(Name = "inn", IsRequired = false)]
        public string Inn { get; set; } // "0000000000",
        
        /// <summary>
        /// КПП получателя
        /// </summary>
        [DataMember(Name = "kpp", IsRequired = false)]
        public string Kpp { get; set; } // null,

        /// <summary>
        /// ОГРН получателя
        /// </summary>
        [DataMember(Name = "ogrn", IsRequired = false)]
        public string Ogrn { get; set; } // "316503200073256",

        /// <summary>
        /// Адрес получателя
        /// </summary>
        [DataMember(Name = "address", IsRequired = false)]
        public string Address { get; set; } // null,

        /// <summary>
        /// Наименование получателя
        /// </summary>
        [DataMember(Name = "name", IsRequired = false)]
        public string Name { get; set; } // "ООО",

        /// <summary>
        /// E-mail получателя
        /// </summary>
        [DataMember(Name = "email", IsRequired = false)]
        public string Email { get; set; } // "noreply@example.com",
    }
}
