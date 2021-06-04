namespace FairMark.TrueApi.DataContracts
{
    using System.Runtime.Serialization;

    public interface IUniformDocumentBase
    {
        string DocumentApiName { get; }
        ProductGroupsTrueApi ProductGroup { get; set; }

    }
    /// <summary>
    /// Uniform document used in TrueApi chapter 4
    /// </summary>
    [DataContract]
    public class UniformDocument
    {
        /// <summary>
        /// Document format. Only "MANUAL"(JSON) format is supported
        /// </summary>
        [DataMember(Name = "document_format")] public string DocumentFormat { get; private set; } = "MANUAL";//TODO Сделать справочником? На данный момент поддерживаем только JSON, поэтому может вообще захордкоидть?

        /// <summary>
        /// Base64-encoded instance of the <see cref="DocumentBase64"/> class.
        /// </summary>
        [DataMember(Name = "product_document")]
        public string DocumentBase64 { get; set; }

        /// <summary>
        /// Detached signature of the original <see cref="DocumentBase64"/> instance.
        /// </summary>
        [DataMember(Name = "signature")]
        public string Signature { get; set; }

        /// <summary>
        /// Код типа документа
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}
