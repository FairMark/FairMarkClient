using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.EdoLite.DataContracts
{
    [DataContract]
    internal class ResID
    {
        [DataMember(Name = "id", IsRequired = true)]
        public string ID { get; set; }
    }
}
