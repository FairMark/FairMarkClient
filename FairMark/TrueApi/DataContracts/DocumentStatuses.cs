using System.Runtime.Serialization;

namespace FairMark.TrueApi.DataContracts
{
    /// <summary>
    /// Справочник TrueApi "Статусы документов"
    /// </summary>
    [DataContract]
    public enum DocumentStatuses
    {
        /// <summary>
        /// Проверяется
        /// </summary>
        [EnumMember(Value = @"IN_PROGRESS")]
        IN_PROGRESS = 0,

        /// <summary>
        /// Обработан
        /// </summary>
        [EnumMember(Value = @"CHECKED_OK")]
        CHECKED_OK = 1,

        /// <summary>
        /// Обработан с ошибками
        /// </summary>
        [EnumMember(Value = @"CHECKED_NOT_OK")]
        CHECKED_NOT_OK = 2,

        /// <summary>
        /// Техническая ошибка
        /// </summary>
        [EnumMember(Value = @"PROCESSING_ERROR")]
        PROCESSING_ERROR = 3,

        /// <summary>
        /// Принят
        /// Примечание: Только для документа "Отгрузка"
        /// </summary>
        [EnumMember(Value = @"ACCEPTED")]
        ACCEPTED = 4,

        /// <summary>
        /// Аннулирован
        /// Примечание: Только для документа "Отгрузка" и документов ЭДО
        /// </summary>
        [EnumMember(Value = @"CANCELLED")]
        CANCELLED = 5,

        /// <summary>
        /// Ожидает приемку
        /// Примечание: Только для документа "Отгрузка". Устанавливается при успешной обработке документа "Отгрузка"
        /// </summary>
        [EnumMember(Value = @"WAIT_ACCEPTANCE")]
        WAIT_ACCEPTANCE = 6,

        /// <summary>
        /// Обработан с ошибками
        /// </summary>
        [EnumMember(Value = @"PARSE_ERROR")]
        PARSE_ERROR = 7,

        /// <summary>
        /// Ожидает регистрации участника в ГИС МТ
        /// Примечание: Только для документа "Отгрузка". Устанавливается при успешной обработке документа "Отгрузка товара" в сторону незарегистрированного участника
        /// </summary>
        [EnumMember(Value = @"WAIT_PARTICIPANT_REGISTRATION")]
        WAIT_PARTICIPANT_REGISTRATION = 8,

        /// <summary>
        /// Ожидает продолжения обработки документа
        /// </summary>
        [EnumMember(Value = @"WAIT_FOR_CONTINUATION")]
        WAIT_FOR_CONTINUATION = 9
    }
}
