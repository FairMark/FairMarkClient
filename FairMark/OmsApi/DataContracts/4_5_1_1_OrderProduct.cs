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
    /// 4.5.1.1. Запрос, Таблица 6.
    /// </summary>
    [DataContract]
    public class OrderProduct
    {
        /// <summary>
        /// Код товара (GTIN).
        /// </summary>
        [DataMember(Name = "gtin", IsRequired = true)]
        public string Gtin { get; set; }

        /// <summary>
        /// Количество КМ.
        /// </summary>
        [DataMember(Name = "quantity", IsRequired = true)]
        public int Quantity { get; set; }

        /// <summary>
        /// Способ генерации серийных номеров.
        /// Справочное значение «Способ формирования индивидуального 
        /// серийного номера», см. раздел 5.3.1.2
        /// </summary>
        /// <remarks>
        /// Примечание: для товарной группы «Табачная продукция» первично установленная
        /// схема генерации и структура шаблона КМ для конкретного типа товара(GTIN),
        /// определяемая атрибутом «serialNumberType», не может быть изменена в дальнейшем.
        /// </remarks>
        [DataMember(Name = "serialNumberType", IsRequired = true)]
        public SerialNumberTypes SerialNumberType { get; set; }

        /// <summary>
        /// Массив серийных номеров.Это поле указывается в случае,
        /// если значение «serialNumber = SELF_MADE» (см. раздел.5.3.1.2).
        /// </summary>
        [DataMember(Name = "serialNumbers", IsRequired = false)]
        public List<string> SerialNumbers { get; set; } = new List<string>();

        /// <summary>
        /// Идентификатор шаблона КМ. Справочное значение
        /// «Способ изготовления», см.раздел 5.3.1.4
        /// </summary>
        /// <remarks>
        /// Для шаблона молочной продукции templateId=20 при
        /// самостоятельном способе генерации длина серийных номеров должна быть равна 5-ти
        /// символам. При эмиссии кодов маркировки серийный номер будет состоять из 6 символов,
        /// включая код страны. Код страны проставляется Сервером эмиссии и указывается перед
        /// полученным серийным номером (см.раздел 5.3.1.13).        /// </remarks>
        [DataMember(Name = "templateId", IsRequired = true)]
        public int TemplateID { get; set; }

        /// <summary>
        /// Идентификатор этикетки.
        /// </summary>
        /// <remarks>
        /// Примечание: поле «stickerId» заполняется при создании
        /// заказа в рамках процесса дистрибуции.
        /// В документации противоречие: тип указан как String,
        /// а в примерах передается значение Integer.
        /// Сделал тип Integer, по аналогии с полем TemplateID.
        /// </remarks>
        [DataMember(Name = "stickerId", IsRequired = false)]
        public int StickerID { get; set; }
    }
}
