using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
            var fileName = "ON_NSCHFDOPPR_2LT-600006439_2LT-600003352_20210426_0dc17582-d11d-4a4d-8e25-816d59870ef4.xml"; // @"C:\Users\ON_NSCHFDOPPRMARK_2LT50_2LT-354_20200218_cc716325-e5b9-43b8-813d-8e70e7912272.xml";
            var xmlFileContents = Resources.ON_NSCHFDOPPR_2LT_600006439_2LT_600003352_20210426_0dc17582_d11d_4a4d_8e25_816d59870ef4;
            var docId = Client.SendDocument(fileName, xmlFileContents);
            Assert.NotNull(docId);
        }

        [Test]
        public void Chapter_3_4_GetIncomingDocument()
        {
            var docId = "afb6cce6-6cb9-4147-bc2f-689be4fd2198";
            var xmlFileContents = Client.GetIncomingDocument(docId);

            Assert.NotNull(xmlFileContents);
            Assert.DoesNotThrow(() => XDocument.Parse(xmlFileContents));
        }

        [Test]
        public void Chapter_3_4_GetOutgoingDocument()
        {
            var docId = "0dc17582-d11d-4a4d-8e25-816d59870ef4";
            var xmlFileContents = Client.GetOutgoingDocument(docId);

            Assert.NotNull(xmlFileContents);
            Assert.DoesNotThrow(() => XDocument.Parse(xmlFileContents));
        }
    }
}
