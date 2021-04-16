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
    /// 4.5.1.1.11 Расширения для производителей альтернативной табачной продукции, Таблица 25.
    /// </summary>
    [DataContract]
    public partial class Order_Otp : Order<OrderProduct_Otp>
    {
        /// <summary>Contact Person (Контактное лицо)</summary>
        [DataMember(Name = "contactPerson", IsRequired = false)]
        public string ContactPerson { get; set; }

        /// <summary>Marking Manufacturing Type (Способ изготовления)</summary>
        [DataMember(Name = "createMethodType", IsRequired = true)]
        public CreateMethodTypes CreateMethodType { get; set; }

        /// <summary>Start date for the production of this order (Дата начала производства продукции по данному заказу)</summary>
        [DataMember(Name = "expectedStartDate", IsRequired = false)]
        public string ExpectedStartDate { get; set; }

        /// <summary>Manufacturer's address (Адрес производства)</summary>
        [DataMember(Name = "factoryAddress", IsRequired = false)]
        public string FactoryAddress { get; set; }

        /// <summary>Country of origin (Страна производителя)</summary>
        [DataMember(Name = "factoryCountry", IsRequired = true)]
        public string FactoryCountry { get; set; }

        /// <summary>Production identifier (Global Location Number) (Идентификатор производства (Глобальный номер места нахождения))</summary>
        [DataMember(Name = "factoryId", IsRequired = true)]
        public string FactoryID { get; set; }

        /// <summary>Name of production (Наименование производства)</summary>
        [DataMember(Name = "factoryName", IsRequired = false)]
        public string FactoryName { get; set; }

        /// <summary>Production order number (Номер производственного заказа)</summary>
        [DataMember(Name = "poNumber", IsRequired = false)]
        public string PoNumber { get; set; }

        /// <summary>Product code (SKU) (Код продукта (SKU))</summary>
        [DataMember(Name = "productCode", IsRequired = true)]
        public string ProductCode { get; set; }

        /// <summary>Product description (Описание продукта)</summary>
        [DataMember(Name = "productDescription", IsRequired = true)]
        public string ProductDescription { get; set; }

        /// <summary>Production line identifier (Идентификатор производственной линии)</summary>
        [DataMember(Name = "productionLineId", IsRequired = true)]
        public string ProductionLineID { get; set; }

        /// <summary>Production Order ID (Идентификатор производственного заказа)</summary>
        [DataMember(Name = "productionOrderId", IsRequired = false)]
        public string ProductionOrderID { get; set; }

        /// <summary>Product Release Type (Способ выпуска товаров в оборот)</summary>
        [DataMember(Name = "releaseMethodType", IsRequired = true)]
        public ReleaseMethodTypes ReleaseMethodType { get; set; }
    }
}
