using System.Runtime.Serialization;

namespace FairMark.TrueApiClient.DataContracts
{
    [DataContract]
    public class AuthResponse
    {
        [DataMember(Name = "uuid")]
        public string UUID { get; set; }

        [DataMember(Name = "data")]
        public string Data { get; set; }
    }
}
