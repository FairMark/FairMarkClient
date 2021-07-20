namespace FairMark.TrueApi.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class DisaggregationUnit
    {
        /// <summary>
        /// Код расформировываемого агрегата
        /// Примечание: Указание КИН в данном поле недопустимо
        /// </summary>
        [DataMember(Name = "uitu")]
        public string Uitu { get; set; }
    }

}
