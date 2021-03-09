using FairMark.TrueApi.Toolbox;

namespace FairMark.TrueApi.Tests
{
    public class UnitTestsBase
    {
        public const string TestCertificateSubjectName = "БЕЛАЯ МЕБЕЛЬ"; // "ООО \"БЕЛАЯ МЕБЕЛЬ\"";
        public const string TestCertificateThumbprint = "00442F9C72B36BB247064B9FC6E3F00C398CAFE0";
        public const string OmsID = "f32b7b49-330a-4f12-921b-9c58df009468";
        public const string Token = "2e7491d3-257d-4c69-aac6-0139c030de61"; //"84a1d136-5232-476c-a471-45260ba34e15";

        static UnitTestsBase()
        {
            // make sure that certificates are searched for the current user
            GostCryptoHelpers.DefaultStoreLocation = System.Security.Cryptography.X509Certificates.StoreLocation.CurrentUser;
        }
    }
}