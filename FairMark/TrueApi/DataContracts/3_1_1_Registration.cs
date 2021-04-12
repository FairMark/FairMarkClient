using System.Runtime.Serialization;

namespace FairMark.TrueApi.DataContracts
{
    /// <summary>
    /// Заявка на регистрацию УОТ.
    /// 3.1.1. Метод создания заявки на регистрацию УОТ
    /// </summary>
    [DataContract(Name="registration")]
    public class Registration
    {
        public const string DocumentFormatXml = "XML";
        public const string DocumentFormatManual = "MANUAL";
        public const string DocumentFormatJson = DocumentFormatManual;

        [DataMember(Name = "document_format")]
        public string DocumentFormat { get; set; }

        /// <summary>
        /// Base64-encoded instance of the <see cref="ProductDocument"/> class.
        /// </summary>
        [DataMember(Name = "product_document")]
        public string ProductDocument { get; set; }

        /// <summary>
        /// Detached signature of the original <see cref="ProductDocument"/> instance.
        /// </summary>
        [DataMember(Name = "signature")]
        public string Signature { get; set; }
    }
}
