using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 4.5.17. Метод «Получить список сервис-провайдеров»
    /// 4.5.17.2, Ответ на запрос, Таблица 83.
    /// </summary>
    [DataContract]
    public partial class ProvidersDto
    {
        [DataMember(Name = "providers", IsRequired = false)]
        public List<ProviderInfo> Providers { get; set; }
    }
}
