using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// Code emission order response.
    /// 4.5.1. Метод «Создать заказ на эмиссию кодов маркировки»
    /// 4.5.1.2. Ответ на запрос
    /// </summary>
    [DataContract]
    public class OrderResponse
    {
        [DataMember(Name = "omsId")]
        public string OmsID { get; set; }

        [DataMember(Name = "orderId")]
        public string OrderID { get; set; }

        [DataMember(Name = "expectedCompleteTimestamp")]
        public long ExpectedCompleteTimestamp { get; set; }
    }
}
