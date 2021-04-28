using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.EdoLite.DataContracts
{
    /// <summary>
    /// 3.8. Получение списка документов
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    /// outgoingdocuments?limit=40&offset=0&sortBy=created_at&asc=false&created_from=1578430800&created_to=1583010000&partner_inn=0000000000&status=1&type=504&type=800
    /// </remarks>
    public class DocumentListFilter
    {
        /// <summary>
        /// Количество возвращаемых документов 
        /// По умолчанию 10
        /// </summary>
        public int? Limit { get; set; } // limit integer

        /// <summary>
        /// Позиция смещения в наборе результатов для начала нумерации страниц
        /// </summary>
        public int? Offset { get; set; } // offset integer

        /// <summary>
        /// Нижняя граница фильтрации документов по времени создания. В выборку попадут документы, время создания которых больше или равно указанному.
        /// </summary>
        public DateTimeOffset? CreatedFrom { get; set; } // created_from string

        /// <summary>
        /// Верхняя граница фильтрации документов по времени создания. В выборку попадут документы, время создания которых меньше или равно указанному.
        /// </summary>
        public DateTimeOffset? CreatedTo { get; set; } // created_to string

        // TODO:
        // 1. Добавить остальные параметры фильтра
        // 2. Добавить обработку параметров в методе EdoLiteClient.GetParameters(filter)

        // partner_inn string - ИНН контрагента Для исходящего документа это получатель, для входящего - отправитель
        // status integer - Цифровое обозначение статуса возвращаемых документов (см.Справочник "Статусы документов"
        // type integer - Цифровое обозначение типа создаваемых документов (см.Справочник "Типы документов"
        // sortBy string - Параметр, по которому необходимо отсортировать возвращаемый список документов Допустимые значения:
        // created_at - время создания документа (параметр сортировки по умолчанию);
        // date - дата документа;
        // partner_name - контрагент(для исходящего документа это получатель, для входящего - отправитель);
        // type - тип документа (сортировка выполняется не по названию, а по цифровому коду типа);
        // status - статус документа (сортировка выполняется не по названию, а по цифровому коду статуса)
        // asc boolean - Параметр, определяющий направление сортировки. Допустимые значения: false - по убыванию (значение по умолчанию), true - по возрастанию.
    }
}
