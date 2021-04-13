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
    ///  4.5.1.1.8 Расширения для производителей молока, Таблица 20.
    /// </summary>
    [DataContract]
    public class OrderProduct_Milk : OrderProduct
    {
        /// <summary>
        /// Максимальная розничная цена.
        /// </summary>
        /// <remarks>
        /// Примечание*: Поле «exporterTaxpayerId» становится обязательным, если в поле
        /// releaseMethodType (способ выпуска товара в оборот) было выбрано значение
        /// «CROSSBORDER» (Ввезен в РФ из стран ЕАЭС).        /// </remarks>
        [DataMember(Name = "exporterTaxpayerId", IsRequired = false)]
        public string ExporterTaxpayerID { get; set; }
    }
}
