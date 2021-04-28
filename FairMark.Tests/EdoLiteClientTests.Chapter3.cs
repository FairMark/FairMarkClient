using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
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

        public EdoLiteClientTests()
        {
            // enforce authentication and make sure 
            // that the last OMS auth token is saved
            Client.GetOutgoingDocuments();
            SaveEdoLiteToken(Client.Authenticator.AuthToken);
        }

        [Test, Explicit("Avoid creating lots of duplicate documents on each commit")]
        public void Chapter_3_1_SendSellerUpdDocument()
        {
            var fileName = "ON_NSCHFDOPPR_2LT-600006439_2LT-600003352_20210426_0dc17582-d11d-4a4d-8e25-816d59870ef4.xml"; // @"C:\Users\ON_NSCHFDOPPRMARK_2LT50_2LT-354_20200218_cc716325-e5b9-43b8-813d-8e70e7912272.xml";
            var xmlFileContents = Resources.ON_NSCHFDOPPR_2LT_600006439_2LT_600003352_20210426_0dc17582_d11d_4a4d_8e25_816d59870ef4;
            var docId = Client.SendSellerUpdDocument(fileName, xmlFileContents, true);

            // unsigned: 28dacc48-7fd2-4248-942b-2c8c210f2f40
            // signed: "d0f62b99-e823-4759-b22b-af57f86359d7"
            // signed: "1771bf33-dbae-4973-af8d-a64ce4163623"
            Assert.NotNull(docId);
        }

        [Test, Explicit("Avoid creating lots of duplicate documents on each commit")]
        public void Chapter_3_2_SendSellerUpdiDocument()
        {
            // УПДи по структуре отличается от УПД,
            // и обычный УПД вместо него послать невозможно
            // ошибка "DOC-0017: Неверный тип документа загружаемого xml файла"
            // var fileName = "ON_NSCHFDOPPR_2LT-600006439_2LT-600003352_20210426_0dc17582-d11d-4a4d-8e25-816d59870ef4.xml"; // @"C:\Users\ON_NSCHFDOPPRMARK_2LT50_2LT-354_20200218_cc716325-e5b9-43b8-813d-8e70e7912272.xml";
            // var xmlFileContents = Resources.ON_NSCHFDOPPR_2LT_600006439_2LT_600003352_20210426_0dc17582_d11d_4a4d_8e25_816d59870ef4;
            var fileName = "ON_NSCHFDOPPR_2LT-600006439_2LT-600003352_20210426_a5011718-844e-4bba-b15c-a1c15e49a691.xml";
            var xmlFileContents = Resources.ON_NSCHFDOPPR_2LT_600006439_2LT_600003352_20210426_a5011718_844e_4bba_b15c_a1c15e49a691_УПДи;

            // parentId от документа, загруженного в методе Chapter_3_1_SendSellerUpdDocument
            var parentId = "d0f62b99-e823-4759-b22b-af57f86359d7";
            var docId = Client.SendSellerUpdiDocument(fileName, xmlFileContents, parentId, true);
            Assert.NotNull(docId);

            // unsigned: "60624793-cd64-4d2c-8c68-ce03544b66d7"
            // signed: "900e35f8-9572-4256-b543-2aed40ee35ff"
            // signed: "5d1d074d-c489-45b7-b6d3-e703c680eba4"
        }

        [Test, Explicit("Avoid creating lots of duplicate documents on each commit")]
        public void Chapter_3_3_SendSellerUkdDocument()
        {
            // УКД по структуре отличается от УПД,
            // и обычный УПД вместо него послать невозможно
            // ошибка "DOC-0017: Неверный тип документа загружаемого xml файла"
            //var fileName = "ON_NSCHFDOPPR_2LT-600006439_2LT-600003352_20210426_0dc17582-d11d-4a4d-8e25-816d59870ef4.xml"; // @"C:\Users\ON_NSCHFDOPPRMARK_2LT50_2LT-354_20200218_cc716325-e5b9-43b8-813d-8e70e7912272.xml";
            //var xmlFileContents = Resources.ON_NSCHFDOPPR_2LT_600006439_2LT_600003352_20210426_0dc17582_d11d_4a4d_8e25_816d59870ef4;
            var fileName = "ON_KORSCHFDOPPR_2LT-600006439_2LT-600003352_20210426_68426923-d1e2-4582-93f2-f690912d5161.xml";
            var xmlFileContents = Resources.ON_KORSCHFDOPPR_2LT_600006439_2LT_600003352_20210426_68426923_d1e2_4582_93f2_f690912d5161;

            // parentId от документа, загруженного в методе Chapter_3_1_SendSellerUpdDocument
            var parentId = "d0f62b99-e823-4759-b22b-af57f86359d7";
            var docId = Client.SendSellerUkdDocument(fileName, xmlFileContents, parentId, true);
            Assert.NotNull(docId);

            // signed: "71dd59ac-2f88-4bfb-bacc-51fe3d55d404"
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

        [Test, Explicit("A document can be signed only once")]
        public void Chapter_3_5_SignOutgoingDocument()
        {
            // черновик можно подписать только один раз
            // чтобы обновить тест, нужно загрузить новый документ
            // и не подписывать его, см. Chapter_3_1_SendSellerUpdDocument
            var draftDocId = "60624793-cd64-4d2c-8c68-ce03544b66d7";
            Assert.DoesNotThrow(() => Client.SignOutgoingDocument(draftDocId));
        }

        private void AssertPdfFormat(byte[] data)
        {
            Assert.NotNull(data);
            Assert.IsTrue(data.Length > 1000);

            using (var ms = new MemoryStream(data))
            using (var sr = new StreamReader(ms))
            {
                var firstLine = sr.ReadLine();
                Assert.IsTrue(firstLine.StartsWith("%PDF"));
            }
        }

        [Test]
        public void Chapter_3_6_PrintIncomingDocument()
        {
            // чтобы обновить тест, скопируйте коды
            // документов из личного кабинета демо-контура ГИС МТ,
            // с закладки ЭДО Входящие
            // https://milk.demo.crpt.tech/documents/incoming/list
            AssertPdfFormat(Client.PrintIncomingDocument("afb6cce6-6cb9-4147-bc2f-689be4fd2198")); // УПД
            AssertPdfFormat(Client.PrintIncomingDocument("a4941fa7-9a53-4991-aa02-f1606b71142c")); // УПДи
            AssertPdfFormat(Client.PrintIncomingDocument("00c4d099-a48f-47ed-8608-54d32890fe73")); // УКД
        }

        [Test]
        public void Chapter_3_6_PrintOutgoingDocument()
        {
            // чтобы обновить тест, скопируйте коды
            // документов из личного кабинета демо-контура ГИС МТ,
            // с закладки ЭДО Исходящие
            // https://milk.demo.crpt.tech/documents/outgoing/list
            AssertPdfFormat(Client.PrintOutgoingDocument("d0f62b99-e823-4759-b22b-af57f86359d7")); // УПД
            AssertPdfFormat(Client.PrintOutgoingDocument("5d1d074d-c489-45b7-b6d3-e703c680eba4")); // УПДи
            AssertPdfFormat(Client.PrintOutgoingDocument("71dd59ac-2f88-4bfb-bacc-51fe3d55d404")); // УКД
        }

        private void AssertZipArchive(byte[] zip)
        {
            Assert.NotNull(zip);
            Assert.IsTrue(zip.Length > 100);

            using (var ms = new MemoryStream(zip))
            using (var arc = new ZipArchive(ms))
            {
                foreach (var entry in arc.Entries)
                {
                    Assert.NotNull(entry);
                    Assert.NotNull(entry.Name);
                    Assert.NotZero(entry.CompressedLength);

                    using (var data = entry.Open())
                    using (var ems = new MemoryStream())
                    {
                        data.CopyTo(ems);
                        data.Flush();
                        ems.Flush();

                        Assert.AreEqual(ems.Length, entry.Length);
                    }
                }
            }
        }

        [Test]
        public void Chapter_3_7_DownloadIncomingZipArchive()
        {
            // чтобы обновить тест, скопируйте код
            // документа из личного кабинета демо-контура ГИС МТ,
            // с закладки ЭДО Входящие
            // https://milk.demo.crpt.tech/documents/incoming/list
            AssertZipArchive(Client.DownloadIncomingZipArchive("afb6cce6-6cb9-4147-bc2f-689be4fd2198")); // УПД+УПДи+УКД
        }

        [Test]
        public void Chapter_3_7_DownloadOutgoingZipArchive()
        {
            // чтобы обновить тест, скопируйте код
            // документа из личного кабинета демо-контура ГИС МТ,
            // с закладки ЭДО Исходящие
            // https://milk.demo.crpt.tech/documents/outgoing/list
            AssertZipArchive(Client.DownloadOutgoingZipArchive("d0f62b99-e823-4759-b22b-af57f86359d7")); // УПД+УПДи+УКД
        }

        [Test]
        public void Chapter_3_8_GetOutgoingDocuments()
        {
            var result = Client.GetOutgoingDocuments();
            Assert.NotNull(result);
            Assert.IsTrue(result.Count > 0);
            Assert.IsNull(result.First().Sender);
            Assert.IsNotNull(result.First().Recipient);
        }

        [Test]
        public void Chapter_3_8_GetIncomingDocuments()
        {
            var result = Client.GetIncomingDocuments();
            Assert.NotNull(result);
            Assert.IsTrue(result.Count > 0);
            Assert.IsNotNull(result.First().Sender);
            Assert.IsNull(result.First().Recipient);
        }
    }
}
