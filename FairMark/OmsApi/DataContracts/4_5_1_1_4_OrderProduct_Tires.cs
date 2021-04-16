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
    /// 4.5.1.1.4 Расширения для производителей шин – категория товарной группы
    /// «Шины и покрышки пневматические резиновые новые», Таблица 14.
    /// </summary>
    /// <remarks>
    /// Примечание*: Поле «exporterTaxpayerId» становится обязательным, если в поле
	/// releaseMethod (способ выпуска товара в оборот) было выбрано значение
	/// «CROSSBORDER» (Ввезен в РФ из стран ЕАЭС).
    /// </remarks>
    [DataContract]
    public class OrderProduct_Tires : OrderProduct
    {
        /// <summary>ИНН/УНБ (или аналог) экспортера</summary>
        [DataMember(Name = "exporterTaxpayerId", IsRequired = false)]
        public string ExporterTaxpayerID { get; set; }
    }
}
