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
    public partial class ApiFieldError
    {
        [DataMember(Name = "errorCode", IsRequired = false)]
        public int? ErrorCode { get; set; }

        [DataMember(Name = "fieldError", IsRequired = false)]
        public string FieldError { get; set; }

        [DataMember(Name = "fieldName", IsRequired = false)]
        public string FieldName { get; set; }
    }
}
