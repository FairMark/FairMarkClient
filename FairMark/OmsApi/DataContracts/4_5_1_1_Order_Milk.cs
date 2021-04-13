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
    /// 4.5.1.1.8 Расширения для производителей молока, Таблица 21.
    /// </summary>
    [DataContract]
    public class Order_Milk : Order<OrderProduct_Milk>
    {
        /// <summary>
        /// Контактное лицо.
        /// </summary>
        [DataMember(Name = "contactPerson", IsRequired = false)]
        public string ContactPerson { get; set; }

        /// <summary>
        /// Способ выпуска товаров в оборот.
        /// Справочное значение «Способ выпуска товаров в оборот»
        /// см. раздел 5.3.1.1.
        /// </summary>
        [DataMember(Name = "releaseMethodType", IsRequired = true)]
        public string ReleaseMethodType { get; set; }

        /// <summary>
        /// Способ изготовления СИ.
        /// Справочное значение «Способ изготовления»
        /// см. раздел 5.3.1.3.
        /// </summary>
        [DataMember(Name = "createMethodType", IsRequired = true)]
        public string CreateMethodType { get; set; }

        /// <summary>
        /// Идентификатор производственного заказа.
        /// </summary>
        [DataMember(Name = "productionOrderId", IsRequired = true)]
        public string ProductionOrderID { get; set; }
    }
}
