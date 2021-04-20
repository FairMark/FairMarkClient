using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 4.5.5. Метод «Закрыть подзаказ/заказ»
    /// 4.5.11 Метод «Проверить доступность СУЗ»
    /// </summary>
    [DataContract]
    internal class EmptyResult
    {
        [DataMember(Name = "omsId")]
        public string OmsID { get; set; }
    }
}
