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
    /// 4.5.1.1.2 Расширения для лёгкой промышленности – категория товарной группы
    /// «Предметы одежды, белье постельное, столовое, туалетное и кухонное», Таблица 10.
    /// </summary>
    /// <remarks>
    /// Примечание*: Поле «exporterTaxpayerId» становится обязательным, если в поле
	/// releaseMethod (способ выпуска товара в оборот) было выбрано значение
	/// «CROSSBORDER» (Ввезен в РФ из стран ЕАЭС).
    /// </remarks>
    [DataContract]
    public class OrderProduct_Lp : OrderProduct
    {
        /// <summary>CIS type (Тип КМ)</summary>
        [DataMember(Name = "cisType", IsRequired = false)]
        public CisTypes? CisType { get; set; }

        /// <summary>ИНН/УНБ (или аналог) экспортера</summary>
        [DataMember(Name = "exporterTaxpayerId", IsRequired = false)]
        public string ExporterTaxpayerID { get; set; }
    }
}
