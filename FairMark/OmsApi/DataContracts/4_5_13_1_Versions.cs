using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 4.5.13. Метод «Получить версию СУЗ и API»
    /// </summary>
    [DataContract]
    public class Versions
    {
        [DataMember(Name = "apiVersion")]
        public string ApiVersion { get; set; }

        [DataMember(Name = "omsVersion")]
        public string OmsVersion { get; set; }
    }
}
