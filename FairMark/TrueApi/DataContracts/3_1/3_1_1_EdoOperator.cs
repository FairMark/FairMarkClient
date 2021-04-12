namespace FairMark.TrueApi.DataContracts._3_1
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Оператор электронного документооборота.
    /// 3.1.1. Метод создания заявки на регистрацию УОТ
    /// </summary>
    [DataContract(Name = "edo_operators")]
    public partial class EdoOperator
    {
        [DataMember(Name = "edo_operator_name")]
        public string EdoOperatorName { get; set; }

        [DataMember(Name = "edo_participant_id")]
        public string EdoParticipantId { get; set; }

        [DataMember(Name = "is_main_operator")]
        public bool IsMainOperator { get; set; }
    }
}