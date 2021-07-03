using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.TrueApi.DataContracts
{
    using System.Runtime.Serialization;
    
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
