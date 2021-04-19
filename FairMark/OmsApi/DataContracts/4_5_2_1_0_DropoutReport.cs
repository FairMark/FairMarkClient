using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 4.5.2.1. Метод «Отправить отчёт о выбытии/отбраковке КМ», Таблица 32.
    /// </summary>
    /// <remarks>
    /// Примечание. Количество КМ в отчёте о выбытии не должно превышать 30 000 кодов.
    /// Примечание. Для ТГ «Табачная продукция» и «Никотиносодержащая продукция»
    /// допустимо указывать в массиве выбывших КМ транспортные и групповые упаковки с
    /// указанием признака списания всех вложенных элементов.
    /// Массив выбывших КМ потребительской упаковки для ТГ «Табачная продукция» и
    /// «Никотиносодержащая продукция» обязательно должен содержать код идентификации
    /// (GTIN + Serial).
    /// </remarks>
    [DataContract]
    public partial class DropoutReport
    {
        /// <summary>Dropout reason (Причина выбытия)</summary>
        [DataMember(Name = "dropoutReason", IsRequired = true)]
        public DropoutReasons DropoutReason { get; set; }

        /// <summary>Identification Codes that were dropped out (Информация о выбывших КМ)</summary>
        [DataMember(Name = "sntins", IsRequired = true)]
        public List<string> Sntins { get; set; } = new List<string>();
    }
}
