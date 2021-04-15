namespace FairMark.TrueApi.Tests
{
    using System;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Security.Cryptography.X509Certificates;
    using FairMark.OmsApi;
    using NUnit.Framework;
    using Toolbox;

    [TestFixture]
    public class UnitTestsBase
    {
        public const string TestCertificateSubjectName = "КС"; // "ООО \"БЕЛАЯ МЕБЕЛЬ\"";
        public const string TestCertificateThumbprintCopiedFromTheSnapin = "‎aa 04 44 c6 d4 72 20 d9 e7 75 58 e8 8c 76 35 43 cd 97 73 e2";
        public const string TestCertificateThumbprint = "aa0444c6d47220d9e77558e88c763543cd9773e2";
        public const string TestOmsConnectionID = "6242a186-970c-4260-9bd9-b8f19ed66d4d"; // taken from Postman environment, TODO: document where do we get it?
        public const string TestOmsID = "67ad4640-48f4-4eca-886b-517462cf0415"; // "f32b7b49-330a-4f12-921b-9c58df009468";
        public const string Token = "2e7491d3-257d-4c69-aac6-0139c030de61"; //"84a1d136-5232-476c-a471-45260ba34e15";

        static UnitTestsBase()
        {
            // detect CI runner environment
            var ci = Environment.GetEnvironmentVariable("GITLAB_CI") != null;
            if (ci)
            {
                TestContext.Progress.WriteLine("Running unit tests on CI server.");
            }

            // for continuous integration: use certificates installed on the local machine
            // for unit tests run inside Visual Studio: use current user's certificates
            GostCryptoHelpers.DefaultStoreLocation = ci ? StoreLocation.LocalMachine : StoreLocation.CurrentUser;
        }

        protected static void SaveSetting(string name, string value)
        {
            try
            {
                using (var store = IsolatedStorageFile.GetUserStoreForAssembly())
                using (var stream = store.CreateFile(name))
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(value);
                    TestContext.Progress.Write($"Saved setting {name}: {value}");
                }
            }
            catch (Exception ex)
            {
                TestContext.Progress.Write($"Error writing setting file {name}: {ex}");
            }
        }

        protected static string LoadSetting(string name)
        {
            try
            {
                using (var store = IsolatedStorageFile.GetUserStoreForAssembly())
                using (var stream = store.OpenFile(name, FileMode.Open, FileAccess.Read))
                using (var reader = new StreamReader(stream))
                {
                    var result = reader.ReadToEnd();
                    TestContext.Progress.Write($"Loaded setting {name}: {result}");
                    return result;
                }
            }
            catch (Exception ex)
            {
                TestContext.Progress.Write($"Error loading setting file {name}: {ex.Message}");
                return null;
            }
        }

        protected static void SaveTrueApiToken(string token) => SaveSetting(nameof(TrueApiClient), token);

        protected static string LoadTrueApiToken() => LoadSetting(nameof(TrueApiClient));

        protected static void SaveOmsApiToken(string token) => SaveSetting(nameof(OmsApiClient), token);

        protected static string LoadOmsApiToken() => LoadSetting(nameof(OmsApiClient));
    }
}