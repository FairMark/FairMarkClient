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
    /// 4.5.1.1.1 Расширения для табачной промышленности, Таблица 8.
    /// </summary>
    [DataContract]
    public class Order_Tobacco : Order
    {
        /// <summary>
        /// Идентификатор производства. (Глобальный номер места нахождения)
        /// </summary>
        [DataMember(Name = "factoryId", IsRequired = true)]
        public string FactoryID { get; set; }

        /// <summary>
        /// Наименование производства.
        /// </summary>
        [DataMember(Name = "factoryName", IsRequired = true)]
        public string FactoryName { get; set; }

        /// <summary>
        /// Адрес производства.
        /// </summary>
        [DataMember(Name = "factoryAddress", IsRequired = true)]
        public string FactoryAddress { get; set; }

        /// <summary>
        /// Страна производителя.
        /// </summary>
        [DataMember(Name = "factoryCountry", IsRequired = true)]
        public string FactoryCountry { get; set; }

        /// <summary>
        /// Идентификатор производственной линии.
        /// </summary>
        [DataMember(Name = "productionLineId", IsRequired = true)]
        public string ProductionLineID { get; set; }

        /// <summary>
        /// Код продукта (SKU).
        /// </summary>
        [DataMember(Name = "productCode", IsRequired = true)]
        public string ProductCode { get; set; }

        /// <summary>
        /// Описание продукта.
        /// </summary>
        [DataMember(Name = "productDescription", IsRequired = true)]
        public string ProductDescription { get; set; }

        /// <summary>
        /// Номер производственного заказа.
        /// </summary>
        [DataMember(Name = "poNumber", IsRequired = false)]
        public string PoNumber { get; set; }

        /// <summary>
        /// Дата начала производства продукции по данному заказу.
        /// </summary>
        /// <remarks>
        /// Формат: (yyyy-mm-dd).
        /// </remarks>
        [DataMember(Name = "expectedStartDate", IsRequired = false)]
        public string ExpectedStartDate { get; set; }
    }
}
