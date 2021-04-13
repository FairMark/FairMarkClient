using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        private int BruteForceFindValidRegistrationStatusNumber()
        {
            foreach (var i in Enumerable.Range(636, 10)) // Range(0, 1000)
             {
                try
                {
                    var status = Client.GetRegistrationStatus(i);
                    Assert.NotNull(status);
                    TestContext.Progress.WriteLine($"OK: {i}");
                    return i;
                }
                catch
                {
                    TestContext.Progress.WriteLine($"Error: {i}");
                }
            }

            throw new InvalidOperationException("Registration number not found!");
        }

        [Test]
        public void Chapter_3_1_2_GetRegistrationStatus_Success()
        {
            var regNumber = BruteForceFindValidRegistrationStatusNumber();
            Assert.That(regNumber, Is.GreaterThan(0));

            var status = Client.GetRegistrationStatus(637);
            Assert.NotNull(status);

            Assert.AreEqual("CHECKED_NOT_OK", status.RegistrationRequestStatus);
            Assert.AreEqual(1, status.Errors.Length);
            Assert.AreEqual("1003: Недопустимый формат значения в поле \"ИНН\" в документе \"Регистрация\".", status.Errors[0].Message);
        }

        [Test]
        public void Chapter_3_1_2_GetRegistrationStatus_BadRequest()
        {
            var ex = Assert.Throws<FairMarkException>(() =>
            {
                Client.GetRegistrationStatus(6102);
            });

            Assert.AreEqual(HttpStatusCode.BadRequest, ex.StatusCode);
            Assert.AreEqual("[OPEN API] Отсутствует провайдер статуса для типа заявки LK_REGISTRATION", ex.ErrorResponse.ErrorMessage);
        }
    }
}
