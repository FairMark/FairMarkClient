using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GisMtClient.DataContracts
{
    [DataContract]
    public class AuthResponse
    {
        [DataMember(Name = "uuid")]
        public string UUID { get; set; }

        [DataMember(Name = "data")]
        public string Data { get; set; }
    }
}
