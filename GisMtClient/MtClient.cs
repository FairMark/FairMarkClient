using System;
using RestSharp;

namespace GisMtClient
{
    /// <summary>
    /// GIS MT REST API Client.
    /// </summary>
    public class MtClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MtClient"/> class.
        /// </summary>
        /// <param name="baseUrl">Base API url.</param>
        /// <param name="credentials">Credentials.</param>
        public MtClient(string baseUrl, Credentials credentials)
            : this(new RestClient(baseUrl), credentials)
        {
        }

        public MtClient(IRestClient client, Credentials credentials)
        {
        }
    }
}
