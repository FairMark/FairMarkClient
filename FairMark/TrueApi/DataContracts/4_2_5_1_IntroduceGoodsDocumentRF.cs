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
    [DataContract]
    public class IntroduceGoodsDocumentRF : IUniformDocumentBase
    {
        public string DocumentApiName { get; } = "LP_INTRODUCE_GOODS";
        public ProductGroupsTrueApi ProductGroup { get; set; }

        /// <summary>
        /// ИНН участника, осуществившего эмиссию КИ
        /// </summary>
        [DataMember(Name = "participant_inn")]
        public string ParticipantInn { get; set; }

        /// <summary>
        /// Дата производства товара.
        /// Задаётся в формате yyyy-MM-dd. Диапазон допустимых значений: от даты создания документа минус пять лет по дату создания документа. 
        /// Диапазон допустимых значений: от даты создания документа минус пять лет по дату создания документа.
        /// Параметр является обязательным, если "production_date" ("Дата производства товара") не указан в массиве <see cref="Products"/> ("Массив, содержащий список передаваемых кодов товаров")  </summary>
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
        public string ProductionType { get; } = "OWN_PRODUCTION";//According to documentation only one value can be - OWN_PRODUCTION

        /// <summary>
        /// Перечень товаров
        /// </summary>
        [DataMember(Name = "products")]
        public List<IntroduceGoodsProduct> Products { get; set; }
    }

}
