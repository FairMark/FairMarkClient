using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 4.5.14. Метод «Получить список идентификаторов пакетов кодов маркировки»
    /// 4.5.14.3. Ответ на запрос, Таблица 76.
    /// </summary>
    [DataContract]
    public partial class BlockDto
    {
        /// <summary>Date, time of creation of the marking code package(Дата, время создания пакета кодов маркировки)</summary>
        [DataMember(Name = "blockDateTime", IsRequired = false)]
        public long? BlockDateTime { get; set; }

        /// <summary>Unique identifier of a business order for issuing MC (Уникальный идентификатор бизнес-заказа на эмиссию КМ)</summary>
        [DataMember(Name = "blockId", IsRequired = false)]
        public string BlockID { get; set; }

        /// <summary>Количество КМ/СИ</summary>
        [DataMember(Name = "quantity", IsRequired = false)]
        public int? Quantity { get; set; }
    }
}
