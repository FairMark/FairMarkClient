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
    /// 4.5.1.1.3 Расширения для лёгкой промышленности – категория товарной группы «Обувные товары», Таблица 12.
    /// </summary>
    /// <remarks>
    /// Примечание*: Поле «exporterTaxpayerId» становится обязательным, если в поле
	/// releaseMethod (способ выпуска товара в оборот) было выбрано значение
	/// «CROSSBORDER» (Ввезен в РФ из стран ЕАЭС).
    /// </remarks>
    [DataContract]
    public class OrderProduct_Shoes : OrderProduct
    {
        /// <summary>ИНН/УНБ (или аналог) экспортера</summary>
        [DataMember(Name = "exporterTaxpayerId", IsRequired = false)]
        public string ExporterTaxpayerID { get; set; }
    }
}
