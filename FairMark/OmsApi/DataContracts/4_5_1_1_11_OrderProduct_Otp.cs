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
    /// 4.5.1.1.11 Расширения для производителей альтернативной табачной продукции, Таблица 24.
    /// </summary>
    [DataContract]
    public class OrderProduct_Otp : OrderProduct
    {
        /// <summary>CIS type (Тип КМ)</summary>
        [DataMember(Name = "cisType", IsRequired = false)]
        public CisTypes? CisType { get; set; }

        /// <summary>
        /// Максимальная розничная цена.
        /// </summary>
        /// <remarks>
        /// Примечание*: Поле «mrp» (Максимальная розничная цена) является обязательным
        /// для заполнения, максимально розничная цена должна указываться в копейках, с точностью
        /// до единицы, например, если цена 105 рублей и 1 копейка, то это число 10501, для блока
        /// это сумма всех пачек, также в копейках.        /// </remarks>
        [DataMember(Name = "mrp", IsRequired = true)]
        public string MaxRetailPrice { get; set; }
    }
}
