using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// CIS buffer pool information
    /// 4.5.7. Метод «Получить статус массива КМ из заказа»
    /// 4.5.7.2. Ответ на запрос, Таблица 58
    /// </summary>
    [DataContract]
    public class PoolInfo
    {
        /// <summary>
        /// Готовность РЭ .
        /// </summary>
        [DataMember(Name = "isRegistrarReady", IsRequired = true)]
        public bool IsRegistrarReady { get; set; }

        /// <summary>
        /// Метка времени последней наблюдавшейся ошибки РЭ.
        /// </summary>
        [DataMember(Name = "lastRegistrarErrorTimestamp", IsRequired = false)]
        public long LastRegistrarErrorTimestamp { get; set; }

        /// <summary>
        /// Заказанное количество КМ в пуле.
        /// </summary>
        [DataMember(Name = "quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Количество ошибок РЭ.
        /// </summary>
        [DataMember(Name = "registrarErrorCount")]
        public int RegistrarErrorCount { get; set; }

        /// <summary>
        /// Идентификатор РЭ (номер).
        /// </summary>
        [DataMember(Name = "registrarId")]
        public string RegistrarID { get; set; }

        /// <summary>
        /// Причина отказа.
        /// </summary>
        [DataMember(Name = "rejectionReason", IsRequired = false)]
        public string RejectionReason { get; set; }

        /// <summary>
        /// Статус пула КМ. Справочное значение «Статус массива КМ».
        /// см. раздел 5.3.1.5, <see cref="PoolStatuses"/>.
        /// </summary>
        [DataMember(Name = "status", IsRequired = true)]
        public PoolStatuses Status { get; set; }
    }
}
