using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 4.5.17. Метод «Получить список сервис-провайдеров»
    /// 4.5.17.2, Ответ на запрос, Таблица 84.
    /// </summary>
    [DataContract]
    public partial class ProviderInfo
    {
        /// <summary>Site address (Адрес площадки)</summary>
        [DataMember(Name = "address", IsRequired = false)]
        public string Address { get; set; }

        /// <summary>Contact person (Контактное лицо)</summary>
        [DataMember(Name = "contactPerson", IsRequired = false)]
        public string ContactPerson { get; set; }

        /// <summary>Service provider country (Страна сервис провайдера)</summary>
        [DataMember(Name = "country", IsRequired = true)]
        public string Country { get; set; }

        /// <summary>E-mail (Электронный адрес)</summary>
        [DataMember(Name = "email", IsRequired = false)]
        public string Email { get; set; }

        /// <summary>Contractor name (Наименование контрагента)</summary>
        [DataMember(Name = "name", IsRequired = true)]
        public string Name { get; set; }

        /// <summary>Contractor role (Service Provider Role)</summary>
        [DataMember(Name = "productGroups", IsRequired = true)]
        public List<ProductGroups> ProductGroups { get; set; } = new List<ProductGroups>();

        /// <summary>Service provider name (Наименование сервис-провайдера)</summary>
        [DataMember(Name = "providerName", IsRequired = true)]
        public string ProviderName { get; set; }

        /// <summary>Service provider role (Роль сервис провайдера)</summary>
        [DataMember(Name = "role", IsRequired = false)]
        public string Role { get; set; }

        /// <summary>Service Provider ID (Идентификатор сервис-провайдера)</summary>
        [DataMember(Name = "serviceProviderId", IsRequired = true)]
        public string ServiceProviderID { get; set; }

        /// <summary>Exporter ID (Идентификатор экспортера)</summary>
        [DataMember(Name = "taxIdentificationNumber", IsRequired = true)]
        public string TaxIdentificationNumber { get; set; }
    }
}
