using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FairMark.OmsApi.DataContracts
{
    /// <summary>
    /// 4.5.4.1 Метод «Отправить отчёт об использовании (нанесении) КМ»
    /// 4.5.4.1.2 Расширения для фармацевтической промышленности, Таблица 46.
    /// </summary>
    /// <remarks>
    /// Примечание: Значение subjectId (value of subjectId):
    /// 1) при производстве лекарственного препарата на территории Российской
    /// Федерации: 14-значный идентификатор места осуществления деятельности
    /// субъекта обращения согласно лицензии, присвоенный по итогам регистрации
    /// субъектом обращения места осуществления деятельности в ФГИС МДЛП;
    /// 2) при производстве лекарственного препарата вне территории Российской
    /// Федерации: 36-значный номер, присвоенный держателю регистрационного
    /// удостоверения(или его представительству) при его регистрации в ФГИС МДЛП.
    /// Внимание!
    /// 1) При производстве лекарственных препаратов на территории Российской
    /// Федерации:
    /// − Поле orderType является обязательным.Указанное поле должно содержать
    /// числовое значение типа производственного заказа – (1) собственное или(2)
    /// контрактное производство.
    /// − В случае указания orderType = 2 в обязательном порядке должно быть указано
    /// значение поля ownerId - 36-значный номер, присвоенный субъекту обращения,
    /// являющемуся заказчиком контрактного производства, при его регистрации в ФГИС
    /// МДЛП.
    /// − Поля packingId, controlId, customsReceiverId не заполняются.
    /// 2) При производстве лекарственных препаратов вне территории Российской
    /// Федерации:
    /// − Поле packingId является обязательным.Должно содержать
    /// 36-значный идентификатор, присваиваемый иностранным контрагентам при их
    /// регистрации в ФГИС МДЛП держателем регистрационного удостоверения
    /// лекарственного препарата (или его представительством).
    /// − Поле customsReceiverId является необязательным.Поле должно быть
    /// заполнено в случае маркировки лекарственных препаратов в зоне таможенного
    /// контроля. Должно содержать 36-значный идентификатор местонахождения товара
    /// из реестра мест в зоне таможенного контроля в ФГИС МДЛП.
    /// − Поле controlId является необязательным.
    /// Обязательность атрибута controlId наступает при заполненном customsReceiverId,
    /// т.е.поле должно быть заполнено в случае маркировки лекарственных препаратов
    /// в зоне таможенного контроля.
    /// Поле controlId может быть заполнено для производства вне территории РФ даже в
    /// случае, если маркировка осуществляется вне зоны таможенного контроля (поле
    /// при этом является опциональным).
    /// Должно содержать 36-значный идентификатор, присваиваемый иностранным
    /// контрагентам при их регистрации в ФГИС МДЛП держателем регистрационного
    /// удостоверения лекарственного препарата(или его представительством).
    /// − Поля orderType и ownerId не заполняются.
    /// </remarks>
    [DataContract]
    public partial class UtilisationReport_Pharma : UtilisationReport
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

        /// <summary>Subject ID (Субъект обращения (Идентификатор места деятельности)</summary>
        [DataMember(Name = "subjectId", IsRequired = true)]
        public string SubjectID { get; set; }
    }
}
