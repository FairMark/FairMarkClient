using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using FairMark.OmsApi;
using FairMark.Toolbox;
using FairMark.TrueApi;
using NUnit.Framework;

namespace FairMark.Tests
{
    [TestFixture]
    public class UnitTestsBase
    {
        public const string TestCertificateSubjectName = "КС"; // "ООО \"БЕЛАЯ МЕБЕЛЬ\"";
        public const string TestCertificateThumbprintCopiedFromTheSnapin = "‎aa 04 44 c6 d4 72 20 d9 e7 75 58 e8 8c 76 35 43 cd 97 73 e2";
        public const string TestCertificateThumbprint = "aa0444c6d47220d9e77558e88c763543cd9773e2";
        public const string TestOmsConnectionID = "6242a186-970c-4260-9bd9-b8f19ed66d4d"; // taken from Postman environment, TODO: document where do we get it?
        public const string TestOmsID = "67ad4640-48f4-4eca-886b-517462cf0415"; // "f32b7b49-330a-4f12-921b-9c58df009468";
        public const string TestSettingPath = @"c:\Temp\FairMarkClient";

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

        protected static void WriteLine(string text) => TestContext.Progress.WriteLine(text);

        protected static void WriteLine(string format, params object[] args) => TestContext.Progress.WriteLine(format, args);

        protected static void SaveSetting(string name, string value)
        {
            try
            {
                // Make sure that the CI server reuses
                // the same authentication tokens I'm getting
                // when I'm executing the unit tests manually
                Directory.CreateDirectory(TestSettingPath);

                //using (var store = IsolatedStorageFile.GetUserStoreForAssembly())
                //using (var stream = store.CreateFile(name))
                using (var stream = File.Create(Path.Combine(TestSettingPath, name)))
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(value);
                    WriteLine($"Saved setting {name}: {value}");
                }
            }
            catch (Exception ex)
            {
                WriteLine($"Error writing setting file {name}: {ex}");
            }
        }

        protected static string LoadSetting(string name)
        {
            try
            {
                //using (var store = IsolatedStorageFile.GetUserStoreForAssembly())
                //using (var stream = store.OpenFile(name, FileMode.Open, FileAccess.Read))
                using (var stream = File.OpenRead(Path.Combine(TestSettingPath, name)))
                using (var reader = new StreamReader(stream))
                {
                    var result = reader.ReadToEnd();
                    WriteLine($"Loaded setting {name}: {result}");
                    return result;
                }
            }
            catch (Exception ex)
            {
                WriteLine($"Error loading setting file {name}: {ex.Message}");
                return null;
            }
        }

        protected static void SaveTrueApiToken(string token) => SaveSetting(nameof(TrueApiClient), token);

        protected static string LoadTrueApiToken() => LoadSetting(nameof(TrueApiClient));

        protected static void SaveOmsApiToken(string token) => SaveSetting(nameof(OmsApiClient), token);

        protected static string LoadOmsApiToken() => LoadSetting(nameof(OmsApiClient));
    }
}