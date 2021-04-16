using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// CIS buffer information
    /// 4.5.7. Метод «Получить статус массива КМ из заказа»
    /// 4.5.7.2. Ответ на запрос, Таблица 57
    /// </summary>
    [DataContract]
    public class BufferInfo
    {
        /// <summary>
        /// Общее количество доступных КМ для товара
        /// в буфере и пулах регистратора.
        /// </summary>
        [DataMember(Name = "availableCodes", IsRequired = true)]
        public int AvailableCodes { get; set; }

        /// <summary>
        /// Статус буфера. Справочное значение «Статус буфера КМ»
        /// см. раздел 5.3.1.7: <see cref="BufferStatuses"/>.
        /// </summary>
        [DataMember(Name = "bufferStatus", IsRequired = true)]
        public BufferStatuses BufferStatus { get; set; }

        /// <summary>
        /// Код товара (GTIN) – по которому был сделан запрос.
        /// </summary>
        [DataMember(Name = "gtin", IsRequired = true)]
        public string Gtin { get; set; }

        /// <summary>
        /// Количество неиспользованных КМ. (локальный буфер).
        /// </summary>
        [DataMember(Name = "leftInBuffer", IsRequired = true)]
        public int LeftInBuffer { get; set; }

        /// <summary>
        /// Уникальный идентификатор СУЗ.
        /// </summary>
        [DataMember(Name = "omsId", IsRequired = true)]
        public string OmsID { get; set; }

        /// <summary>
        /// Уникальный идентификатор СУЗ.
        /// </summary>
        [DataMember(Name = "orderId", IsRequired = true)]
        public string OrderID { get; set; }

        /// <summary>
        /// Массив пулов, созданных для буфера.
        /// </summary>
        [DataMember(Name = "poolInfos", IsRequired = true)]
        public List<PoolInfo> PoolInfos { get; set; } = new List<PoolInfo>();

        /// <summary>
        /// Пулы КМ в регистраторах исчерпаны.
        /// </summary>
        [DataMember(Name = "poolsExhausted", IsRequired = true)]
        public bool PoolsExhausted { get; set; }

        /// <summary>
        /// Причина отклонения буфера со стороны СУЗ.
        /// </summary>
        /// <remarks>
        /// Примечание: в случае отклонения заказа в данном поле содержится
        /// значение «Order declined: » и далее причина отклонения заказа.
        /// </remarks>
        [DataMember(Name = "rejectionReason", IsRequired = false)]
        public string RejectionReason { get; set; }

        /// <summary>
        /// Заказанное количество КМ в заказе.
        /// </summary>
        [DataMember(Name = "totalCodes")]
        public int TotalCodes { get; set; }

        /// <summary>
        /// Суммарное кол-во КМ полученных из буфера.
        /// </summary>
        [DataMember(Name = "totalPassed", IsRequired = true)]
        public int TotalPassed { get; set; }

        /// <summary>
        /// Количество недоступных кодов.
        /// </summary>
        [DataMember(Name = "unavailableCodes", IsRequired = true)]
        public int UnavailableCodes { get; set; }

        /// <summary>
        /// Дата истечения срока годности КМ.
        /// Формат: UnixTime(в миллисекундах).
        /// </summary>
        [DataMember(Name = "expiredDate", IsRequired = false)]
        public string ExpiredDate { get; set; }
    }
}
