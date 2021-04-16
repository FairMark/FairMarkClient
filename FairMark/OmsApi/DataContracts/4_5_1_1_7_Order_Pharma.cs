using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// Code emission order.
    /// 4.5.1. Метод «Создать заказ на эмиссию кодов маркировки»
    /// 4.5.1.1.7 Расширения для фармацевтической промышленности, Таблица 19.
    /// </summary>
    [DataContract]
    public partial class Order_Pharma : Order<OrderProduct>
    {
        /// <summary>Is code emission free (Признак оплаты эмиссии КМ: true - не подлежит оплате, false - подлежит оплате (значение по умолчанию)</summary>
        [DataMember(Name = "freeCode", IsRequired = false)]
        public bool? FreeCode { get; set; }

        /// <summary>Payment Type (Тип оплаты: 1 - Оплата по эмиссии, 2 - Оплата по нанесению (значение по умолчанию)</summary>
        [DataMember(Name = "paymentType", IsRequired = false)]
        public int? PaymentType { get; set; }

        /// <summary>Subject ID (Субъект обращения)</summary>
        [DataMember(Name = "subjectId", IsRequired = true)]
        public string SubjectID { get; set; }
    }
}
