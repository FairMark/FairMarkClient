using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairMark.DataContracts;
using FairMark.EdoLite;
using FairMark.OmsApi;
using FairMark.OmsApi.DataContracts;
using FairMark.TrueApi;
using FairMark.TrueApi.DataContracts;
using NUnit.Framework;

namespace FairMark.Tests
{
    [TestFixture]
    public class AuthentificationTests : UnitTestsBase
    {
        [Test]
        public void TestSaveLoadSettings()
        {
            Assert.DoesNotThrow(() =>
            {
                var unknownSetting = LoadSetting("Unknown");
                Assert.IsNull(unknownSetting);

                var value = Guid.NewGuid().ToString();
                SaveSetting("TestSetting", value);

                var loaded = LoadSetting("TestSetting");
                Assert.AreEqual(value, loaded);
            });
        }

        [Test]
        public void TrueApiClientAuthenticatesUsingCertificate()
        {
            AuthenticateTrueApiClient();
        }

        [Test]
        public void TrueApiClientAuthenticatesUsingSavedToken()
        {
            AuthenticateTrueApiClient(LoadTrueApiToken());
        }

        private void AuthenticateTrueApiClient(AuthToken savedToken = null)
        {
            var client = new TrueApiClient(TrueApiClient.SandboxApiUrl, new TrueApiCredentials
            {
                CertificateThumbprint = TestCertificateThumbprint,
                SessionToken = savedToken,
            });

            // test tracing
            var trace = new StringBuilder();
            client.Tracer = (f, a) =>
            {
                trace.AppendFormat(f, a);
                TestContext.Progress.WriteLine(f, a);
            };

            try
            {
                // authenticates and requests a resource
                var s = client.Get("auth/key");
                Assert.NotNull(s);
                Assert.IsTrue(client.Authenticator.IsAuthenticated);
                Assert.NotNull(client.Authenticator.AuthToken);

                // save the token for later reuse
                SaveTrueApiToken(client.Authenticator.AuthToken);
            }
            finally
            {
                // logs out
                Assert.DoesNotThrow(() => client.Dispose());
                Assert.IsFalse(client.Authenticator.IsAuthenticated);
                Assert.IsNull(client.Authenticator.AuthToken);
            }

            var traceText = trace.ToString();
            Assert.IsTrue(traceText.Length > 0, "TrueApiClient trace is empty");
            Assert.IsTrue(traceText.Contains("// "));
            Assert.IsTrue(traceText.Contains("-> GET"));
            Assert.IsTrue(traceText.Contains("<- OK 200 (OK)"));
        }

        [Test] //, Explicit("OMS API sandbox times out very often")]
        public void OmsApiClientAuthenticatesUsingCertificate()
        {
            AuthenticateOmsApiClient();
        }

        [Test]
        public void OmsApiClientAuthenticatesUsingSavedToken()
        {
            AuthenticateOmsApiClient(LoadOmsApiToken());
        }

        private void AuthenticateOmsApiClient(AuthToken savedToken = null)
        {
            var client = new OmsApiClient(OmsApiClient.SandboxApiUrl, OmsApiClient.SandboxAuthUrl, ProductGroupsOMS.milk, new OmsCredentials
            {
                CertificateThumbprint = TestCertificateThumbprint,
                OmsID = TestOmsID, // it's case sensitive, to my surprise
                OmsConnectionID = TestOmsConnectionID,
                SessionToken = savedToken,
            });

            // test tracing
            var trace = new StringBuilder();
            client.Tracer = (f, a) =>
            {
                trace.AppendFormat(f, a);
                TestContext.Progress.WriteLine(f, a);
            };

            try
            {
                // authenticates and requests a resource
                var version = client.GetVersion();
                Assert.NotNull(version);
                Assert.NotNull(version.ApiVersion);
                Assert.NotNull(version.OmsVersion);
                Assert.IsTrue(client.Authenticator.IsAuthenticated);
                Assert.NotNull(client.Authenticator.AuthToken);

                // ping/pong
                var omsId = client.Ping(); // ($"milk/ping?omsId={TestOmsID}");
                Assert.NotNull(omsId);
                Assert.AreEqual(omsId, client.OmsCredentials.OmsID);

                // save the token for later reuse
                SaveOmsApiToken(client.Authenticator.AuthToken);
            }
            finally
            {
                // logs out
                Assert.DoesNotThrow(() => client.Dispose());
                Assert.IsFalse(client.Authenticator.IsAuthenticated);
                Assert.IsNull(client.Authenticator.AuthToken);
            }

            var traceText = trace.ToString();
            Assert.IsTrue(traceText.Length > 0, "OmsApiClient trace is empty");
            Assert.IsTrue(traceText.Contains("// GetVersion"));
            Assert.IsTrue(traceText.Contains("-> GET"));
            Assert.IsTrue(traceText.Contains("<- OK 200 (OK)"));
        }

        [Test]
        public void EdoLiteAuthenticatesUsingCertificate()
        {
            AuthenticateEdoLiteClient();
        }

        [Test]
        public void EdoLiteAuthenticatesUsingSavedToken()
        {
            AuthenticateEdoLiteClient(LoadEdoLiteToken());
        }

        private void AuthenticateEdoLiteClient(AuthToken savedToken = null)
        {
            var client = new EdoLiteClient(EdoLiteClient.SandboxApiUrl, new EdoLiteCredentials
            {
                CertificateThumbprint = TestCertificateThumbprint,
                //SessionToken = savedToken,
            });

            // test tracing
            var trace = new StringBuilder();
            client.Tracer = (f, a) =>
            {
                trace.AppendFormat(f, a);
                TestContext.Progress.WriteLine(f, a);
            };

            try
            {
                // authenticates and requests a resource
                var s = client.Get("outgoing-documents/unsigned-events");
                Assert.NotNull(s);
                Assert.IsTrue(client.Authenticator.IsAuthenticated);
                Assert.NotNull(client.Authenticator.AuthToken);

                // save the token for later reuse
                SaveEdoLiteToken(client.Authenticator.AuthToken);
            }
            finally
            {
                // logs out
                Assert.DoesNotThrow(() => client.Dispose());
                Assert.IsFalse(client.Authenticator.IsAuthenticated);
                Assert.IsNull(client.Authenticator.AuthToken);
            }

            var traceText = trace.ToString();
            Assert.IsTrue(traceText.Length > 0, "EdoLiteClient trace is empty");
            Assert.IsTrue(traceText.Contains("// "));
            Assert.IsTrue(traceText.Contains("-> GET"));
            Assert.IsTrue(traceText.Contains("<- OK 200 (OK)"));
        }
    }
}
