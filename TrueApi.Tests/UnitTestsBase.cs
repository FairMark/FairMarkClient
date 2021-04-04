namespace FairMark.TrueApi.Tests
{
    using Toolbox;

    public class UnitTestsBase
    {
        public const string TestCertificateSubjectName = "КС"; // "ООО \"БЕЛАЯ МЕБЕЛЬ\"";
        public const string TestCertificateThumbprint = "aa0444c6d47220d9e77558e88c763543cd9773e2";
        public const string OmsID = "f32b7b49-330a-4f12-921b-9c58df009468";
        public const string Token = "2e7491d3-257d-4c69-aac6-0139c030de61"; //"84a1d136-5232-476c-a471-45260ba34e15";

        static UnitTestsBase()
        {
            // make sure that certificates are searched for the current user
            GostCryptoHelpers.DefaultStoreLocation = System.Security.Cryptography.X509Certificates.StoreLocation.CurrentUser;
        }
    }
}