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
        private List<IntroduceGoodsProduct> Products { get; set; }
    }

    [DataContract]
    public class IntroduceGoodsProduct
    {
        /// <summary>
        /// Дата производства товара из общих сведений о вводе товара в оборот.
        /// Формат: YYYY-MM-DD. Диапазон допустимых значений: от даты создания документа минус пять лет по дату создания документа.
        /// Параметр указывается, если его значение отличается от значения параметра "production_date" ("Дата производственноготовара"), указанного вне массива
        /// </summary>
        [DataMember(Name = "production_date")]
        public string ProductionDate { get; set; }

        /// <summary>
        /// КИ При агрегации, осуществлённой до ввода в оборот, необходимо указать КИ агрегатов.
        /// КИГУ и КИН не вводятся в оборот без указания вложенных КИ
        /// </summary>
        [DataMember(Name = "uit_code")]
        public string UitCode { get; set; }

        /// <summary>
        /// КИ транспортной упаковки. Параметр обязательный, если не указано значение параметра "uit_code" ("КИ")
        /// </summary>
        [DataMember(Name = "uitu_code")]
        public string UituCode { get; set; }
        
        /// <summary>
        /// Код ТН ВЭД(10 знаков)
        /// </summary>
        [DataMember(Name = "tnved_code")]
        public string TnvedCode { get; set; }
        
        /// <summary>
        /// Код вида документа обязательной сертификации.
        /// Возможные значения: CONFORMITY_CERTIFICATE – сертификат соответствия; CONFORMITY_DECLARATION – декларация соответствия
        /// </summary>
        [DataMember(Name = "certificate_document")]
        public string CertificateDocument { get; set; }
        
        /// <summary>
        /// Номер документа обязательной сертификации
        /// </summary>
        [DataMember(Name = "certificate_document_number")]
        public string CertificateDocumentNumber { get; set; }
        
        /// <summary>
        /// Дата документа обязательной сертификации
        /// Диапазон даты: начиная с 2000-01-01, по дату создания документа
        /// Форматы:
        /// YYYY-MM-DD;
        /// yyyy-MM-ddTHH:mm:ss;
        /// dd.MM.yyyy HH:mm;
        /// yyyy-MM-ddTHH:mm:ss.SSS;
        /// yyyy-MM-dd.
        /// </summary>
        [DataMember(Name = "certificate_document_date")]
        public string CertificateDocumentDate { get; set; }
        
        /// <summary>
        /// Номер ВСД Указывается для товарной группы "Молочная продукция". Параметр обязательный, если в карточке НК "veterinaryControl" ("Признак подконтрольности") = true.
        /// 
        /// Порядок указания номера ВСД, если в карточке НК "veterinaryControl" ("Признак подконтрольности") = true:
        /// КИ - номер ВСД указывается для КИ;
        /// КИГУ - номер ВСД указывается для  вложенных КИ или для КИГУ, или и для вложенных КИ и для КИГУ, при этом номер ВСД у КИГУ и вложенных КИ должен совпадать. Номер ВСД, указанный только для КИГУ, по умолчанию передаётся всем вложенным КИ;
        /// КИТУ - номер ВСД указывается только для вложенных КИ. Номер ВСД, указанный для вложенных КИ, не передаётся по умолчанию КИГУ и КИТУ
        /// 
        /// Формат:
        /// [a-f0-9]{8}-[a-f0-9]{4}-[a - f0 - 9]{ 4}-[af0 - 9]{ 4}-[a - f0 - 9]{ 12};
        /// [A-F0-9]{ 4}-[A - F0 - 9]{ 4}-[A - F0 - 9]{ 4}-[A - F0 - 9]{ 4}-[A - F0 - 9]{ 4}-[A - F0 - 9]{ 4}-[A - F0 - 9]{ 4}-[AF0 - 9]{ 4}.
        /// </summary>
        [DataMember(Name = "vsd_number")]
        public string VsdNumber { get; set; }
    }
}
