using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// Code emission order product.
    /// 4.5.1. Метод «Создать заказ на эмиссию кодов маркировки»
    /// 4.5.1.1.13 Расширения для производителей пива, напитков,
    /// изготавливаемых на основе пива и слабоалкогольных напитков, Таблица 28.
    /// </summary>
    [DataContract]
    public class OrderProduct_Beer : OrderProduct
    {
        /// <summary>CIS type (Тип КМ)</summary>
        [DataMember(Name = "cisType", IsRequired = false)]
        public CisTypes? CisType { get; set; }
    }
}
