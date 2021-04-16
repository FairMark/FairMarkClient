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
    /// 4.5.1.1.6 Расширения для производителей фототоваров – категория товарной группы
	/// «Фотокамеры (кроме кинокамер), фотовспышки и лампы-вспышки», Таблица 17.
    /// </summary>
    /// <remarks>
	/// Примечание*: значение «REMAINS» справочника «Способ выпуска товаров в
	/// оборот» не применимо для категории товаров «Фотокамеры (кроме кинокамер),
	/// фотовспышки и лампы-вспышки»
    /// </remarks>
    [DataContract]
    public partial class Order_Photo : Order<OrderProduct_Photo>
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
    }
}
