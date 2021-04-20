using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 4.5.16. Метод «Получить квитанцию по уникальному идентификатору документа»
    /// 4.5.16.2. Формат объекта Receipt, Таблица 81.
    /// </summary>
    [DataContract]
    public partial class ReceiptDto
    {
        [DataMember(Name = "content", IsRequired = false)]
        public string Content { get; set; }

        [DataMember(Name = "signature", IsRequired = false)]
        public string Signature { get; set; }
    }
}
