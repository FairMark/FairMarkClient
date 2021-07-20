namespace FairMark.TrueApi.DataContracts
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class DocumentInfo
    {
        /// <summary>
        /// Номер документа
        /// </summary>
        [DataMember(Name = "number")]
        public Guid Number { get; set; }

        /// <summary>
        /// Дата и время документа
        /// Примечание: Возвращается в формате yyyy-MM- ddTHH:mm:ss.SSS’Z
        /// </summary>
        [DataMember(Name = "docDate")]
        public DateTime? DocumentDate { get; set; } = null;

        /// <summary>
        /// Дата и время получения документа
        /// Примечание: Возвращается в формате yyyy-MM- ddTHH:mm:ss.SSS’Z
        /// </summary>
        [DataMember(Name = "receivedAt")]
        public string ReceivedAt { get; set; }

        /// <summary>
        /// Тип документа
        /// Примечание: См. Справочник "Типы документов"
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Статус обработки документа
        /// Примечание: См. Справочник "Статусы документов"
        /// </summary>
        [DataMember(Name = "status")]
        public DocumentStatuses? Status { get; set; }

        /// <summary>
        /// ID документа во внешней системе ЭДО
        /// </summary>
        [DataMember(Name = "externalId")]
        public string ExternalId { get; set; }

        /// <summary>
        /// ИНН отправителя документа
        /// </summary>
        [DataMember(Name = "senderInn")]
        public string SenderInn { get; set; }

        /// <summary>
        /// Наименование отправителя документа
        /// </summary>
        [DataMember(Name = "senderName")]
        public string SenderName { get; set; }

        /// <summary>
        /// ИНН получателя документа
        /// </summary>
        [DataMember(Name = "receiverInn")]
        public string ReceiverInn { get; set; }

        /// <summary>
        /// Наименование получателя документа
        /// </summary>
        [DataMember(Name = "receiverName")]
        public string ReceiverName { get; set; }

        /// <summary>
        /// Номер счёта-фактуры, УКД
        /// </summary>
        [DataMember(Name = "invoiceNumber")]
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// Дата счёта-фактуры, УКД
        /// Примечание: Возвращается в формате yyyy-MM- ddTHH:mm:ss.SSS’Z
        /// </summary>
        [DataMember(Name = "invoiceDate")]
        public string InvoiceDate { get; set; }

        /// <summary>
        /// Общая сумма документа
        /// </summary>
        [DataMember(Name = "total")]
        public double Total { get; set; }

        /// <summary>
        /// Сумма НДС документа
        /// </summary>
        [DataMember(Name = "vat")]
        public double Vat { get; set; }

        /// <summary>
        /// Статус загрузки документа
        /// Примечание: См. Справочник "Статусы документов"
        /// </summary>
        [DataMember(Name = "downloadStatus")]
        public DocumentStatuses? DownloadStatus { get; set; }

        /// <summary>
        /// Описание загрузки документа
        /// </summary>
        [DataMember(Name = "downloadDesc")]
        public string DownloadDescription { get; set; }

        /// <summary>
        /// Тело документа
        /// </summary>
        [DataMember(Name = "body")]
        public object Body { get; set; }

        /// <summary>
        /// Содержимое документа
        /// Примечание: Содержимое отправленного документа в формате * .json с набором полей, специфичных для каждого типа документа. См. Справочник "Типы документов"
        /// </summary>
        [DataMember(Name = "content")]
        public string Content { get; set; }

        /// <summary>
        /// Признак того, что документ является входящим/исходящим
        /// Примечание: Возможные значения: true – входящий; false – исходящий
        /// </summary>
        [DataMember(Name = "input")]
        public bool? Input { get; set; } = null;

        /// <summary>
        /// Ссылка на файл в формате * .pdf
        /// </summary>
        [DataMember(Name = "pdfFile")]
        public string PdfFile { get; set; }

        /// <summary>
        /// Ошибки
        /// Примечание: Значение параметра возвращается при наличии ошибки. Если ошибки отсутствуют, то возвращается значение "null". Для УД ошибки в ответе не возвращаются
        /// </summary>
        [DataMember(Name = "errors")]
        public string[] Errors { get; set; }

        /// <summary>
        /// Список ошибок обработки документа
        /// </summary>
        [DataMember(Name = "docErrors")]
        public string[] DocErrors { get; set; }

        /// <summary>
        /// Сообщение об ошибке при обработке документа в формате JSON, XML
        /// Примечание: Параметр возвращается при наличии ошибки только для УД документов (общее описание ошибки по документу)
        /// </summary>
        [DataMember(Name = "errorMessage")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Список сообщений об ошибке при обработке самого документа
        /// Примечание: Параметр возвращается при наличии ошибок
        /// </summary>
        [DataMember(Name = "errorMessages")]
        public string[] ErrorMessages { get; set; }

        /// <summary>
        /// Агрегированный таможенный код
        /// </summary>
        [DataMember(Name = "atk")]
        public string Atk { get; set; }
        /// <summary>
        /// Отправитель
        /// Примечание: Возвращается только для УД
        /// </summary>
        [DataMember(Name = "sender")]
        public SenderInfo Sender { get; set; }
        /// <summary>
        /// Получатель
        /// Примечание: Возвращается только для УД
        /// </summary>
        [DataMember(Name = "receiver")]
        public ReceiverInfo Receiver { get; set; }

    }

    [DataContract]
    public class SenderInfo
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        [DataMember(Name = "address")]
        public string Address { get; set; }
        /// <summary>
        /// ИНН
        /// </summary>
        [DataMember(Name = "inn")]
        public string Inn { get; set; }
        /// <summary>
        /// КПП
        /// Примечание: Код причины постановки на учёт
        /// </summary>
        [DataMember(Name = "kpp")]
        public string Kpp { get; set; }
    }
    [DataContract]
    public class ReceiverInfo
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        [DataMember(Name = "address")]
        public string Address { get; set; }
        /// <summary>
        /// ИНН
        /// </summary>
        [DataMember(Name = "inn")]
        public string Inn { get; set; }
        /// <summary>
        /// КПП
        /// Примечание: Код причины постановки на учёт
        /// </summary>
        [DataMember(Name = "kpp")]
        public string Kpp { get; set; }
    }
}
