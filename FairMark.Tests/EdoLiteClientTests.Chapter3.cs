using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairMark.EdoLite;
using FairMark.Tests.Properties;
using FairMark.TrueApi.DataContracts;
using NUnit.Framework;

namespace FairMark.Tests
{
    [TestFixture]
    public partial class EdoLiteClientTests : UnitTestsBase
    {
        private EdoLiteClient Client { get; } = new EdoLiteClient(EdoLiteClient.SandboxApiUrl, new EdoLiteCredentials
        {
            CertificateThumbprint = TestCertificateThumbprint,

            // SessionToken is not required in production code
            // it is used here to skip authentication in unit tests
            SessionToken = LoadEdoLiteToken(),
        })
        {
            Tracer = TestContext.Progress.WriteLine,
        };

        [Test, Explicit("Doesn't seem to work")]
        public void Chapter_3_1_SendDocument()
        {
            var fileName = "ON_NSCHFDOPPRMARK_2LT-600061573_2LT-354_20191121_99933cc4-710d-4a6f-aa1c03203dc8f6c4"; // @"C:\Users\ON_NSCHFDOPPRMARK_2LT50_2LT-354_20200218_cc716325-e5b9-43b8-813d-8e70e7912272.xml";
            var xmlFileContents = Resources.EdoLite_Chapter_3_1_SampleUpd;
            var docId = Client.SendDocument(fileName, xmlFileContents);
            Assert.NotNull(docId);
        }
    }
}
