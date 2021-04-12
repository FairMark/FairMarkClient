namespace FairMark
{
    using System.Security;
    using System.Text;
    using DataContracts;
    using Toolbox;

    /// <summary>
    /// Common FairMark credentials for True API, OMS API, etc.
    /// </summary>
    public class Credentials
    {
        /// <summary>
        /// Gets or sets the user identity, same as the cryptographic certificate thumbprint.
        /// </summary>
        public string CertificateThumbprint { get; set; }

        // <summary>
        // Gets or sets the OMS Identity, taken from the user's profile,
        // see https://intuot.crpt.ru:12011/configuration/profile
        // </summary>
        // public string OmsID { get; set; }

        // <summary>
        // Gets or sets the device token, taken from the device properties,
        // see https://intuot.crpt.ru:12011/management/devices
        // </summary>
        // public string DeviceToken { get; set; }

        /// <summary>
        /// Performs authentication, returns access token with a limited lifetime.
        /// </summary>
        /// <param name="apiClient">GIS MT client to perform API calls.</param>
        /// <returns><see cref="AuthToken"/> instance.</returns>
        public AuthToken Authenticate(CommonApiClient apiClient)
        {
            // load the certificate with a private key by userId
            var certificate = apiClient.UserCertificate;
            if (certificate == null)
            {
                throw new SecurityException("GOST-compliant certificate not found. " +
                    "Make sure that the certificate is properly installed and has the associated private key. " +
                    "Thumbprint or subject name: " + CertificateThumbprint);
            }

            // get authentication code
            var authResponse = apiClient.Authenticate();

            // compute the signature and save the size
            var signedData = GostCryptoHelpers.ComputeAttachedSignature(certificate, authResponse.Data);
            apiClient.SignatureSize = Encoding.UTF8.GetByteCount(signedData);

            // get authentication token
            return apiClient.GetToken(authResponse, signedData);
        }
    }
}