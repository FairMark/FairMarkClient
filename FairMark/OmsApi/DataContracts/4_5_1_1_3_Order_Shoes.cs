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
    /// 4.5.1.1.3 Расширения для лёгкой промышленности – категория товарной группы «Обувные товары», Таблица 11.
    /// </summary>
    /// <remarks>
    /// Примечание*: значение «REMAINS» справочника «Способ выпуска товаров в
	/// оборот» не применимо для категории товаров «Обувные товары».
    /// </remarks>
    [DataContract]
    public partial class Order_Shoes : Order<OrderProduct_Shoes>
    {
        /// <summary>Contact Person (Контактное лицо)</summary>
        [DataMember(Name = "contactPerson", IsRequired = false)]
        public string ContactPerson { get; set; }

        /// <summary>Marking Manufacturing Type (Способ изготовления)</summary>
        [DataMember(Name = "createMethodType", IsRequired = true)]
        public CreateMethodTypes CreateMethodType { get; set; }

        /// <summary>Production Order ID (Идентификатор производственного заказа)</summary>
        [DataMember(Name = "productionOrderId", IsRequired = false)]
        public string ProductionOrderID { get; set; }

        /// <summary>Product Release Type (Способ выпуска товаров в оборот)</summary>
        [DataMember(Name = "releaseMethodType", IsRequired = true)]
        public ReleaseMethodTypes ReleaseMethodType { get; set; }

        /// <summary>Признак того, что товар произведен/приобретен до даты запрета оборота немаркированных товаров по данной ТГ</summary>
        [DataMember(Name = "remainsAvailable", IsRequired = false)]
        public bool? RemainsAvailable { get; set; }
    }
}
