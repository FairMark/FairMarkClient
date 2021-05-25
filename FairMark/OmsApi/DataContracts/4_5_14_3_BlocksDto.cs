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
    /// 4.5.14.3. Ответ на запрос, Таблица 75.
    /// </summary>
    [DataContract]
    public partial class BlocksDto
    {
        [DataMember(Name = "blocks", IsRequired = false)]
        public List<BlockDto> Blocks { get; set; }

        /// <summary>Product GTIN (GTIN товара)</summary>
        [DataMember(Name = "gtin", IsRequired = true)]
        public string Gtin { get; set; }

        /// <summary>Уникальный идентификатор СУЗ</summary>
        [DataMember(Name = "omsId", IsRequired = true)]
        public string OmsID { get; set; }

        /// <summary>Unique identifier of a business order for issuing MC (Уникальный идентификатор бизнес-заказа на эмиссию КМ)</summary>
        [DataMember(Name = "orderId", IsRequired = false)]
        public Guid OrderID { get; set; }
    }
}
