using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.TrueApi.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Ответ на 5.4.1. Метод получения информации о товаре по GTIN товара
    /// ВНИМАНИЕ: Контракт описан на основе ответа для молочных продуктов. Данный контракт требует дополнения и уточнения!
    /// Примечание: Ответ, получаемый в реальности, не совсем соответствует документации!
    /// </summary>
    [DataContract]
    public class GetProductsInfoResponse
    {
        /// <summary>
        /// Массив с информацией о товарах по запрошенным КИ
        /// </summary>
        [DataMember(Name = "results")]
        public ProductsInfo[] Products { get; set; }

        /// <summary>
        /// Сколько товаров вернулось в запросе
        /// </summary>
        [DataMember(Name = "total")]
        public int TotalProductsInRequest { get; set; }
    }

    /// <summary>
    /// ВНИМАНИЕ: Контракт описан на основе ответа для молочных продуктов. Данный контракт требует дополнения и уточнения!
    /// Примечание: Ответ, получаемый в реальности, не совсем соответствует документации!
    /// </summary>
    [DataContract]
    public class ProductsInfo
    {
        /// <summary>
        /// ID товара
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Наименование товара
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Код товара, по которому выполняется запрос
        /// </summary>
        [DataMember(Name = "gtin")]
        public string Gtin { get; set; }

        /// <summary>
        /// Бренд
        /// </summary>
        [DataMember(Name = "brand")]
        public string Brand { get; set; }

        /// <summary>
        /// Тип упаковки
        /// Примечание: См. Справочник "Типы упаковки"
        /// </summary>
        [DataMember(Name = "packageType")]
        public string PackageType { get; set; }

        /// <summary>
        /// Количество товара в упаковке
        /// </summary>
        [DataMember(Name = "innerUnitCount")]
        public double InnerUnitCount { get; set; }

        /// <summary>
        /// ИНН участника оборота товара
        /// </summary>
        [DataMember(Name = "inn")]
        public string Inn { get; set; }

        /// <summary>
        /// Идентификатор товарной группы
        /// Примечание: См. Справочник "Список поддерживаемых товарных групп". Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "productGroupId")]
        public Int64 ProductGroupId { get; set; }

        /// <summary>
        /// Идентификатор товарной группы
        /// Примечание: См. Справочник "Список поддерживаемых товарных групп". Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "productGroup")]
        public int ProductGroup { get; set; }

        /// <summary>
        /// Признак подписания карточки товара в КМТ
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "goodSignedFlag")]
        public bool GoodSignedFlag { get; set; }
        /// <summary>
        /// Признак готовности к маркировке
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "goodMarkFlag")]
        public bool GoodMarkFlag { get; set; }
        /// <summary>
        /// Индикатор заполнения второго слоя карточки в КМТ
        /// Примечание: Индикатор заполнения второго слоя карточки в НК. Если значение = true, то можно заказать КМ и ввести товар в оборот. Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "goodTurnFlag")]
        public bool GoodTurnFlag { get; set; }

        /// <summary>
        /// Группа ТН ВЭД
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        //[DataMember(Name = "tnVedCode")]//Судя по ответу это поле возвращается как просто tnved
        [DataMember(Name = "tnved")]
        public string TnVedCode { get; set; }

        /// <summary>
        /// Массив кодов ТН ВЭД (10 знаков)
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "tnVed10")]
        public string TnVedCode10 { get; set; }

        /// <summary>
        /// Признак "Комплект" в карточке товара
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "isKit")]
        public bool IsKit { get; set; }

        /// <summary>
        /// Признак "Технологический" по карточке товара
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "isTechGtin")]
        public bool IsTechGtin { get; set; }

        /// <summary>
        /// Признак "Набор" по карточке товара в КМТ
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "isSet")]
        public bool IsSet { get; set; }

        /// <summary>
        /// Уровень упаковки
        /// Примечание: Значения: trade-unit - единица КТ; inner-pack - групповая упаковка
        /// </summary>
        [DataMember(Name = "level")]
        public string Level { get; set; }

        /// <summary>
        /// В документации описания нет! Неизвестное поле, но в ответе возвращается!
        /// </summary>
        [DataMember(Name = "multiplier")]
        public string Multiplier { get; set; }

        /// <summary>
        /// Cтатус карточки товара в КМТ
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ. Если карточка товара выводится из GS1, то параметр не возвращается.
        /// Возможные значения: draft - карточка товара в разных статусах в КМТ: "Черновик", "На модерации", "Требует изменений", "Ожидает подписания"; published - опубликованная карточка товара; archived - карточка товара в архиве
        /// </summary>
        [DataMember(Name = "goodStatus")]
        public string GoodStatus { get; set; }

        /// <summary>
        /// Признак принадлежности кода товара субаккаунту
        /// Примечание: Если значение = true - субаккаунту был предоставлен доступ к этому коду товара. Если значение = false - код товара собственный
        /// </summary>
        [DataMember(Name = "isGtinSubaccount")]
        public bool IsGtinSubaccount { get; set; }
        
        /// <summary>
        /// Категория молочного товара
        /// </summary>
        [DataMember(Name = "milkProductType")]
        public string MilkProductType { get; set; }

        /// <summary>
        /// Обязательный ветеринарный контроль
        /// </summary>
        [DataMember(Name = "veterinaryControl")]
        public string VeterinaryControl { get; set; }

        /// <summary>
        /// В документации описания нет! Неизвестное поле, но в ответе возвращается!
        /// </summary>
        [DataMember(Name = "okpd2Group")]
        public string Okpd2Group { get; set; }

        /// <summary>
        /// Полное наименование товара
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "fullName")]
        public string FullName { get; set; }

        /// <summary>
        /// Является детским питанием
        /// </summary>
        [DataMember(Name = "babyFoodProduct")]
        public string BabyFoodProduct { get; set; }

        /// <summary>
        /// Вес или объём
        /// </summary>
        [DataMember(Name = "volumeWeight")]
        public string VolumeWeight { get; set; }

        /// <summary>
        /// Состав
        /// </summary>
        [DataMember(Name = "structure")]
        public string Structure { get; set; }

        /// <summary>
        /// В документации описания нет! Неизвестное поле, но в ответе возвращается!
        /// </summary>
        [DataMember(Name = "isSpecializedFoodProduct")]
        public string IsSpecializedFoodProduct { get; set; }

        /// <summary>
        /// В документации описания нет! Неизвестное поле, но в ответе возвращается!
        /// </summary>
        [DataMember(Name = "packMaterial")]
        public string PackMaterial { get; set; }

        /// <summary>
        /// В документации описания нет! Неизвестное поле, но в ответе возвращается!
        /// </summary>
        [DataMember(Name = "isShelfLife40Days")]
        public string IsShelfLife40Days { get; set; }
        
        /// <summary>
        /// В документации описания нет! Неизвестное поле, но в ответе возвращается!
        /// </summary>
        [DataMember(Name = "paymentGroup")]
        public string PaymentGroup { get; set; }

        /// <summary>
        /// В документации описания нет! Неизвестное поле, но в ответе возвращается!
        /// </summary>
        [DataMember(Name = "fat")]
        public string Fat { get; set; }

        /// <summary>
        /// В документации описания нет! Неизвестное поле, но в ответе возвращается!
        /// </summary>
        [DataMember(Name = "rawOrigin")]
        public string RawOrigin { get; set; }





        //Ниже поля из документации, которые не возвращаются для товаров группы Молоко. Т.к. название полей могут не соответствовать действительности, то не стал их ключать в контракт!
        /*
        /// <summary>
        /// Модель, артикул производителя
        /// Примечание: Параметр возвращается в ответе для товарных групп "Шины и покрышки пневматические резиновые новые", "Обувные товары", "Предметы одежды бельё постельное столовое туалетное и кухонное", "Фотокамеры, кроме кинокамер, фотовспышки и лампы-вспышки", "Кресла- коляски"
        /// </summary>
        [DataMember(Name = "model")]
        public string model { get; set; }
        /// <summary>
        /// Дата публикации кода товара
        /// Примечание: Формат: yyyy-MM-ddTHH:mm:ss.SSS’Z
        /// </summary>
        [DataMember(Name = "publicationDate")]
        public Int64 publicationDate { get; set; }
        /// <summary>
        /// Заявитель маркируемого и вводимого в оборот товара
        /// </summary>
        [DataMember(Name = "exporter")]
        public object exporter { get; set; }
        /// <summary>
        /// ID заявителя
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "id")]
        public Int64 id { get; set; }
        /// <summary>
        /// Идентификатор заявителя в БД КМТ
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "ncId")]
        public Int64 ncId { get; set; }
        /// <summary>
        /// Наименование заявителя- экспортёра
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "exporterName")]
        public string exporterName { get; set; }
        /// <summary>
        /// ИНН заявителя или его аналог
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "exporterTaxpayerId")]
        public string exporterTaxpayerId { get; set; }
        /// <summary>
        /// КПП или его аналог
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "kpp")]
        public string kpp { get; set; }
        /// <summary>
        /// Глобальный идентификатор компании в GS1
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "gcp")]
        public string gcp { get; set; }
        /// <summary>
        /// Глобальный идентификатор места нахождения
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "gln")]
        public string gln { get; set; }
        /// <summary>
        /// Адрес производственной площадки
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "manufactureAddress")]
        public string manufactureAddress { get; set; }
        /// <summary>
        /// Ссылка на аккаунт импортёра
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "importerAccount")]
        public string importerAccount { get; set; }
        /// <summary>
        /// Массив ИНН компаний- субаккаунтов, которым владелец кода товара предоставил возможность использовать данный код товара для заказа КМ
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в  КМТ. Параметр возвращается для владельца кода товара и для Оператора
        /// </summary>
        [DataMember(Name = "permittedInns")]
        public string[] permittedInns { get; set; }
  
        /// <summary>
        /// Объект с данными о производителе
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "foreignProducer")]
        public object foreignProducer { get; set; }
        /// <summary>
        /// Наименование производителя
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "name")]
        public string name { get; set; }
        /// <summary>
        /// ИНН производителя или его аналог
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "inn")]
        public string inn { get; set; }
        /// <summary>
        /// КПП производителя или его аналог
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "kpp")]
        public string kpp { get; set; }
        /// <summary>
        /// GCP производителя
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "gcp")]
        public string gcp { get; set; }
        /// <summary>
        /// GLN производителя
        /// </summary>
        [DataMember(Name = "gln")]
        public string gln { get; set; }
        /// <summary>
        /// Массив адресов производителя
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "address")]
        public string[] address { get; set; }
        /// <summary>
        /// Выводимая ошибка, если обязательные атрибуты не заполнены или карточка товара в КМТ не подписана
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "explain")]
        public string explain { get; set; }
        /// <summary>
        /// Описание набора
        /// Примечание: Возвращается описание товара в составе набора, содержащее параметры, специфичные для конкретного товара. Данный параметр вернётся в том случае, если он заполнен в карточке НК (см. "Справочник "Дополнительные параметры в ответе в зависимости от товарных групп""). Данный параметр вернётся только в том случае, если он заполнен в карточке НК.
        /// </summary>
        [DataMember(Name = "setDescription")]
        public string setDescription { get; set; }
        /// <summary>
        /// Страна производства
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "country")]
        public string country { get; set; }
        /// <summary>
        /// Данные полученные ГИС МТ в ответе от ФТС при вводе товара в оборот
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "fts")]
        public object fts { get; set; }
        /// <summary>
        /// Массив данных по РД
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "rds")]
        public array[object] rds { get; set; }
        /// <summary>
        /// Дата разрешительного документа
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "authDocDate")]
        public string authDocDate { get; set; }
        /// <summary>
        /// Номер разрешительного документа
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "authDocNumber")]
        public string authDocNumber { get; set; }
        /// <summary>
        /// Массив стран производства
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "countries")]
        public string[] countries { get; set; }
        /// <summary>
        /// Массив уникальных значений цветов изделия
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "colors")]
        public string[] colors { get; set; }
        /// <summary>
        /// Массив кодов товара, входящих в состав набора
        /// Примечание: Возвращается в ответе, если "isSet" = true при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "setGtin")]
        public array[object] setGtin { get; set; }
        /// <summary>
        /// Код товара, входящего в набор
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "gtin")]
        public string gtin { get; set; }
        /// <summary>
        /// Признак "Набор" по карточке товара в КМТ
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "isSet")]
        public bool isSet { get; set; }
        /// <summary>
        /// Массив кодов товара, входящих в состав набора
        /// Примечание: Возвращается в ответе, если "isSet" = true при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "setGtin")]
        public array[object] setGtin { get; set; }
        /// <summary>
        /// Код товара
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "gtin")]
        public string gtin { get; set; }
        /// <summary>
        /// Количество кодов товаров
        /// Примечание: Возвращается в ответе при условии указания сведений в карточке товара в КМТ
        /// </summary>
        [DataMember(Name = "quantity")]
        public int quantity { get; set; }
        /// <summary>
        /// Количество найденных товаров
        /// </summary>
        [DataMember(Name = "total")]
        public int total { get; set; }
        /// <summary>
        /// Код ошибки
        /// </summary>
        [DataMember(Name = "errorCode")]
        public string errorCode { get; set; }
        */
    }
}
