using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.TrueApi.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Ответ на 5.4.2. Метод получения списка кодов товаров (GTIN) УОТ по ИНН
    /// Примечание: Ответ, получаемый в реальности, не соответствует документации!
    /// </summary>
    [DataContract]
    public class GetParticipantGtinsReponse
    {
        /// <summary>
        /// Сколько всего кодов
        /// </summary>
        [DataMember(Name = "total")]
        public int Total { get; set; }

        /// <summary>
        /// Список Gtin`ов
        /// </summary>
        [DataMember(Name = "gtins")]
        public List<string> Gtins { get; set; }
    }
}
