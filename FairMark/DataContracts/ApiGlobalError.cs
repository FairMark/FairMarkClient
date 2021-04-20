using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.DataContracts
{
    /// <summary>
    /// Структура, которая содержит описание ошибочного поля.
    /// </summary>
    [DataContract]
    public partial class ApiGlobalError
    {
        [DataMember(Name = "error", IsRequired = false)]
        public string Error { get; set; }

        [DataMember(Name = "errorCode", IsRequired = false)]
        public int? ErrorCode { get; set; }
    }
}
