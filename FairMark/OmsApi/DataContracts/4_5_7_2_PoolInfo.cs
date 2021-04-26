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
        /// <summary>Logical flag that shows if the Emission Registrar is currently ready for orders (Готовность РЭ)</summary>
        [DataMember(Name = "isRegistrarReady", IsRequired = true)]
        public bool IsRegistrarReady { get; set; }

        /// <summary>Timestamp when the last Emission Registrar error occurred (Метка времени последней наблюдавшейся ошибки РЭ)</summary>
        [DataMember(Name = "lastRegistrarErrorTimestamp", IsRequired = true)]
        public long LastRegistrarErrorTimestamp { get; set; }

        /// <summary>Number of unused ICs in the pool (Оставшеесе кол-во КМ в пуле)</summary>
        [DataMember(Name = "leftInRegistrar", IsRequired = true)]
        public int LeftInRegistrar { get; set; }

        /// <summary>Number of ICs ordered in the array (Заказанное кол-во КМ в пуле)</summary>
        [DataMember(Name = "quantity", IsRequired = true)]
        public int Quantity { get; set; }

        /// <summary>Number of Emission Registrar errors occurred (Количество ошибок РЭ)</summary>
        [DataMember(Name = "registrarErrorCount", IsRequired = true)]
        public int RegistrarErrorCount { get; set; }

        /// <summary>Emission Registrar Identifier (Номер РЭ)</summary>
        [DataMember(Name = "registrarId", IsRequired = true)]
        public string RegistrarID { get; set; }

        /// <summary>The IC array rejection reason returned by the Emission Registrar (Причина отказа)</summary>
        [DataMember(Name = "rejectionReason", IsRequired = false)]
        public string RejectionReason { get; set; }

        /// <summary>
        /// IC array status (Статус пула КМ). Справочное значение «Статус массива КМ».
        /// см. раздел 5.3.1.5, <see cref="PoolStatuses"/>.
        /// </summary>
        [DataMember(Name = "status", IsRequired = true)]
        public PoolStatuses Status { get; set; }
    }
}
