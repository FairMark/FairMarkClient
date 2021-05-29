using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 4.5.4.1 Метод «Отправить отчёт об использовании (нанесении) КМ»
    /// 4.5.4.1.3 Расширения для производителей молока, Таблица 47.
    /// </summary>
    /// <remarks>
    /// Примечание*: В отчёте обязательно должна быть представлена дата срока
    /// годности продукции в атрибуте «expDate» или «expDate72». В случае, если коды
    /// маркировки содержат дату срока годности продукции, отличную от значения, указанного в
    /// атрибутах «expDate» или «expDate72», отчёт не будет принят. 
    /// Атрибут «accompanyingDocument» в текущей версии является необязательным и в
    /// дальнейшем будет исключён как устаревший.
    /// </remarks>
    [DataContract]
    public partial class UtilisationReport_Milk : UtilisationReport
    {
        /// <summary>Производственный ветеринарный сопроводительный документ</summary>
        [DataMember(Name = "accompanyingDocument", IsRequired = false)]
        public string AccompanyingDocument { get; set; }

        /// <summary>Capacity/Weight (Объем/Масса)</summary>
        [DataMember(Name = "capacity", IsRequired = false)]
        public double? Capacity { get; set; }

        /// <summary>CIS type (Тип КМ)</summary>
        [DataMember(Name = "cisType", IsRequired = true)]
        public CisTypes CisType { get; set; }

        /// <summary>Date format: "yyMMdd" Expiry date of the product (expiration date more than 72 hours) (Дата окончания срока годности продукции (срок хранения более 72 часов))</summary>
        [DataMember(Name = "expDate", IsRequired = false)]
        public string ExpDate { get; set; }

        /// <summary>Date format: "yyMMddHHmm" Expiry date of the product (expiration date more than 72 hours) (Дата окончания срока годности продукции (срок хранения менее 72 часов))</summary>
        [DataMember(Name = "expDate72", IsRequired = false)]
        public string ExpDate72 { get; set; }

        /// <summary>The indication of use of ICs in production (Признак использовании КМ на производстве)</summary>
        /// <remarks>Признак использования КМ на производстве: 0 – значение по умолчанию; 1 – КМ были использованы на производстве</remarks>
        [DataMember(Name = "usedInProduction", IsRequired = false)]
        public int? UsedInProduction { get; set; }
    }
}
