using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 4.5.11
    /// </summary>
    [DataContract]
    internal class Pong
    {
        [DataMember(Name = "omsId")]
        public string OmsID { get; set; }
    }
}
