using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 4.5.9. Метод «Получить информацию об агрегации»
    /// 4.5.9.2. Ответ на запрос, Таблица 64.
    /// </summary>
    [DataContract]
    public class ProductInfo
    {
        [DataMember(Name = "gtin", IsRequired = false)]
        public string Gtin { get; set; }

        [DataMember(Name = "name", IsRequired = false)]
        public string Name { get; set; }
    }
}
