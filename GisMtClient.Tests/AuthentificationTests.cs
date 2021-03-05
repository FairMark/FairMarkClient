using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GisMtClient.Tests
{
    [TestFixture]
    public class AuthentificationTests : UnitTestsBase
    {
        [Test]
        public void MtClientAuthenticates()
        {
            var client = new MtClient(MtClient.SandboxApiUrl, new Credentials
            {
                OmsID = OmsID,
                Connection = Token,
                UserID = TestCertificateThumbprint,
            });

            var s = client.Get("auth/cert/key");
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
    }
}
