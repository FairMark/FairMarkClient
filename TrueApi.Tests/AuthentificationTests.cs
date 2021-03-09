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
    public class AuthentificationTests : UnitTestsBase
    {
        [Test]
        public void TrueApiClientAuthenticates()
        {
            var client = new TrueApiClient(TrueApiClient.SandboxApiUrl, new Credentials
            {
                UserID = TestCertificateThumbprint,
            });

            // test tracing
            var trace = new StringBuilder();
            client.Tracer = (f, a) => trace.AppendFormat(f, a);

            try
            {
                // authenticates and requests a resource
                var s = client.Get("auth/key");
                Assert.NotNull(s);
                Assert.IsTrue(client.IsAuthenticated);

                if (client.Client.Authenticator is CredentialsAuthenticator auth)
                {
                    Assert.NotNull(auth.AuthToken);
                }
                else
                {
                    Assert.Fail("Authenticator is missing");
                }
            }
            finally
            {
                // logs out
                Assert.DoesNotThrow(() => client.Dispose());
                Assert.IsFalse(client.IsAuthenticated);
                if (client.Client.Authenticator is CredentialsAuthenticator auth)
                {
                    Assert.IsNull(auth.AuthToken);
                }
            }

            var traceText = trace.ToString();
            Assert.IsTrue(traceText.Length > 0, "TrueApiClient trace is empty");
            Assert.IsTrue(traceText.Contains("// Authenticate"));
            Assert.IsTrue(traceText.Contains("// GetToken"));
            Assert.IsTrue(traceText.Contains("-> GET"));
            Assert.IsTrue(traceText.Contains("<- OK 200 (OK)"));
        }
    }
}
