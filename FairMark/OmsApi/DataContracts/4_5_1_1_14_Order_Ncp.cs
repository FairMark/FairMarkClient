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
    /// 4.5.1.1.14 Расширения для производителей никотиносодержащей продукции, Таблица 29.
    /// </summary>
    /// <remarks>
    /// Примечание: Поле «mrp» (Максимальная розничная цена) в структуре запроса для
	/// категории товарной группы «Никотиносодержащая продукция» отсутствует:
	/// При эмиссии КМ для товаров с шаблоном кодов маркировок templateId = 21 (блоки)
	/// максимальная розничная цена (mrp) для каждого товара автоматически заполняется и
	/// содержит числовой формат, соответствующий 6 нулям - 000000,
	/// При эмиссии КМ для товаров с шаблоном кодов маркировок templateId = 22 (пачки)
	/// максимальная розничная цена (mrp) для каждого товара автоматически заполняется и
	/// содержит символьный формат (в перекодированном виде, соответствующий 4А – АААА).
	/// Примечание: Значения «REMAINS», «REMARK» и «CROSSBORDER» справочника
	/// «Способ выпуска товаров в оборот» не применимы для категории товаров
	/// «Никотиносодержащая продукция».
    /// </remarks>
    [DataContract]
    public partial class Order_Ncp : Order<OrderProduct>
    {
        /// <summary>Expected Start Date (Дата начала производства продукции по данному заказу)</summary>
        [DataMember(Name = "expectedStartDate", IsRequired = false)]
        public string ExpectedStartDate { get; set; }

        /// <summary>Factory Address (Адрес производства)</summary>
        [DataMember(Name = "factoryAddress", IsRequired = false)]
        public string FactoryAddress { get; set; }

        /// <summary>Factory Country (Страна производителя)</summary>
        [DataMember(Name = "factoryCountry", IsRequired = true)]
        public string FactoryCountry { get; set; }

        /// <summary>Factory Identifier (GLN) Идентификатор производства. (Глобальный номер места нахождения)</summary>
        [DataMember(Name = "factoryId", IsRequired = true)]
        public string FactoryID { get; set; }

        /// <summary>Factory Name (Наименование производства)</summary>
        [DataMember(Name = "factoryName", IsRequired = false)]
        public string FactoryName { get; set; }

        /// <summary>PO Number (Номер производственного заказа)</summary>
        [DataMember(Name = "poNumber", IsRequired = false)]
        public string PoNumber { get; set; }

        /// <summary>Product Code SKU (Код продукта)</summary>
        [DataMember(Name = "productCode", IsRequired = true)]
        public string ProductCode { get; set; }

        /// <summary>Product Description (Описание продукта)</summary>
        [DataMember(Name = "productDescription", IsRequired = true)]
        public string ProductDescription { get; set; }

        /// <summary>Line Identifier (Идентификатор производственной линии)</summary>
        [DataMember(Name = "productionLineId", IsRequired = true)]
        public string ProductionLineID { get; set; }

        /// <summary>Product Release Type (Способ выпуска товаров в оборот)</summary>
        [DataMember(Name = "releaseMethodType", IsRequired = true)]
        public ReleaseMethodTypes ReleaseMethodType { get; set; }
    }
}
