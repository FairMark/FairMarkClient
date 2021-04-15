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
    /// 4.5.1.1.8 Расширения для производителей молока, Таблица 20.
    /// </summary>
    [DataContract]
    public class OrderProduct_Milk : OrderProduct
    {
        /// <summary>CIS type (Тип КМ)</summary>
        [DataMember(Name = "cisType", IsRequired = false)]
        public CisTypes? CisType { get; set; }

        /// <summary>Expiry date of the product (expiration date more than 72 hours) (Дата окончания срока годности продукции (срок хранения более 72 часов))</summary>
        [DataMember(Name = "expDate", IsRequired = false)]
        public string ExpDate { get; set; }

        /// <summary>Expiration date of the product (shelf life less than 72 hours) Дата окончания срока годности продукции (срок хранения менее 72 часов))</summary>
        [DataMember(Name = "expDate72", IsRequired = false)]
        public string ExpDate72 { get; set; }

        /// <summary>ИНН/УНБ (или аналог) экспортера</summary>
        /// <remarks>
        /// Примечание*: Поле «exporterTaxpayerId» становится обязательным, если в поле
        /// releaseMethodType (способ выпуска товара в оборот) было выбрано значение
        /// «CROSSBORDER» (Ввезен в РФ из стран ЕАЭС).
        /// </remarks>
        [DataMember(Name = "exporterTaxpayerId", IsRequired = false)]
        public string ExporterTaxpayerID { get; set; }
    }
}
