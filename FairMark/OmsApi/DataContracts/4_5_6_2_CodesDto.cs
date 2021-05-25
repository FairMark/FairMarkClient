using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 4.5.6. Метод «Получить КМ из заказа»
    /// 4.5.6.2. Ответ на запрос, Таблица 55.
    /// 4.5.15 Метод «Получить повторно коды маркировки из заказа кодов маркировки»
    /// 4.5.15.3. Ответ на запрос, Таблица 78.
    /// </summary>
    [DataContract]
    public partial class CodesDto
    {
        /// <summary>Identifier of code block (Идентификатор блока кодов)</summary>
        [DataMember(Name = "blockId", IsRequired = false)]
        public Guid BlockID { get; set; }

        /// <summary>Identification Codes (Список КМ)</summary>
        [DataMember(Name = "codes", IsRequired = false)]
        public List<string> Codes { get; set; }

        /// <summary>Уникальный идентификатор СУЗ</summary>
        [DataMember(Name = "omsId", IsRequired = true)]
        public string OmsID { get; set; }
    }
}
