using FairMark.DataContracts;

namespace FairMark
{
    public partial class CommonApiClient
    {
        /// <summary>
        /// Authentication Step 1.
        /// </summary>
        internal abstract AuthResponse Authenticate();

        /// <summary>
        /// Authentication Step 2.
        /// </summary>
        internal abstract AuthToken GetToken(AuthResponse authResponse, string signedData);

        /// <summary>
        /// Invalidating the authentication token is not supported.
        /// </summary>
        internal abstract void Logout();
    }
}
