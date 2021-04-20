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
    public partial class OMSIdentifier
    {
        /// <summary>Уникальный идентификатор СУЗ</summary>
        [DataMember(Name = "omsId", IsRequired = true)]
        public string OmsID { get; set; }


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

}
