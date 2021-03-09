using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                OmsID = OmsID,
                Connection = Token,
                UserID = TestCertificateThumbprint,
            });

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
            }
        }
    }
}
