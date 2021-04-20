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
    /// 4.5.16.2. Ответ на запрос, Таблица 80.
    /// </summary>
    [DataContract]
    public partial class ReceiptsDto
    {
        [DataMember(Name = "receipts", IsRequired = false)]
        public List<ReceiptDto> Receipts { get; set; }
    }
}
