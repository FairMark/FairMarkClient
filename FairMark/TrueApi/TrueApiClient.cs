namespace FairMark.TrueApi
{
    using RestSharp;

    public partial class TrueApiClient : CommonApiClient
    {
        public TrueApiClient(string baseUrl, Credentials credentials) : base(baseUrl, credentials)
        {

        }
        public TrueApiClient(IRestClient baseUrl, Credentials credentials) : base(baseUrl, credentials)
        {

        }
    }
}
