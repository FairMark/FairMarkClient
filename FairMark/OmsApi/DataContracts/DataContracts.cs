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
    /// 4.5.1.1.8 Расширения для производителей молока, Таблица 21.
    /// </summary>
    [DataContract]
    public partial class AggregationInfo
    {
        /// <summary>Aggregation unit (Единица агрегации)</summary>
        [DataMember(Name = "aggregationUnit", IsRequired = true)]
        public AggregationUnit AggregationUnit { get; set; } = new AggregationUnit();

        /// <summary>Уникальный идентификатор СУЗ</summary>
        [DataMember(Name = "omsId", IsRequired = true)]
        public string OmsID { get; set; }

        /// <summary>Taxpayer Identification Number (Идентификационный номер налогоплательщика)</summary>
        [DataMember(Name = "participantId", IsRequired = false)]
        public string ParticipantID { get; set; }

        [DataMember(Name = "productsInfo", IsRequired = false)]
        public List<ProductInfo> ProductsInfo { get; set; }


    }

    [DataContract]
    public partial class AggregationReportDtoBeer
    {
        /// <summary>Array of aggregation unit (Массив единиц агрегации)</summary>
        [DataMember(Name = "aggregationUnits", IsRequired = true)]
        public List<AggregationUnit> AggregationUnits { get; set; } = new List<AggregationUnit>();

        /// <summary>Taxpayer Identification Number (Идентификационный номер налогоплательщика)</summary>
        [DataMember(Name = "participantId", IsRequired = true)]
        public string ParticipantID { get; set; }


    }

    [DataContract]
    public partial class AggregationReportDtoLight
    {
        /// <summary>Array of aggregation unit (Массив единиц агрегации)</summary>
        [DataMember(Name = "aggregationUnits", IsRequired = true)]
        public List<AggregationUnit> AggregationUnits { get; set; } = new List<AggregationUnit>();

        /// <summary>Taxpayer Identification Number (Идентификационный номер налогоплательщика)</summary>
        [DataMember(Name = "participantId", IsRequired = true)]
        public string ParticipantID { get; set; }


    }

    [DataContract]
    public partial class AggregationReportDtoLp
    {
        /// <summary>Array of aggregation unit (Массив единиц агрегации)</summary>
        [DataMember(Name = "aggregationUnits", IsRequired = true)]
        public List<AggregationUnit> AggregationUnits { get; set; } = new List<AggregationUnit>();

        /// <summary>Taxpayer Identification Number (Идентификационный номер налогоплательщика)</summary>
        [DataMember(Name = "participantId", IsRequired = true)]
        public string ParticipantID { get; set; }


    }

    [DataContract]
    public partial class AggregationReportDtoMilk
    {
        /// <summary>Array of aggregation unit (Массив единиц агрегации)</summary>
        [DataMember(Name = "aggregationUnits", IsRequired = true)]
        public List<AggregationUnit> AggregationUnits { get; set; } = new List<AggregationUnit>();

        /// <summary>Taxpayer Identification Number (Идентификационный номер налогоплательщика)</summary>
        [DataMember(Name = "participantId", IsRequired = true)]
        public string ParticipantID { get; set; }


    }

    [DataContract]
    public partial class AggregationReportDtoNcp
    {
        /// <summary>Array of aggregation unit (Массив единиц агрегации)</summary>
        [DataMember(Name = "aggregationUnits", IsRequired = true)]
        public List<AggregationUnit> AggregationUnits { get; set; } = new List<AggregationUnit>();

        /// <summary>Наименование бренда продукции</summary>
        [DataMember(Name = "brandcode", IsRequired = false)]
        public string Brandcode { get; set; }

        /// <summary>Taxpayer Identification Number (Идентификационный номер налогоплательщика)</summary>
        [DataMember(Name = "participantId", IsRequired = true)]
        public string ParticipantID { get; set; }

        /// <summary>Production date (Дата производства)</summary>
        [DataMember(Name = "productionDate", IsRequired = false)]
        public string ProductionDate { get; set; }

        /// <summary>Production Line ID (Идентификатор производственной линии)</summary>
        [DataMember(Name = "productionLineId", IsRequired = true)]
        public string ProductionLineID { get; set; }

        /// <summary>Идентификатор производственного заказа</summary>
        [DataMember(Name = "productionOrderId", IsRequired = false)]
        public string ProductionOrderID { get; set; }


    }

    [DataContract]
    public partial class AggregationReportDtoOtp
    {
        /// <summary>Array of aggregation unit (Массив единиц агрегации)</summary>
        [DataMember(Name = "aggregationUnits", IsRequired = true)]
        public List<AggregationUnit> AggregationUnits { get; set; } = new List<AggregationUnit>();

        /// <summary>Taxpayer Identification Number (Идентификационный номер налогоплательщика)</summary>
        [DataMember(Name = "participantId", IsRequired = true)]
        public string ParticipantID { get; set; }

        /// <summary>Production Line ID (Идентификатор производственной линии)</summary>
        [DataMember(Name = "productionLineId", IsRequired = true)]
        public string ProductionLineID { get; set; }

        [DataMember(Name = "productionOrderId", IsRequired = false)]
        public string ProductionOrderID { get; set; }


    }

    [DataContract]
    public partial class AggregationReportDtoPerfum
    {
        /// <summary>Array of aggregation unit (Массив единиц агрегации)</summary>
        [DataMember(Name = "aggregationUnits", IsRequired = true)]
        public List<AggregationUnit> AggregationUnits { get; set; } = new List<AggregationUnit>();

        /// <summary>Taxpayer Identification Number (Идентификационный номер налогоплательщика)</summary>
        [DataMember(Name = "participantId", IsRequired = true)]
        public string ParticipantID { get; set; }


    }

    [DataContract]
    public partial class AggregationReportDtoPhoto
    {
        /// <summary>Array of aggregation unit (Массив единиц агрегации)</summary>
        [DataMember(Name = "aggregationUnits", IsRequired = true)]
        public List<AggregationUnit> AggregationUnits { get; set; } = new List<AggregationUnit>();

        /// <summary>Taxpayer Identification Number (Идентификационный номер налогоплательщика)</summary>
        [DataMember(Name = "participantId", IsRequired = true)]
        public string ParticipantID { get; set; }


    }

    [DataContract]
    public partial class AggregationReportDtoShoes
    {
        /// <summary>Array of aggregation unit (Массив единиц агрегации)</summary>
        [DataMember(Name = "aggregationUnits", IsRequired = true)]
        public List<AggregationUnit> AggregationUnits { get; set; } = new List<AggregationUnit>();

        /// <summary>Taxpayer Identification Number (Идентификационный номер налогоплательщика)</summary>
        [DataMember(Name = "participantId", IsRequired = true)]
        public string ParticipantID { get; set; }


    }

    [DataContract]
    public partial class AggregationReportDtoTobacco
    {
        /// <summary>Array of aggregation unit (Массив единиц агрегации)</summary>
        [DataMember(Name = "aggregationUnits", IsRequired = true)]
        public List<AggregationUnit> AggregationUnits { get; set; } = new List<AggregationUnit>();

        /// <summary>Taxpayer Identification Number (Идентификационный номер налогоплательщика)</summary>
        [DataMember(Name = "participantId", IsRequired = true)]
        public string ParticipantID { get; set; }

        /// <summary>Production date (Дата производства)</summary>
        [DataMember(Name = "productionDate", IsRequired = false)]
        public string ProductionDate { get; set; }

        /// <summary>Production line number (Номер производственной линии)</summary>
        [DataMember(Name = "productionLineId", IsRequired = true)]
        public string ProductionLineID { get; set; }

        /// <summary>The Id of the production order (Идентификатор производственного заказа)</summary>
        [DataMember(Name = "productionOrderId", IsRequired = false)]
        public string ProductionOrderID { get; set; }


    }

    [DataContract]
    public partial class AggregationReportDtoWater
    {
        /// <summary>Array of aggregation unit (Массив единиц агрегации)</summary>
        [DataMember(Name = "aggregationUnits", IsRequired = true)]
        public List<AggregationUnit> AggregationUnits { get; set; } = new List<AggregationUnit>();

        /// <summary>Taxpayer Identification Number (Идентификационный номер налогоплательщика)</summary>
        [DataMember(Name = "participantId", IsRequired = true)]
        public string ParticipantID { get; set; }


    }

    [DataContract]
    public partial class AggregationUnit
    {
        /// <summary>Number of goods actually aggregated in the unit (Фактически упаковано)</summary>
        [DataMember(Name = "aggregatedItemsCount", IsRequired = true)]
        public int AggregatedItemsCount { get; set; }

        /// <summary>Aggregation operation type (Тип агрегации)</summary>
        [DataMember(Name = "aggregationType", IsRequired = true)]

        public AggregationUnitAggregationType AggregationType { get; set; }

        /// <summary>Aggregation Unit Capacity (Емкость упаковки)</summary>
        [DataMember(Name = "aggregationUnitCapacity", IsRequired = true)]
        public int AggregationUnitCapacity { get; set; }

        /// <summary>List of the Aggregated Identification Codes (Список агрегированных КМ)</summary>
        [DataMember(Name = "sntins", IsRequired = true)]
        public List<string> Sntins { get; set; } = new List<string>();

        /// <summary>Identification Code of Aggregation Unit (КМ агрегата)</summary>
        [DataMember(Name = "unitSerialNumber", IsRequired = true)]
        public string UnitSerialNumber { get; set; }


    }

    [DataContract]
    public partial class AppVersion
    {
        /// <summary>OMS API Version (Версия API СУЗ)</summary>
        [DataMember(Name = "apiVersion", IsRequired = false)]
        public string ApiVersion { get; set; }

        /// <summary>OMS Version (Версия СУЗ)</summary>
        [DataMember(Name = "omsVersion", IsRequired = false)]
        public string OmsVersion { get; set; }


    }

    [DataContract]
    public partial class BlockDto
    {
        /// <summary>Date, time of creation of the marking code package(Дата, время создания пакета кодов маркировки)</summary>
        [DataMember(Name = "blockDateTime", IsRequired = false)]
        public long? BlockDateTime { get; set; }

        /// <summary>Unique identifier of a business order for issuing MC (Уникальный идентификатор бизнес-заказа на эмиссию КМ)</summary>
        [DataMember(Name = "blockId", IsRequired = false)]
        public string BlockID { get; set; }

        /// <summary>Количество КМ/СИ</summary>
        [DataMember(Name = "quantity", IsRequired = false)]
        public int? Quantity { get; set; }


    }

    [DataContract]
    public partial class BlocksDto
    {
        [DataMember(Name = "blocks", IsRequired = false)]
        public List<BlockDto> Blocks { get; set; }

        /// <summary>Product GTIN (GTIN товара)</summary>
        [DataMember(Name = "gtin", IsRequired = true)]
        public string Gtin { get; set; }

        /// <summary>Уникальный идентификатор СУЗ</summary>
        [DataMember(Name = "omsId", IsRequired = true)]
        public string OmsID { get; set; }

        /// <summary>Unique identifier of a business order for issuing MC (Уникальный идентификатор бизнес-заказа на эмиссию КМ)</summary>
        [DataMember(Name = "orderId", IsRequired = false)]
        public string OrderID { get; set; }


    }

    [DataContract]
    public partial class BufferInfo
    {
        /// <summary>Number of available codes in buffer and pools (Общее кол-во доступных КМ для товара в буфере и пулах регистратора)</summary>
        [DataMember(Name = "availableCodes", IsRequired = true)]
        public int AvailableCodes { get; set; }

        /// <summary>Buffer status (Статус буфера)</summary>
        [DataMember(Name = "bufferStatus", IsRequired = true)]

        public BufferInfoBufferStatus BufferStatus { get; set; }

        /// <summary>Codes expired date in millis since epoch (Дата истечения срока годности КМ в Unix time. Равна нулю если срок годности не ограничен.)</summary>
        [DataMember(Name = "expiredDate", IsRequired = false)]
        public long? ExpiredDate { get; set; }

        /// <summary>Product GTIN (GTIN товара)</summary>
        [DataMember(Name = "gtin", IsRequired = true)]
        public string Gtin { get; set; }

        /// <summary>Number of unused ICs in the array (Остаток КМ в буфере СУЗ)</summary>
        [DataMember(Name = "leftInBuffer", IsRequired = true)]
        public int LeftInBuffer { get; set; }

        /// <summary>Уникальный идентификатор СУЗ</summary>
        [DataMember(Name = "omsId", IsRequired = true)]
        public string OmsID { get; set; }

        /// <summary>A unique order ID in OMS (Уникальный идентификатор заказа на эмиссию КМ)</summary>
        [DataMember(Name = "orderId", IsRequired = true)]
        public string OrderID { get; set; }

        /// <summary>Array of pools created for the IC buffer (Массив пулов, созданных для буфера)</summary>
        [DataMember(Name = "poolInfos", IsRequired = false)]
        public List<PoolInfo> PoolInfos { get; set; }

        /// <summary>ER pools was exhausted (Закончились КМ в пулах РЭ)</summary>
        [DataMember(Name = "poolsExhausted", IsRequired = true)]
        public bool PoolsExhausted { get; set; }

        /// <summary>Buffer rejection reason (Причина отклонения буфера СУЗ-ом)</summary>
        [DataMember(Name = "rejectionReason", IsRequired = false)]
        public string RejectionReason { get; set; }

        /// <summary>Order quantity of IC in the order (Общее кол-во заказанных КМ для товара)</summary>
        [DataMember(Name = "totalCodes", IsRequired = true)]
        public int TotalCodes { get; set; }

        /// <summary>Buffer total passed codes (Суммарное кол-во КМ полученных из буфера)</summary>
        [DataMember(Name = "totalPassed", IsRequired = true)]
        public int TotalPassed { get; set; }

        /// <summary>Number of unavailable codes (Общее кол-во недоступных КМ для товара в связи с техническими причинами)</summary>
        [DataMember(Name = "unavailableCodes", IsRequired = true)]
        public int UnavailableCodes { get; set; }


    }

    [DataContract]
    public partial class CodesDto
    {
        /// <summary>Identifier of code block (Идентификатор блока кодов)</summary>
        [DataMember(Name = "blockId", IsRequired = false)]
        public string BlockID { get; set; }

        /// <summary>Identification Codes (Список КМ)</summary>
        [DataMember(Name = "codes", IsRequired = false)]
        public List<string> Codes { get; set; }

        /// <summary>Уникальный идентификатор СУЗ</summary>
        [DataMember(Name = "omsId", IsRequired = true)]
        public string OmsID { get; set; }


    }

    [DataContract]
    public partial class DropoutReportDtoBeer
    {
        /// <summary>Dropout reason (Причина выбытия)</summary>
        [DataMember(Name = "dropoutReason", IsRequired = true)]

        public DropoutReportDtoBeerDropoutReason DropoutReason { get; set; }

        /// <summary>Identification Codes that were dropped out (Информация о выбывших КМ)</summary>
        [DataMember(Name = "sntins", IsRequired = true)]
        public List<string> Sntins { get; set; } = new List<string>();


    }

    [DataContract]
    public partial class DropoutReportDtoMilk
    {
        /// <summary>Dropout reason (Причина выбытия)</summary>
        [DataMember(Name = "dropoutReason", IsRequired = true)]

        public DropoutReportDtoMilkDropoutReason DropoutReason { get; set; }

        /// <summary>Identification Codes that were dropped out (Информация о выбывших КМ)</summary>
        [DataMember(Name = "sntins", IsRequired = true)]
        public List<string> Sntins { get; set; } = new List<string>();


    }

    [DataContract]
    public partial class DropoutReportDtoNcp
    {
        /// <summary>Address where the write-off was made (Адрес, где было произведено списание)</summary>
        [DataMember(Name = "address", IsRequired = true)]
        public string Address { get; set; }

        /// <summary>Dropout reason (Причина выбытия)</summary>
        [DataMember(Name = "dropoutReason", IsRequired = true)]

        public DropoutReportDtoNcpDropoutReason DropoutReason { get; set; }

        /// <summary>Taxpayer Identification Number (Идентификационный номер налогоплательщика)</summary>
        [DataMember(Name = "participantId", IsRequired = true)]
        public string ParticipantID { get; set; }

        /// <summary>Production Line Number (Идентификатор производственной линии)</summary>
        [DataMember(Name = "productionLineId", IsRequired = false)]
        public string ProductionLineID { get; set; }

        /// <summary>The Id of the production order (Идентификатор производственного заказа)</summary>
        [DataMember(Name = "productionOrderId", IsRequired = false)]
        public string ProductionOrderID { get; set; }

        /// <summary>Identification Codes that were dropped out (Информация о выбывших КМ)</summary>
        [DataMember(Name = "sntins", IsRequired = true)]
        public List<string> Sntins { get; set; } = new List<string>();

        /// <summary>Dropout document date (Дата документа)</summary>
        [DataMember(Name = "sourceDocDate", IsRequired = false)]
        public string SourceDocDate { get; set; }

        /// <summary>Dropout document number (Идентификатор документа, на основании которого осуществляется списание)</summary>
        [DataMember(Name = "sourceDocNum", IsRequired = false)]
        public string SourceDocNum { get; set; }

        /// <summary>Specifies whether to write off all nested items (Признак списания всех вложенных элементов)</summary>
        [DataMember(Name = "withChild", IsRequired = true)]
        public bool WithChild { get; set; }


    }

    [DataContract]
    public partial class DropoutReportDtoTobacco
    {
        /// <summary>Address where the write-off was made (Адрес, где было произведено списание)</summary>
        [DataMember(Name = "address", IsRequired = true)]
        public string Address { get; set; }

        /// <summary>Dropout reason (Причина выбытия)</summary>
        [DataMember(Name = "dropoutReason", IsRequired = true)]

        public DropoutReportDtoTobaccoDropoutReason DropoutReason { get; set; }

        /// <summary>Taxpayer Identification Number (Идентификационный номер налогоплательщика)</summary>
        [DataMember(Name = "participantId", IsRequired = true)]
        public string ParticipantID { get; set; }

        /// <summary>Production Line Number (Идентификатор производственной линии)</summary>
        [DataMember(Name = "productionLineId", IsRequired = false)]
        public string ProductionLineID { get; set; }

        /// <summary>The Id of the production order (Идентификатор производственного заказа)</summary>
        [DataMember(Name = "productionOrderId", IsRequired = false)]
        public string ProductionOrderID { get; set; }

        /// <summary>Identification Codes that were dropped out (Информация о выбывших КМ)</summary>
        [DataMember(Name = "sntins", IsRequired = true)]
        public List<string> Sntins { get; set; } = new List<string>();

        /// <summary>Dropout document date (Дата первичного документа)</summary>
        [DataMember(Name = "sourceDocDate", IsRequired = false)]
        public string SourceDocDate { get; set; }

        /// <summary>Dropout document number (Номер первичного документа)</summary>
        [DataMember(Name = "sourceDocNum", IsRequired = false)]
        public string SourceDocNum { get; set; }

        /// <summary>Specifies whether to write off all nested items (Признак списания всех вложенных элементов)</summary>
        [DataMember(Name = "withChild", IsRequired = true)]
        public bool WithChild { get; set; }


    }

    [DataContract]
    public partial class DropoutReportDtoWater
    {
        /// <summary>Dropout reason (Причина выбытия)</summary>
        [DataMember(Name = "dropoutReason", IsRequired = true)]

        public DropoutReportDtoWaterDropoutReason DropoutReason { get; set; }

        /// <summary>Identification Codes that were dropped out (Информация о выбывших КМ)</summary>
        [DataMember(Name = "sntins", IsRequired = true)]
        public List<string> Sntins { get; set; } = new List<string>();


    }

    [DataContract]
    public partial class OMSIdentifier
    {
        /// <summary>Уникальный идентификатор СУЗ</summary>
        [DataMember(Name = "omsId", IsRequired = true)]
        public string OmsID { get; set; }


    }

    [DataContract]
    public partial class OmsApiFieldError
    {
        [DataMember(Name = "errorCode", IsRequired = false)]
        public int? ErrorCode { get; set; }

        [DataMember(Name = "fieldError", IsRequired = false)]
        public string FieldError { get; set; }

        [DataMember(Name = "fieldName", IsRequired = false)]
        public string FieldName { get; set; }


    }

    [DataContract]
    public partial class OmsApiGlobalError
    {
        [DataMember(Name = "error", IsRequired = false)]
        public string Error { get; set; }

        [DataMember(Name = "errorCode", IsRequired = false)]
        public int? ErrorCode { get; set; }


    }

    [DataContract]
    public partial class OmsRestResult
    {
        [DataMember(Name = "fieldErrors", IsRequired = false)]
        public List<OmsApiFieldError> FieldErrors { get; set; }

        [DataMember(Name = "globalErrors", IsRequired = false)]
        public List<OmsApiGlobalError> GlobalErrors { get; set; }

        [DataMember(Name = "success", IsRequired = false)]
        public bool? Success { get; set; }


    }

    [DataContract]
    public partial class Order_Bicycle
    {
        /// <summary>Contact Person (Контактное лицо)</summary>
        [DataMember(Name = "contactPerson", IsRequired = false)]
        public string ContactPerson { get; set; }

        /// <summary>Marking Manufacturing Type (Способ изготовления)</summary>
        [DataMember(Name = "createMethodType", IsRequired = true)]

        public OrderDtoBicycleCreateMethodType CreateMethodType { get; set; }

        /// <summary>Production Order ID (Идентификатор производственного заказа)</summary>
        [DataMember(Name = "productionOrderId", IsRequired = false)]
        public string ProductionOrderID { get; set; }

        /// <summary>Product list (Список товаров)</summary>
        [DataMember(Name = "products", IsRequired = true)]
        public List<OrderProduct_Bicycle> Products { get; set; } = new List<OrderProduct_Bicycle>();

        /// <summary>Product Release Type (Способ выпуска товаров в оборот)</summary>
        [DataMember(Name = "releaseMethodType", IsRequired = true)]

        public OrderDtoBicycleReleaseMethodType ReleaseMethodType { get; set; }

        [DataMember(Name = "serviceProviderId", IsRequired = false)]
        public string ServiceProviderID { get; set; }


    }

    [DataContract]
    public partial class Order_Light
    {
        /// <summary>Contact Person (Контактное лицо)</summary>
        [DataMember(Name = "contactPerson", IsRequired = false)]
        public string ContactPerson { get; set; }

        /// <summary>Marking Manufacturing Type (Способ изготовления)</summary>
        [DataMember(Name = "createMethodType", IsRequired = true)]

        public OrderDtoLightCreateMethodType CreateMethodType { get; set; }

        /// <summary>Production Order ID (Идентификатор производственного заказа)</summary>
        [DataMember(Name = "productionOrderId", IsRequired = false)]
        public string ProductionOrderID { get; set; }

        /// <summary>Product list (Список товаров)</summary>
        [DataMember(Name = "products", IsRequired = true)]
        public List<OrderProduct_Fashion> Products { get; set; } = new List<OrderProduct_Fashion>();

        /// <summary>Product Release Type (Способ выпуска товаров в оборот)</summary>
        [DataMember(Name = "releaseMethodType", IsRequired = true)]

        public OrderDtoLightReleaseMethodType ReleaseMethodType { get; set; }

        /// <summary>Признак того, что товар произведен/приобретен до даты запрета оборота немаркированных товаров по данной ТГ</summary>
        [DataMember(Name = "remainsAvailable", IsRequired = false)]
        public bool? RemainsAvailable { get; set; }

        [DataMember(Name = "serviceProviderId", IsRequired = false)]
        public string ServiceProviderID { get; set; }


    }

    [DataContract]
    public partial class Order_Lp
    {
        /// <summary>Contact Person (Контактное лицо)</summary>
        [DataMember(Name = "contactPerson", IsRequired = false)]
        public string ContactPerson { get; set; }

        /// <summary>Marking Manufacturing Type (Способ изготовления)</summary>
        [DataMember(Name = "createMethodType", IsRequired = true)]

        public OrderDtoLpCreateMethodType CreateMethodType { get; set; }

        /// <summary>Production Order ID (Идентификатор производственного заказа)</summary>
        [DataMember(Name = "productionOrderId", IsRequired = false)]
        public string ProductionOrderID { get; set; }

        /// <summary>Product list (Список товаров)</summary>
        [DataMember(Name = "products", IsRequired = true)]
        public List<OrderProduct_Fashion> Products { get; set; } = new List<OrderProduct_Fashion>();

        /// <summary>Product Release Type (Способ выпуска товаров в оборот)</summary>
        [DataMember(Name = "releaseMethodType", IsRequired = true)]

        public OrderDtoLpReleaseMethodType ReleaseMethodType { get; set; }

        /// <summary>Признак того, что товар произведен/приобретен до даты запрета оборота немаркированных товаров по данной ТГ</summary>
        [DataMember(Name = "remainsAvailable", IsRequired = false)]
        public bool? RemainsAvailable { get; set; }

        [DataMember(Name = "serviceProviderId", IsRequired = false)]
        public string ServiceProviderID { get; set; }


    }

    [DataContract]
    public partial class Order_Milk
    {
        /// <summary>Contact Person (Контактное лицо)</summary>
        [DataMember(Name = "contactPerson", IsRequired = false)]
        public string ContactPerson { get; set; }

        /// <summary>Marking Manufacturing Type (Способ изготовления)</summary>
        [DataMember(Name = "createMethodType", IsRequired = true)]

        public OrderDtoMilkCreateMethodType CreateMethodType { get; set; }

        /// <summary>Production Order ID (Идентификатор производственного заказа)</summary>
        [DataMember(Name = "productionOrderId", IsRequired = false)]
        public string ProductionOrderID { get; set; }

        /// <summary>Product list (Список товаров)</summary>
        [DataMember(Name = "products", IsRequired = true)]
        public List<OrderProduct_Milk> Products { get; set; } = new List<OrderProduct_Milk>();

        /// <summary>Product Release Type (Способ выпуска товаров в оборот)</summary>
        [DataMember(Name = "releaseMethodType", IsRequired = true)]

        public OrderDtoMilkReleaseMethodType ReleaseMethodType { get; set; }

        [DataMember(Name = "serviceProviderId", IsRequired = false)]
        public string ServiceProviderID { get; set; }


    }

    [DataContract]
    public partial class Order_Ncp
    {
        /// <summary>Expected Start Date (Дата начала производства продукции по данному заказу)</summary>
        [DataMember(Name = "expectedStartDate", IsRequired = false)]
        public string ExpectedStartDate { get; set; }

        /// <summary>Factory Address (Адрес производства)</summary>
        [DataMember(Name = "factoryAddress", IsRequired = false)]
        public string FactoryAddress { get; set; }

        /// <summary>Factory Country (Страна производителя)</summary>
        [DataMember(Name = "factoryCountry", IsRequired = true)]
        public string FactoryCountry { get; set; }

        /// <summary>Factory Identifier (GLN) Идентификатор производства. (Глобальный номер места нахождения)</summary>
        [DataMember(Name = "factoryId", IsRequired = true)]
        public string FactoryID { get; set; }

        /// <summary>Factory Name (Наименование производства)</summary>
        [DataMember(Name = "factoryName", IsRequired = false)]
        public string FactoryName { get; set; }

        /// <summary>PO Number (Номер производственного заказа)</summary>
        [DataMember(Name = "poNumber", IsRequired = false)]
        public string PoNumber { get; set; }

        /// <summary>Product Code SKU (Код продукта)</summary>
        [DataMember(Name = "productCode", IsRequired = true)]
        public string ProductCode { get; set; }

        /// <summary>Product Description (Описание продукта)</summary>
        [DataMember(Name = "productDescription", IsRequired = true)]
        public string ProductDescription { get; set; }

        /// <summary>Line Identifier (Идентификатор производственной линии)</summary>
        [DataMember(Name = "productionLineId", IsRequired = true)]
        public string ProductionLineID { get; set; }

        /// <summary>Product list (Список товаров)</summary>
        [DataMember(Name = "products", IsRequired = true)]
        public List<OrderProduct_Ncp> Products { get; set; } = new List<OrderProduct_Ncp>();

        /// <summary>Product Release Type (Способ выпуска товаров в оборот)</summary>
        [DataMember(Name = "releaseMethodType", IsRequired = true)]

        public OrderDtoNcpReleaseMethodType ReleaseMethodType { get; set; }

        [DataMember(Name = "serviceProviderId", IsRequired = false)]
        public string ServiceProviderID { get; set; }


    }

    [DataContract]
    public partial class Order_Otp
    {
        /// <summary>Contact Person (Контактное лицо)</summary>
        [DataMember(Name = "contactPerson", IsRequired = false)]
        public string ContactPerson { get; set; }

        /// <summary>Marking Manufacturing Type (Способ изготовления)</summary>
        [DataMember(Name = "createMethodType", IsRequired = true)]

        public OrderDtoOtpCreateMethodType CreateMethodType { get; set; }

        /// <summary>Start date for the production of this order (Дата начала производства продукции по данному заказу)</summary>
        [DataMember(Name = "expectedStartDate", IsRequired = false)]
        public string ExpectedStartDate { get; set; }

        /// <summary>Manufacturer's address (Адрес производства)</summary>
        [DataMember(Name = "factoryAddress", IsRequired = false)]
        public string FactoryAddress { get; set; }

        /// <summary>Country of origin (Страна производителя)</summary>
        [DataMember(Name = "factoryCountry", IsRequired = true)]
        public string FactoryCountry { get; set; }

        /// <summary>Production identifier (Global Location Number) (Идентификатор производства (Глобальный номер места нахождения))</summary>
        [DataMember(Name = "factoryId", IsRequired = true)]
        public string FactoryID { get; set; }

        /// <summary>Name of production (Наименование производства)</summary>
        [DataMember(Name = "factoryName", IsRequired = false)]
        public string FactoryName { get; set; }

        /// <summary>Production order number (Номер производственного заказа)</summary>
        [DataMember(Name = "poNumber", IsRequired = false)]
        public string PoNumber { get; set; }

        /// <summary>Product code (SKU) (Код продукта (SKU))</summary>
        [DataMember(Name = "productCode", IsRequired = true)]
        public string ProductCode { get; set; }

        /// <summary>Product description (Описание продукта)</summary>
        [DataMember(Name = "productDescription", IsRequired = true)]
        public string ProductDescription { get; set; }

        /// <summary>Production line identifier (Идентификатор производственной линии)</summary>
        [DataMember(Name = "productionLineId", IsRequired = true)]
        public string ProductionLineID { get; set; }

        /// <summary>Production Order ID (Идентификатор производственного заказа)</summary>
        [DataMember(Name = "productionOrderId", IsRequired = false)]
        public string ProductionOrderID { get; set; }

        /// <summary>Product list (Список товаров)</summary>
        [DataMember(Name = "products", IsRequired = true)]
        public List<OrderProduct_Otp> Products { get; set; } = new List<OrderProduct_Otp>();

        /// <summary>Product Release Type (Способ выпуска товаров в оборот)</summary>
        [DataMember(Name = "releaseMethodType", IsRequired = true)]

        public OrderDtoOtpReleaseMethodType ReleaseMethodType { get; set; }

        [DataMember(Name = "serviceProviderId", IsRequired = false)]
        public string ServiceProviderID { get; set; }


    }

    [DataContract]
    public partial class Order_Perfum
    {
        /// <summary>Contact Person (Контактное лицо)</summary>
        [DataMember(Name = "contactPerson", IsRequired = false)]
        public string ContactPerson { get; set; }

        /// <summary>Marking Manufacturing Type (Способ изготовления)</summary>
        [DataMember(Name = "createMethodType", IsRequired = true)]

        public OrderDtoPerfumCreateMethodType CreateMethodType { get; set; }

        /// <summary>Production Order ID (Идентификатор производственного заказа)</summary>
        [DataMember(Name = "productionOrderId", IsRequired = false)]
        public string ProductionOrderID { get; set; }

        /// <summary>Product list (Список товаров)</summary>
        [DataMember(Name = "products", IsRequired = true)]
        public List<OrderProduct_Perfum> Products { get; set; } = new List<OrderProduct_Perfum>();

        /// <summary>Product Release Type (Способ выпуска товаров в оборот)</summary>
        [DataMember(Name = "releaseMethodType", IsRequired = true)]

        public OrderDtoPerfumReleaseMethodType ReleaseMethodType { get; set; }

        [DataMember(Name = "serviceProviderId", IsRequired = false)]
        public string ServiceProviderID { get; set; }


    }

    [DataContract]
    public partial class Order_Pharma
    {
        /// <summary>Is code emission free (Признак оплаты эмиссии КМ: true - не подлежит оплате, false - подлежит оплате (значение по умолчанию)</summary>
        [DataMember(Name = "freeCode", IsRequired = false)]
        public bool? FreeCode { get; set; }

        /// <summary>Payment Type (Тип оплаты: 1 - Оплата по эмиссии, 2 - Оплата по нанесению (значение по умолчанию)</summary>
        [DataMember(Name = "paymentType", IsRequired = false)]
        public OrderDtoPharmaPaymentType? PaymentType { get; set; }

        /// <summary>Product list (Список товаров)</summary>
        [DataMember(Name = "products", IsRequired = true)]
        public List<OrderProduct_Pharma> Products { get; set; } = new List<OrderProduct_Pharma>();

        [DataMember(Name = "serviceProviderId", IsRequired = false)]
        public string ServiceProviderID { get; set; }

        /// <summary>Subject ID (Субъект обращения)</summary>
        [DataMember(Name = "subjectId", IsRequired = true)]
        public string SubjectID { get; set; }


    }

    [DataContract]
    public partial class Order_Photo
    {
        /// <summary>Contact Person (Контактное лицо)</summary>
        [DataMember(Name = "contactPerson", IsRequired = false)]
        public string ContactPerson { get; set; }

        /// <summary>Marking Manufacturing Type (Способ изготовления)</summary>
        [DataMember(Name = "createMethodType", IsRequired = true)]

        public OrderDtoPhotoCreateMethodType CreateMethodType { get; set; }

        /// <summary>Production Order ID (Идентификатор производственного заказа)</summary>
        [DataMember(Name = "productionOrderId", IsRequired = false)]
        public string ProductionOrderID { get; set; }

        /// <summary>Product list (Список товаров)</summary>
        [DataMember(Name = "products", IsRequired = true)]
        public List<OrderProduct_Photo> Products { get; set; } = new List<OrderProduct_Photo>();

        /// <summary>Product Release Type (Способ выпуска товаров в оборот)</summary>
        [DataMember(Name = "releaseMethodType", IsRequired = true)]

        public OrderDtoPhotoReleaseMethodType ReleaseMethodType { get; set; }

        [DataMember(Name = "serviceProviderId", IsRequired = false)]
        public string ServiceProviderID { get; set; }


    }

    [DataContract]
    public partial class Order_Shoes
    {
        /// <summary>Contact Person (Контактное лицо)</summary>
        [DataMember(Name = "contactPerson", IsRequired = false)]
        public string ContactPerson { get; set; }

        /// <summary>Marking Manufacturing Type (Способ изготовления)</summary>
        [DataMember(Name = "createMethodType", IsRequired = true)]

        public OrderDtoShoesCreateMethodType CreateMethodType { get; set; }

        /// <summary>Production Order ID (Идентификатор производственного заказа)</summary>
        [DataMember(Name = "productionOrderId", IsRequired = false)]
        public string ProductionOrderID { get; set; }

        /// <summary>Product list (Список товаров)</summary>
        [DataMember(Name = "products", IsRequired = true)]
        public List<OrderProduct_Fashion> Products { get; set; } = new List<OrderProduct_Fashion>();

        /// <summary>Product Release Type (Способ выпуска товаров в оборот)</summary>
        [DataMember(Name = "releaseMethodType", IsRequired = true)]

        public OrderDtoShoesReleaseMethodType ReleaseMethodType { get; set; }

        /// <summary>Признак того, что товар произведен/приобретен до даты запрета оборота немаркированных товаров по данной ТГ</summary>
        [DataMember(Name = "remainsAvailable", IsRequired = false)]
        public bool? RemainsAvailable { get; set; }

        [DataMember(Name = "serviceProviderId", IsRequired = false)]
        public string ServiceProviderID { get; set; }


    }

    [DataContract]
    public partial class Order_Tires
    {
        /// <summary>Contact Person (Контактное лицо)</summary>
        [DataMember(Name = "contactPerson", IsRequired = false)]
        public string ContactPerson { get; set; }

        /// <summary>Marking Manufacturing Type (Способ изготовления)</summary>
        [DataMember(Name = "createMethodType", IsRequired = true)]

        public OrderDtoTiresCreateMethodType CreateMethodType { get; set; }

        /// <summary>Production Order ID (Идентификатор производственного заказа)</summary>
        [DataMember(Name = "productionOrderId", IsRequired = false)]
        public string ProductionOrderID { get; set; }

        /// <summary>Product list (Список товаров)</summary>
        [DataMember(Name = "products", IsRequired = true)]
        public List<OrderProduct_Tires> Products { get; set; } = new List<OrderProduct_Tires>();

        /// <summary>Product Release Type (Способ выпуска товаров в оборот)</summary>
        [DataMember(Name = "releaseMethodType", IsRequired = true)]

        public OrderDtoTiresReleaseMethodType ReleaseMethodType { get; set; }

        [DataMember(Name = "serviceProviderId", IsRequired = false)]
        public string ServiceProviderID { get; set; }


    }

    [DataContract]
    public partial class Order_Tobacco
    {
        /// <summary>Expected Start Date (Ожидаемая дата начала)</summary>
        [DataMember(Name = "expectedStartDate", IsRequired = false)]
        public string ExpectedStartDate { get; set; }

        /// <summary>Factory Address (Адрес производства)</summary>
        [DataMember(Name = "factoryAddress", IsRequired = false)]
        public string FactoryAddress { get; set; }

        /// <summary>Factory Country (Страна производителя)</summary>
        [DataMember(Name = "factoryCountry", IsRequired = true)]
        public string FactoryCountry { get; set; }

        /// <summary>Factory Identifier (GLN) Идентификатор производства. (Глобальный номер места нахождения)</summary>
        [DataMember(Name = "factoryId", IsRequired = true)]
        public string FactoryID { get; set; }

        /// <summary>Factory Name (Наименование производства)</summary>
        [DataMember(Name = "factoryName", IsRequired = false)]
        public string FactoryName { get; set; }

        /// <summary>PO Number (Номер заказа)</summary>
        [DataMember(Name = "poNumber", IsRequired = false)]
        public string PoNumber { get; set; }

        /// <summary>Product Code (Код продукта)</summary>
        [DataMember(Name = "productCode", IsRequired = true)]
        public string ProductCode { get; set; }

        /// <summary>Product Description (Описание продукта)</summary>
        [DataMember(Name = "productDescription", IsRequired = true)]
        public string ProductDescription { get; set; }

        /// <summary>Line Identifier (Идентификатор производственной линии)</summary>
        [DataMember(Name = "productionLineId", IsRequired = true)]
        public string ProductionLineID { get; set; }

        /// <summary>Product list (Список товаров)</summary>
        [DataMember(Name = "products", IsRequired = true)]
        public List<OrderProduct_Tobacco> Products { get; set; } = new List<OrderProduct_Tobacco>();

        [DataMember(Name = "serviceProviderId", IsRequired = false)]
        public string ServiceProviderID { get; set; }


    }

    [DataContract]
    public partial class Order_Water
    {
        /// <summary>Contact Person (Контактное лицо)</summary>
        [DataMember(Name = "contactPerson", IsRequired = false)]
        public string ContactPerson { get; set; }

        /// <summary>Marking Manufacturing Type (Способ изготовления)</summary>
        [DataMember(Name = "createMethodType", IsRequired = true)]

        public OrderDtoWaterCreateMethodType CreateMethodType { get; set; }

        /// <summary>Production Order ID (Идентификатор производственного заказа)</summary>
        [DataMember(Name = "productionOrderId", IsRequired = false)]
        public string ProductionOrderID { get; set; }

        /// <summary>Product list (Список товаров)</summary>
        [DataMember(Name = "products", IsRequired = true)]
        public List<OrderProduct_Water> Products { get; set; } = new List<OrderProduct_Water>();

        /// <summary>Product Release Type (Способ выпуска товаров в оборот)</summary>
        [DataMember(Name = "releaseMethodType", IsRequired = true)]

        public OrderDtoWaterReleaseMethodType ReleaseMethodType { get; set; }

        [DataMember(Name = "serviceProviderId", IsRequired = false)]
        public string ServiceProviderID { get; set; }


    }

    [DataContract]
    public partial class OrderProduct_Bicycle
    {
        /// <summary>Product GTIN (GTIN товара)</summary>
        [DataMember(Name = "gtin", IsRequired = true)]
        public string Gtin { get; set; }

        /// <summary>Requested Identification Code quantity [Required only if serialNumberType = OPERATOR] (Количество КМ [Обязателен, если serialNumberType = SELF_MADE])</summary>
        [DataMember(Name = "quantity", IsRequired = true)]
        public int Quantity { get; set; }

        /// <summary>Serial number source type (Способ формирования индивидуального серийного номера)</summary>
        [DataMember(Name = "serialNumberType", IsRequired = true)]

        public OrderProductBicycleSerialNumberType SerialNumberType { get; set; }

        /// <summary>Serial numbers [Required only if serialNumberType = SELF_MADE] (Список серийных номеров [Обязателен, если serialNumberType = SELF_MADE])</summary>
        [DataMember(Name = "serialNumbers", IsRequired = false)]
        public List<string> SerialNumbers { get; set; }

        /// <summary>Идентификатор этикетки</summary>
        [DataMember(Name = "stickerId", IsRequired = false)]
        public string StickerID { get; set; }

        /// <summary>Identification Code Template ID (Идентификатор шаблона КМ)</summary>
        [DataMember(Name = "templateId", IsRequired = true)]
        public int TemplateID { get; set; }


    }

    [DataContract]
    public partial class OrderProduct_Fashion
    {
        /// <summary>CIS type (Тип КМ)</summary>
        [DataMember(Name = "cisType", IsRequired = false)]

        public OrderProductFashionCisType? CisType { get; set; }

        /// <summary>ИНН/УНБ (или аналог) экспортера</summary>
        [DataMember(Name = "exporterTaxpayerId", IsRequired = false)]
        public string ExporterTaxpayerID { get; set; }

        /// <summary>Product GTIN (GTIN товара)</summary>
        [DataMember(Name = "gtin", IsRequired = true)]
        public string Gtin { get; set; }

        /// <summary>Requested Identification Code quantity [Required only if serialNumberType = OPERATOR] (Количество КМ [Обязателен, если serialNumberType = SELF_MADE])</summary>
        [DataMember(Name = "quantity", IsRequired = true)]
        public int Quantity { get; set; }

        /// <summary>Serial number source type (Способ формирования индивидуального серийного номера)</summary>
        [DataMember(Name = "serialNumberType", IsRequired = true)]

        public OrderProductFashionSerialNumberType SerialNumberType { get; set; }

        /// <summary>Serial numbers [Required only if serialNumberType = SELF_MADE] (Список серийных номеров [Обязателен, если serialNumberType = SELF_MADE])</summary>
        [DataMember(Name = "serialNumbers", IsRequired = false)]
        public List<string> SerialNumbers { get; set; }

        /// <summary>Идентификатор этикетки</summary>
        [DataMember(Name = "stickerId", IsRequired = false)]
        public string StickerID { get; set; }

        /// <summary>Identification Code Template ID (Идентификатор шаблона КМ)</summary>
        [DataMember(Name = "templateId", IsRequired = true)]
        public int TemplateID { get; set; }


    }

    [DataContract]
    public partial class OrderProduct_Milk
    {
        /// <summary>CIS type (Тип КМ)</summary>
        [DataMember(Name = "cisType", IsRequired = false)]

        public OrderProductMilkCisType? CisType { get; set; }

        /// <summary>Expiry date of the product (expiration date more than 72 hours) (Дата окончания срока годности продукции (срок хранения более 72 часов))</summary>
        [DataMember(Name = "expDate", IsRequired = false)]
        public string ExpDate { get; set; }

        /// <summary>Expiration date of the product (shelf life less than 72 hours) Дата окончания срока годности продукции (срок хранения менее 72 часов))</summary>
        [DataMember(Name = "expDate72", IsRequired = false)]
        public string ExpDate72 { get; set; }

        /// <summary>ИНН/УНБ (или аналог) экспортера</summary>
        [DataMember(Name = "exporterTaxpayerId", IsRequired = false)]
        public string ExporterTaxpayerID { get; set; }

        /// <summary>Product GTIN (GTIN товара)</summary>
        [DataMember(Name = "gtin", IsRequired = true)]
        public string Gtin { get; set; }

        /// <summary>Requested Identification Code quantity [Required only if serialNumberType = OPERATOR] (Количество КМ [Обязателен, если serialNumberType = SELF_MADE])</summary>
        [DataMember(Name = "quantity", IsRequired = true)]
        public int Quantity { get; set; }

        /// <summary>Serial number source type (Способ формирования индивидуального серийного номера)</summary>
        [DataMember(Name = "serialNumberType", IsRequired = true)]

        public OrderProductMilkSerialNumberType SerialNumberType { get; set; }

        /// <summary>Serial numbers [Required only if serialNumberType = SELF_MADE] (Список серийных номеров [Обязателен, если serialNumberType = SELF_MADE])</summary>
        [DataMember(Name = "serialNumbers", IsRequired = false)]
        public List<string> SerialNumbers { get; set; }

        /// <summary>Идентификатор этикетки</summary>
        [DataMember(Name = "stickerId", IsRequired = false)]
        public string StickerID { get; set; }

        /// <summary>Identification Code Template ID (Идентификатор шаблона КМ)</summary>
        [DataMember(Name = "templateId", IsRequired = true)]
        public int TemplateID { get; set; }


    }

    [DataContract]
    public partial class OrderProduct_Ncp
    {
        /// <summary>Product GTIN (GTIN товара)</summary>
        [DataMember(Name = "gtin", IsRequired = true)]
        public string Gtin { get; set; }

        /// <summary>Requested Identification Code quantity [Required only if serialNumberType = OPERATOR] (Количество КМ [Обязателен, если serialNumberType = SELF_MADE])</summary>
        [DataMember(Name = "quantity", IsRequired = true)]
        public int Quantity { get; set; }

        /// <summary>Serial number source type (Способ формирования индивидуального серийного номера)</summary>
        [DataMember(Name = "serialNumberType", IsRequired = true)]

        public OrderProductNcpSerialNumberType SerialNumberType { get; set; }

        /// <summary>Serial numbers [Required only if serialNumberType = SELF_MADE] (Список серийных номеров [Обязателен, если serialNumberType = SELF_MADE])</summary>
        [DataMember(Name = "serialNumbers", IsRequired = false)]
        public List<string> SerialNumbers { get; set; }

        /// <summary>Идентификатор этикетки</summary>
        [DataMember(Name = "stickerId", IsRequired = false)]
        public string StickerID { get; set; }

        /// <summary>Identification Code Template ID (Идентификатор шаблона КМ)</summary>
        [DataMember(Name = "templateId", IsRequired = true)]
        public int TemplateID { get; set; }


    }

    [DataContract]
    public partial class OrderProduct_Otp
    {
        /// <summary>CIS type (Тип КМ)</summary>
        [DataMember(Name = "cisType", IsRequired = false)]

        public OrderProductOtpCisType? CisType { get; set; }

        /// <summary>Product GTIN (GTIN товара)</summary>
        [DataMember(Name = "gtin", IsRequired = true)]
        public string Gtin { get; set; }

        /// <summary>Maximum retail price (Максимальная розничная цена)</summary>
        [DataMember(Name = "mrp", IsRequired = false)]
        public string Mrp { get; set; }

        /// <summary>Requested Identification Code quantity [Required only if serialNumberType = OPERATOR] (Количество КМ [Обязателен, если serialNumberType = SELF_MADE])</summary>
        [DataMember(Name = "quantity", IsRequired = true)]
        public int Quantity { get; set; }

        /// <summary>Serial number source type (Способ формирования индивидуального серийного номера)</summary>
        [DataMember(Name = "serialNumberType", IsRequired = true)]

        public OrderProductOtpSerialNumberType SerialNumberType { get; set; }

        /// <summary>Serial numbers [Required only if serialNumberType = SELF_MADE] (Список серийных номеров [Обязателен, если serialNumberType = SELF_MADE])</summary>
        [DataMember(Name = "serialNumbers", IsRequired = false)]
        public List<string> SerialNumbers { get; set; }

        /// <summary>Идентификатор этикетки</summary>
        [DataMember(Name = "stickerId", IsRequired = false)]
        public string StickerID { get; set; }

        /// <summary>Identification Code Template ID (Идентификатор шаблона КМ)</summary>
        [DataMember(Name = "templateId", IsRequired = true)]
        public int TemplateID { get; set; }


    }

    [DataContract]
    public partial class OrderProduct_Perfum
    {
        /// <summary>CIS type (Тип КМ)</summary>
        [DataMember(Name = "cisType", IsRequired = false)]

        public OrderProductPerfumCisType? CisType { get; set; }

        /// <summary>ИНН/УНБ (или аналог) экспортера</summary>
        [DataMember(Name = "exporterTaxpayerId", IsRequired = false)]
        public string ExporterTaxpayerID { get; set; }

        /// <summary>Product GTIN (GTIN товара)</summary>
        [DataMember(Name = "gtin", IsRequired = true)]
        public string Gtin { get; set; }

        /// <summary>Requested Identification Code quantity [Required only if serialNumberType = OPERATOR] (Количество КМ [Обязателен, если serialNumberType = SELF_MADE])</summary>
        [DataMember(Name = "quantity", IsRequired = true)]
        public int Quantity { get; set; }

        /// <summary>Serial number source type (Способ формирования индивидуального серийного номера)</summary>
        [DataMember(Name = "serialNumberType", IsRequired = true)]

        public OrderProductPerfumSerialNumberType SerialNumberType { get; set; }

        /// <summary>Serial numbers [Required only if serialNumberType = SELF_MADE] (Список серийных номеров [Обязателен, если serialNumberType = SELF_MADE])</summary>
        [DataMember(Name = "serialNumbers", IsRequired = false)]
        public List<string> SerialNumbers { get; set; }

        /// <summary>Идентификатор этикетки</summary>
        [DataMember(Name = "stickerId", IsRequired = false)]
        public string StickerID { get; set; }

        /// <summary>Identification Code Template ID (Идентификатор шаблона КМ)</summary>
        [DataMember(Name = "templateId", IsRequired = true)]
        public int TemplateID { get; set; }


    }

    [DataContract]
    public partial class OrderProduct_Pharma
    {
        /// <summary>Product GTIN (GTIN товара)</summary>
        [DataMember(Name = "gtin", IsRequired = true)]
        public string Gtin { get; set; }

        /// <summary>Requested Identification Code quantity [Required only if serialNumberType = OPERATOR] (Количество КМ [Обязателен, если serialNumberType = SELF_MADE])</summary>
        [DataMember(Name = "quantity", IsRequired = true)]
        public int Quantity { get; set; }

        /// <summary>Serial number source type (Способ формирования индивидуального серийного номера)</summary>
        [DataMember(Name = "serialNumberType", IsRequired = true)]

        public OrderProductPharmaSerialNumberType SerialNumberType { get; set; }

        /// <summary>Serial numbers [Required only if serialNumberType = SELF_MADE] (Список серийных номеров [Обязателен, если serialNumberType = SELF_MADE])</summary>
        [DataMember(Name = "serialNumbers", IsRequired = false)]
        public List<string> SerialNumbers { get; set; }

        /// <summary>Идентификатор этикетки</summary>
        [DataMember(Name = "stickerId", IsRequired = false)]
        public string StickerID { get; set; }

        /// <summary>Identification Code Template ID (Идентификатор шаблона КМ)</summary>
        [DataMember(Name = "templateId", IsRequired = true)]
        public int TemplateID { get; set; }


    }

    [DataContract]
    public partial class OrderProduct_Photo
    {
        /// <summary>CIS type (Тип КМ)</summary>
        [DataMember(Name = "cisType", IsRequired = false)]

        public OrderProductPhotoCisType? CisType { get; set; }

        /// <summary>ИНН/УНБ (или аналог) экспортера</summary>
        [DataMember(Name = "exporterTaxpayerId", IsRequired = false)]
        public string ExporterTaxpayerID { get; set; }

        /// <summary>Product GTIN (GTIN товара)</summary>
        [DataMember(Name = "gtin", IsRequired = true)]
        public string Gtin { get; set; }

        /// <summary>Requested Identification Code quantity [Required only if serialNumberType = OPERATOR] (Количество КМ [Обязателен, если serialNumberType = SELF_MADE])</summary>
        [DataMember(Name = "quantity", IsRequired = true)]
        public int Quantity { get; set; }

        /// <summary>Serial number source type (Способ формирования индивидуального серийного номера)</summary>
        [DataMember(Name = "serialNumberType", IsRequired = true)]

        public OrderProductPhotoSerialNumberType SerialNumberType { get; set; }

        /// <summary>Serial numbers [Required only if serialNumberType = SELF_MADE] (Список серийных номеров [Обязателен, если serialNumberType = SELF_MADE])</summary>
        [DataMember(Name = "serialNumbers", IsRequired = false)]
        public List<string> SerialNumbers { get; set; }

        /// <summary>Идентификатор этикетки</summary>
        [DataMember(Name = "stickerId", IsRequired = false)]
        public string StickerID { get; set; }

        /// <summary>Identification Code Template ID (Идентификатор шаблона КМ)</summary>
        [DataMember(Name = "templateId", IsRequired = true)]
        public int TemplateID { get; set; }


    }

    [DataContract]
    public partial class OrderProduct_Tires
    {
        /// <summary>ИНН/УНБ (или аналог) экспортера</summary>
        [DataMember(Name = "exporterTaxpayerId", IsRequired = false)]
        public string ExporterTaxpayerID { get; set; }

        /// <summary>Product GTIN (GTIN товара)</summary>
        [DataMember(Name = "gtin", IsRequired = true)]
        public string Gtin { get; set; }

        /// <summary>Requested Identification Code quantity [Required only if serialNumberType = OPERATOR] (Количество КМ [Обязателен, если serialNumberType = SELF_MADE])</summary>
        [DataMember(Name = "quantity", IsRequired = true)]
        public int Quantity { get; set; }

        /// <summary>Serial number source type (Способ формирования индивидуального серийного номера)</summary>
        [DataMember(Name = "serialNumberType", IsRequired = true)]

        public OrderProductTiresSerialNumberType SerialNumberType { get; set; }

        /// <summary>Serial numbers [Required only if serialNumberType = SELF_MADE] (Список серийных номеров [Обязателен, если serialNumberType = SELF_MADE])</summary>
        [DataMember(Name = "serialNumbers", IsRequired = false)]
        public List<string> SerialNumbers { get; set; }

        /// <summary>Идентификатор этикетки</summary>
        [DataMember(Name = "stickerId", IsRequired = false)]
        public string StickerID { get; set; }

        /// <summary>Identification Code Template ID (Идентификатор шаблона КМ)</summary>
        [DataMember(Name = "templateId", IsRequired = true)]
        public int TemplateID { get; set; }


    }

    [DataContract]
    public partial class OrderProduct_Tobacco
    {
        /// <summary>Product GTIN (GTIN товара)</summary>
        [DataMember(Name = "gtin", IsRequired = true)]
        public string Gtin { get; set; }

        /// <summary>Maximum retail price (Максимальная розничная цена)</summary>
        [DataMember(Name = "mrp", IsRequired = true)]
        public string Mrp { get; set; }

        /// <summary>Requested Identification Code quantity [Required only if serialNumberType = OPERATOR] (Количество КМ [Обязателен, если serialNumberType = SELF_MADE])</summary>
        [DataMember(Name = "quantity", IsRequired = true)]
        public int Quantity { get; set; }

        /// <summary>Serial number source type (Способ формирования индивидуального серийного номера)</summary>
        [DataMember(Name = "serialNumberType", IsRequired = true)]

        public OrderProductTobaccoSerialNumberType SerialNumberType { get; set; }

        /// <summary>Serial numbers [Required only if serialNumberType = SELF_MADE] (Список серийных номеров [Обязателен, если serialNumberType = SELF_MADE])</summary>
        [DataMember(Name = "serialNumbers", IsRequired = false)]
        public List<string> SerialNumbers { get; set; }

        /// <summary>Идентификатор этикетки</summary>
        [DataMember(Name = "stickerId", IsRequired = false)]
        public string StickerID { get; set; }

        /// <summary>Identification Code Template ID (Идентификатор шаблона КМ)</summary>
        [DataMember(Name = "templateId", IsRequired = true)]
        public int TemplateID { get; set; }


    }

    [DataContract]
    public partial class OrderProduct_Water
    {
        /// <summary>CIS type (Тип КМ)</summary>
        [DataMember(Name = "cisType", IsRequired = false)]

        public OrderProductWaterCisType? CisType { get; set; }

        /// <summary>Product GTIN (GTIN товара)</summary>
        [DataMember(Name = "gtin", IsRequired = true)]
        public string Gtin { get; set; }

        /// <summary>Requested Identification Code quantity [Required only if serialNumberType = OPERATOR] (Количество КМ [Обязателен, если serialNumberType = SELF_MADE])</summary>
        [DataMember(Name = "quantity", IsRequired = true)]
        public int Quantity { get; set; }

        /// <summary>Serial number source type (Способ формирования индивидуального серийного номера)</summary>
        [DataMember(Name = "serialNumberType", IsRequired = true)]

        public OrderProductWaterSerialNumberType SerialNumberType { get; set; }

        /// <summary>Serial numbers [Required only if serialNumberType = SELF_MADE] (Список серийных номеров [Обязателен, если serialNumberType = SELF_MADE])</summary>
        [DataMember(Name = "serialNumbers", IsRequired = false)]
        public List<string> SerialNumbers { get; set; }

        /// <summary>Идентификатор этикетки</summary>
        [DataMember(Name = "stickerId", IsRequired = false)]
        public string StickerID { get; set; }

        /// <summary>Identification Code Template ID (Идентификатор шаблона КМ)</summary>
        [DataMember(Name = "templateId", IsRequired = true)]
        public int TemplateID { get; set; }


    }

    [DataContract]
    public partial class OrderProduct_Wheelchairs
    {
        /// <summary>Product GTIN (GTIN товара)</summary>
        [DataMember(Name = "gtin", IsRequired = true)]
        public string Gtin { get; set; }

        /// <summary>Requested Identification Code quantity [Required only if serialNumberType = OPERATOR] (Количество КМ [Обязателен, если serialNumberType = SELF_MADE])</summary>
        [DataMember(Name = "quantity", IsRequired = true)]
        public int Quantity { get; set; }

        /// <summary>Serial number source type (Способ формирования индивидуального серийного номера)</summary>
        [DataMember(Name = "serialNumberType", IsRequired = true)]

        public OrderProductWheelchairsSerialNumberType SerialNumberType { get; set; }

        /// <summary>Serial numbers [Required only if serialNumberType = SELF_MADE] (Список серийных номеров [Обязателен, если serialNumberType = SELF_MADE])</summary>
        [DataMember(Name = "serialNumbers", IsRequired = false)]
        public List<string> SerialNumbers { get; set; }

        /// <summary>Идентификатор этикетки</summary>
        [DataMember(Name = "stickerId", IsRequired = false)]
        public string StickerID { get; set; }

        /// <summary>Identification Code Template ID (Идентификатор шаблона КМ)</summary>
        [DataMember(Name = "templateId", IsRequired = true)]
        public int TemplateID { get; set; }


    }

    [DataContract]
    public partial class OrderResult
    {
        /// <summary>Time of planned order execution in ms (Время планируемого выполнения заказа в мс)</summary>
        [DataMember(Name = "expectedCompleteTimestamp", IsRequired = true)]
        public long ExpectedCompleteTimestamp { get; set; }

        /// <summary>Уникальный идентификатор СУЗ</summary>
        [DataMember(Name = "omsId", IsRequired = true)]
        public string OmsID { get; set; }

        /// <summary>Unique identifier of a business order for issuing MC (Уникальный идентификатор бизнес-заказа на эмиссию КМ)</summary>
        [DataMember(Name = "orderId", IsRequired = true)]
        public string OrderID { get; set; }


    }

    [DataContract]
    public partial class OrderSummaryDto
    {
        /// <summary>Array of buffer status information (Массив информации о статусе буферов)</summary>
        [DataMember(Name = "buffers", IsRequired = false)]
        public List<BufferInfo> Buffers { get; set; }

        /// <summary>Order creation time (Время создания заказа)</summary>
        [DataMember(Name = "createdTimestamp", IsRequired = false)]
        public long? CreatedTimestamp { get; set; }

        /// <summary>Order decline reason (Причина отклонения заказа)</summary>
        [DataMember(Name = "declineReason", IsRequired = false)]
        public string DeclineReason { get; set; }

        /// <summary>Unique OMS Order ID (Идентификатор бизнес-заказа)</summary>
        [DataMember(Name = "orderId", IsRequired = false)]
        public string OrderID { get; set; }

        /// <summary>Business order status (Статус бизнес-заказа)</summary>
        [DataMember(Name = "orderStatus", IsRequired = false)]

        public OrderSummaryDtoOrderStatus? OrderStatus { get; set; }


    }

    [DataContract]
    public partial class OrdersSummaries
    {
        /// <summary>Уникальный идентификатор СУЗ</summary>
        [DataMember(Name = "omsId", IsRequired = true)]
        public string OmsID { get; set; }

        /// <summary>An array of business orders with their statuses (Массив бизнес-заказов с их статусами)</summary>
        [DataMember(Name = "orderInfos", IsRequired = false)]
        public List<OrderSummaryDto> OrderInfos { get; set; }


    }

    [DataContract]
    public partial class PoolInfo
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

        /// <summary>IC array status (Статус пула)</summary>
        [DataMember(Name = "status", IsRequired = true)]

        public PoolInfoStatus Status { get; set; }


    }

    [DataContract]
    public partial class ProductInfo
    {
        [DataMember(Name = "gtin", IsRequired = false)]
        public string Gtin { get; set; }

        [DataMember(Name = "name", IsRequired = false)]
        public string Name { get; set; }


    }

    [DataContract]
    public partial class ProvidersDto
    {
        [DataMember(Name = "providers", IsRequired = false)]
        public List<ProvidersInfo> Providers { get; set; }


    }

    [DataContract]
    public partial class ProvidersInfo
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
        [DataMember(Name = "productGroups", IsRequired = true, ItemConverterType = typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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

    [DataContract]
    public partial class ReceiptDto
    {
        [DataMember(Name = "content", IsRequired = false)]
        public string Content { get; set; }

        [DataMember(Name = "signature", IsRequired = false)]
        public string Signature { get; set; }


    }

    [DataContract]
    public partial class ReceiptsDto
    {
        [DataMember(Name = "receipts", IsRequired = false)]
        public List<ReceiptDto> Receipts { get; set; }


    }

    [DataContract]
    public partial class ReportResult
    {
        /// <summary>Уникальный идентификатор СУЗ</summary>
        [DataMember(Name = "omsId", IsRequired = true)]
        public string OmsID { get; set; }

        /// <summary>Unique OMS Report ID (Уникальный идентификатор отчета в СУЗ)</summary>
        [DataMember(Name = "reportId", IsRequired = false)]
        public string ReportID { get; set; }


    }

    [DataContract]
    public partial class ReportStatusDto
    {
        /// <summary>Причина отклонения отчета (обнаруженная ошибка)</summary>
        [DataMember(Name = "errorReason", IsRequired = false)]
        public string ErrorReason { get; set; }

        /// <summary>Уникальный идентификатор СУЗ</summary>
        [DataMember(Name = "omsId", IsRequired = true)]
        public string OmsID { get; set; }

        /// <summary>Report ID (Идентификатор отчета)</summary>
        [DataMember(Name = "reportId", IsRequired = true)]
        public string ReportID { get; set; }

        /// <summary>Report status (Статус отчета)</summary>
        [DataMember(Name = "reportStatus", IsRequired = true)]

        public ReportStatusDtoReportStatus ReportStatus { get; set; }


    }

    [DataContract]
    public partial class UtilisationReportDtoBeer
    {
        /// <summary>List of Utilized Identification Codes (Информация об использованных КМ)</summary>
        [DataMember(Name = "sntins", IsRequired = true)]
        public List<string> Sntins { get; set; } = new List<string>();

        /// <summary>Usage type (Тип использования)</summary>
        [DataMember(Name = "usageType", IsRequired = true)]

        public UtilisationReportDtoBeerUsageType UsageType { get; set; }


    }

    [DataContract]
    public partial class UtilisationReportDtoBicycle
    {
        /// <summary>List of Utilized Identification Codes (Информация об использованных КМ)</summary>
        [DataMember(Name = "sntins", IsRequired = true)]
        public List<string> Sntins { get; set; } = new List<string>();

        /// <summary>Usage type (Тип использования)</summary>
        [DataMember(Name = "usageType", IsRequired = true)]

        public UtilisationReportDtoBicycleUsageType UsageType { get; set; }


    }

    [DataContract]
    public partial class UtilisationReportDtoLight
    {
        /// <summary>List of Utilized Identification Codes (Информация об использованных КМ)</summary>
        [DataMember(Name = "sntins", IsRequired = true)]
        public List<string> Sntins { get; set; } = new List<string>();

        /// <summary>Usage type (Тип использования)</summary>
        [DataMember(Name = "usageType", IsRequired = true)]

        public UtilisationReportDtoLightUsageType UsageType { get; set; }


    }

    [DataContract]
    public partial class UtilisationReportDtoMilk
    {
        /// <summary>Производственный ветеринарный сопроводительный документ</summary>
        [DataMember(Name = "accompanyingDocument", IsRequired = false)]
        public string AccompanyingDocument { get; set; }

        /// <summary>Capacity/Weight (Объем/Масса)</summary>
        [DataMember(Name = "capacity", IsRequired = false)]
        public double? Capacity { get; set; }

        /// <summary>CIS type (Тип КМ)</summary>
        [DataMember(Name = "cisType", IsRequired = true)]

        public UtilisationReportDtoMilkCisType CisType { get; set; }

        /// <summary>Expiry date of the product (expiration date more than 72 hours) (Дата окончания срока годности продукции (срок хранения более 72 часов))</summary>
        [DataMember(Name = "expDate", IsRequired = false)]
        public string ExpDate { get; set; }

        /// <summary>Expiry date of the product (expiration date more than 72 hours) (Дата окончания срока годности продукции (срок хранения менее 72 часов))</summary>
        [DataMember(Name = "expDate72", IsRequired = false)]
        public string ExpDate72 { get; set; }

        /// <summary>List of Utilized Identification Codes (Информация об использованных КМ)</summary>
        [DataMember(Name = "sntins", IsRequired = true)]
        public List<string> Sntins { get; set; } = new List<string>();

        /// <summary>Usage type (Тип использования)</summary>
        [DataMember(Name = "usageType", IsRequired = true)]

        public UtilisationReportDtoMilkUsageType UsageType { get; set; }

        /// <summary>The indication of use of ICs in production (Признак использовании КМ на производстве)</summary>
        [DataMember(Name = "usedInProduction", IsRequired = false)]
        public int? UsedInProduction { get; set; }


    }

    [DataContract]
    public partial class UtilisationReportDtoNcp
    {
        /// <summary>Product Brand Name (Наименование бренда продукции)</summary>
        [DataMember(Name = "brandcode", IsRequired = false)]
        public string Brandcode { get; set; }

        /// <summary>Production date (Дата производства. Дата указывается с учетом часового пояса. Обозначение даты в соответствии с ГОСТ ИСО 8601–2001)</summary>
        [DataMember(Name = "productionDate", IsRequired = false)]
        public string ProductionDate { get; set; }

        /// <summary>Production line number (Номер производственной линии)</summary>
        [DataMember(Name = "productionLineId", IsRequired = true)]
        public string ProductionLineID { get; set; }

        /// <summary>The Id of the production order (Идентификатор производственного заказа)</summary>
        [DataMember(Name = "productionOrderId", IsRequired = false)]
        public string ProductionOrderID { get; set; }

        /// <summary>List of Utilized Identification Codes (Информация об использованных КМ)</summary>
        [DataMember(Name = "sntins", IsRequired = true)]
        public List<string> Sntins { get; set; } = new List<string>();

        /// <summary>Utilisation report identifier of APCS (Идентификатор отчёта о нанесении АСУТП)</summary>
        [DataMember(Name = "sourceReportId", IsRequired = false)]
        public string SourceReportID { get; set; }

        /// <summary>Usage type (Тип использования)</summary>
        [DataMember(Name = "usageType", IsRequired = true)]

        public UtilisationReportDtoNcpUsageType UsageType { get; set; }


    }

    [DataContract]
    public partial class UtilisationReportDtoOtp
    {
        /// <summary>Наименование бренда продукции</summary>
        [DataMember(Name = "brandcode", IsRequired = false)]
        public string Brandcode { get; set; }

        /// <summary>Идентификатор производственной линии</summary>
        [DataMember(Name = "productionLineId", IsRequired = true)]
        public string ProductionLineID { get; set; }

        /// <summary>Идентификатор производственного заказа</summary>
        [DataMember(Name = "productionOrderId", IsRequired = false)]
        public string ProductionOrderID { get; set; }

        /// <summary>List of Utilized Identification Codes (Информация об использованных КМ)</summary>
        [DataMember(Name = "sntins", IsRequired = true)]
        public List<string> Sntins { get; set; } = new List<string>();

        /// <summary>Идентификатор отчёта о нанесении АСУТП</summary>
        [DataMember(Name = "sourceReportId", IsRequired = false)]
        public string SourceReportID { get; set; }

        /// <summary>Usage type (Тип использования)</summary>
        [DataMember(Name = "usageType", IsRequired = true)]

        public UtilisationReportDtoOtpUsageType UsageType { get; set; }

        /// <summary>The indication of use of ICs in production (Признак использовании КМ на производстве)</summary>
        [DataMember(Name = "usedInProduction", IsRequired = false)]
        public int? UsedInProduction { get; set; }


    }

    [DataContract]
    public partial class UtilisationReportDtoPharma
    {
        /// <summary>The ID of the manufacturer who produced the quality control (36-значный идентификатор, присваиваемый иностранным контрагентам при их регистрации в ФГИС МДЛП держателем регистрационного удостоверения лекарственного препарата (или его представительством))</summary>
        [DataMember(Name = "controlId", IsRequired = false)]
        public string ControlID { get; set; }

        /// <summary>Identifier of the location of goods in the customs control zone (36-значный идентификатор местонахождения товара из реестра мест в зоне таможенного контроля в ФГИС МДЛП)</summary>
        [DataMember(Name = "customsReceiverId", IsRequired = false)]
        public string CustomsReceiverID { get; set; }

        /// <summary>Expiration Data (Дата истечения срока годности)</summary>
        [DataMember(Name = "expirationDate", IsRequired = true)]
        public string ExpirationDate { get; set; }

        /// <summary>Order Type (Тип заказа)</summary>
        [DataMember(Name = "orderType", IsRequired = false)]
        public string OrderType { get; set; }

        /// <summary>Owner Identifier (Идентификатор владельца)</summary>
        [DataMember(Name = "ownerId", IsRequired = false)]
        public string OwnerID { get; set; }

        /// <summary>The ID of the packaging manufacturer (Идентификатор производителя, осуществившего упаковку/фасовку во вторичную (а при ее отсутствии – первичную упаковку)</summary>
        [DataMember(Name = "packingId", IsRequired = false)]
        public string PackingID { get; set; }

        /// <summary>Production dates (Дата производства)</summary>
        [DataMember(Name = "productionDate", IsRequired = false)]
        public string ProductionDate { get; set; }

        /// <summary>Series Number (Номер производственной серии)</summary>
        [DataMember(Name = "seriesNumber", IsRequired = true)]
        public string SeriesNumber { get; set; }

        /// <summary>List of Utilized Identification Codes (Информация об использованных КМ)</summary>
        [DataMember(Name = "sntins", IsRequired = true)]
        public List<string> Sntins { get; set; } = new List<string>();

        /// <summary>Subject ID (Субъект обращения (Идентификатор места деятельности)</summary>
        [DataMember(Name = "subjectId", IsRequired = true)]
        public string SubjectID { get; set; }

        /// <summary>Usage type (Тип использования)</summary>
        [DataMember(Name = "usageType", IsRequired = true)]

        public UtilisationReportDtoPharmaUsageType UsageType { get; set; }


    }

    [DataContract]
    public partial class UtilisationReportDtoTobacco
    {
        /// <summary>Product Brand Name (Наименование бренда продукции)</summary>
        [DataMember(Name = "brandcode", IsRequired = false)]
        public string Brandcode { get; set; }

        /// <summary>Production date (Дата производства. Дата указывается с учетом часового пояса. Обозначение даты в соответствии с ГОСТ ИСО 8601–2001)</summary>
        [DataMember(Name = "productionDate", IsRequired = false)]
        public string ProductionDate { get; set; }

        /// <summary>Production line number (Номер производственной линии)</summary>
        [DataMember(Name = "productionLineId", IsRequired = true)]
        public string ProductionLineID { get; set; }

        /// <summary>The Id of the production order (Идентификатор производственного заказа)</summary>
        [DataMember(Name = "productionOrderId", IsRequired = false)]
        public string ProductionOrderID { get; set; }

        /// <summary>List of Utilized Identification Codes (Информация об использованных КМ)</summary>
        [DataMember(Name = "sntins", IsRequired = true)]
        public List<string> Sntins { get; set; } = new List<string>();

        /// <summary>Utilisation report identifier of APCS (Идентификатор отчёта о нанесении АСУТП)</summary>
        [DataMember(Name = "sourceReportId", IsRequired = false)]
        public string SourceReportID { get; set; }

        /// <summary>Usage type (Тип использования)</summary>
        [DataMember(Name = "usageType", IsRequired = true)]

        public UtilisationReportDtoTobaccoUsageType UsageType { get; set; }


    }

    [DataContract]
    public partial class UtilisationReportDtoWater
    {
        /// <summary>List of Utilized Identification Codes (Информация об использованных КМ)</summary>
        [DataMember(Name = "sntins", IsRequired = true)]
        public List<string> Sntins { get; set; } = new List<string>();

        /// <summary>Usage type (Тип использования)</summary>
        [DataMember(Name = "usageType", IsRequired = true)]

        public UtilisationReportDtoWaterUsageType UsageType { get; set; }

        /// <summary>The indication of use of ICs in production (Признак использовании КМ на производстве)</summary>
        [DataMember(Name = "usedInProduction", IsRequired = false)]
        public int? UsedInProduction { get; set; }


    }

    [DataContract]
    public partial class UtilisationReportDtoWheelchairs
    {
        /// <summary>List of Utilized Identification Codes (Информация об использованных КМ)</summary>
        [DataMember(Name = "sntins", IsRequired = true)]
        public List<string> Sntins { get; set; } = new List<string>();

        /// <summary>Usage type (Тип использования)</summary>
        [DataMember(Name = "usageType", IsRequired = true)]

        public UtilisationReportDtoWheelchairsUsageType UsageType { get; set; }


    }
}
