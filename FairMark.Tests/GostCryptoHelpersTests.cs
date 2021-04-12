namespace FairMark.TrueApi.Tests
{
    using System.Security.Cryptography.X509Certificates;
    using NUnit.Framework;
    using Toolbox;

    [TestFixture]
    public class GostCryptoHelpersTests : UnitTestsBase
    {
        private X509Certificate2 GetTestCertificate()
        {
            return GostCryptoHelpers.FindCertificate(TestCertificateSubjectName);
        }

        [Test]
        public void CertificateThumbprintIsCleanedUp()
        {
            Assert.AreEqual(null, GostCryptoHelpers.CleanupThumbprint(null));
            Assert.AreEqual(string.Empty, GostCryptoHelpers.CleanupThumbprint(string.Empty));
            Assert.AreEqual(string.Empty, GostCryptoHelpers.CleanupThumbprint(" \t\v\r\n"));
            Assert.AreEqual("1234abcd", GostCryptoHelpers.CleanupThumbprint(" 12 34  ab cd   "));
            Assert.AreEqual(TestCertificateThumbprint, GostCryptoHelpers.CleanupThumbprint(TestCertificateThumbprintCopiedFromTheSnapin));
        }

        [Test]
        public void GostCryproProviderIsInstalled()
        {
            Assert.IsTrue(GostCryptoHelpers.IsGostCryptoProviderInstalled());
        }

        [Test]
        public void CertificateIsLoadedByThumbprint()
        {
            var cert = GostCryptoHelpers.FindCertificate(TestCertificateThumbprint);
            Assert.NotNull(cert);
        }

        [Test]
        public void CertificateWithPrivateKeyIsLoaded()
        {
            var cert = GetTestCertificate();
            Assert.IsNotNull(cert);
            Assert.AreEqual(cert.Thumbprint.ToUpper(), TestCertificateThumbprint.ToUpper());
        }

        [Test]
        public void CertificateCanBeUsedToComputeDetachedCmsSignature()
        {
            var cert = GetTestCertificate();
            var sign = GostCryptoHelpers.ComputeDetachedSignature(cert, "Привет!");
            Assert.IsNotNull(sign);
            Assert.IsTrue(sign.StartsWith("MII"));
            Assert.IsTrue(sign.Length > 1000);
        }

        [Test]
        public void CertificateCanBeUsedToComputeAttachedCmsSignature()
        {
            var cert = GetTestCertificate();
            var sign = GostCryptoHelpers.ComputeAttachedSignature(cert, "Привет!");
            Assert.IsNotNull(sign);
            Assert.IsTrue(sign.StartsWith("MII"));
            Assert.IsTrue(sign.Length > 1000);
        }
    }
}
