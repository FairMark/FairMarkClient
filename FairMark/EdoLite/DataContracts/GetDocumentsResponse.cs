using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.EdoLite.DataContracts
{
    /// <summary>
    /// 3.8. Получение списка документов.
    /// Список цепочек документов.
    /// </summary>
    [DataContract]
    internal class GetDocumentsResponse
    {
        /// <summary>
        /// Цепочки документов
        /// </summary>
        [DataMember(Name = "items")]
        public List<DocumentGroup> Items { get; set; }

        /// <summary>
        /// Количество цепочек
        /// </summary>
        [DataMember(Name = "count", IsRequired = false)]
        public int Count { get; set; } // 1
    }
}
