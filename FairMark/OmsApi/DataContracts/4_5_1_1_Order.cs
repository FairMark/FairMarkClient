using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// Code emission order.
    /// 4.5.1. Метод «Создать заказ на эмиссию кодов маркировки»
    /// 4.5.1.1. Запрос, Таблица 5.
    /// </summary>
    [DataContract]
    public class Order
    {
        /// <summary>
        /// Список товаров.
        /// </summary>
        /// <remarks>
        /// В зависимости от типа товара в этой коллекции нужно
        /// передавать экземпляры либо класса <see cref="OrderProduct"/>,
        /// либо его потомков: <see cref="OrderProduct_Tobacco"/> и др.
        /// </remarks>
        [DataMember(Name = "products", IsRequired = true)]
        public List<OrderProduct> Products { get; set; } = new List<OrderProduct>();

        /// <summary>
        /// Идентификатор сервис-провайдера.
        /// </summary>
        [DataMember(Name = "serviceProviderId", IsRequired = false)]
        public string ServiceProviderID { get; set; }
    }
}
