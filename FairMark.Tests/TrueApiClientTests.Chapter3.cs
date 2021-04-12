using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairMark.TrueApi.DataContracts;
using NUnit.Framework;

namespace FairMark.TrueApi.Tests
{
    [TestFixture]
    public partial class TrueApiClientTests : UnitTestsBase
    {
        private TrueApiClient Client { get; } = new TrueApiClient(TrueApiClient.SandboxApiUrl, new TrueApiCredentials
        {
            CertificateThumbprint = TestCertificateThumbprint,
        })
        {
            Tracer = TestContext.Progress.WriteLine,
        };

        [Test, Ignore("Returns error 400 Bad request")]
        public void Chapter_3_1_1_Registration()
        {
            var request = new ProductDocument
            {
                Organization = new Organization
                {
                    Inn = "123",
                    Address = "321"
                },
                User = new User
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Fingerprint = TestCertificateThumbprint,
                }
            };

            var docId = Client.Register(request);
            Assert.NotNull(docId);
            TestContext.Progress.WriteLine($"Registration request id = {docId}");
        }

        [Test, Ignore("Returns Error 400 Bad Request: [OPEN API] Отсутствует провайдер статуса для типа заявки LK_REGISTRATION")]
        public void Chapter_3_1_2_GetRegistrationStatus()
        {
            var status = Client.GetRegistrationStatus(6102);
            Assert.NotNull(status);
        }
    }
}
