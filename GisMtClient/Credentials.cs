namespace GisMtClient
{
    /// <summary>
    /// GIS MT Credentials.
    /// </summary>
    public class Credentials
    {
        /// <summary>
        /// Gets or sets the OMS Identity, taken from the user's profile,
        /// see https://intuot.crpt.ru:12011/configuration/profile
        /// </summary>
        public string OmsID { get; set; }

        /// <summary>
        /// Gets or sets the device token, taken from the device properties,
        /// see https://intuot.crpt.ru:12011/management/devices
        /// </summary>
        public string Connection { get; set; }

        /// <summary>
        /// Gets or sets the user identity, taken from the cryptographic certificate,
        /// see Thumbprint property.
        /// </summary>
        public string UserID { get; set; }
    }
}