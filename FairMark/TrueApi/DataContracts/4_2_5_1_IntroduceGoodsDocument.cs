using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.TrueApi.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// 4.2.5.1. Ввод в оборот
    /// </summary>
    //[DataContract(Name = "bank_details")]   
    public class IntroduceGoodsDocumentRF
    {
        /// <summary>
        /// ИНН участника, осуществившего эмиссию КИ
        /// </summary>
        [DataMember(Name = "participant_inn")]
        public string ParticipantInn { get; set; }

        /// <summary>
        /// Дата производства товара
        /// Задаётся в формате yyyy-MM-dd. Диапазон допустимых значений: от даты создания документа минус пять лет по дату создания документа
        /// </summary>
        [DataMember(Name = "production_date")]
        public string ProductionDate { get; set; }

        /// <summary>
        /// ИНН производителя товара
        /// </summary>
        [DataMember(Name = "producer_inn")]
        public string ProducerInn { get; set; }

        /// <summary>
        /// ИНН собственника товара
        /// </summary>
        [DataMember(Name = "owner_inn")]
        public string OwnerInn { get; set; }

        /// <summary>
        /// Тип производственного заказа
        /// Возможные значения: OWN_PRODUCTION – Собственное производство
        /// </summary>
        [DataMember(Name = "production_type")]
        public string ProductionType { get; set; } = "OWN_PRODUCTION";//In documentaion is said that only one value can be - OWN_PRODUCTION

        /// <summary>
        /// Перечень товаров
        /// </summary>
        //[DataMember(Name = "products")]
        //List<> Products
    }
}
