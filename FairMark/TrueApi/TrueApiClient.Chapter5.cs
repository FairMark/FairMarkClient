namespace FairMark.TrueApi
{
    using DataContracts;
    using RestSharp;

    public partial class TrueApiClient
    {
        /// <summary>
        /// 5.4.2. Get products Gtins for participant
        /// Note: Response doesn`t corresponds to the documentation
        /// </summary>
        /// <param name="productGroup">Product group name from <see cref="ProductGroupsTrueApi"/></param>
        /// <param name="includeSubaccount">If true, then the response returns data on all GTINs both belonging to the participant and provided to him through the subaccounts. 
        /// If false, then the response returns data only on the GTIN belonging to the participant.
        /// Default = false 
        /// <param name="limit">Row count in response
        /// Note: Maximum 10000 rows. Default 10
        /// По умолчанию: 10 записей</param>
        /// <param name="page">Number of page. Default 0</param>
        /// <returns></returns>
        public GetParticipantGtinsReponse GetParticipantGtins(ProductGroupsTrueApi productGroup, bool includeSubaccount, int limit = 10, int page = 0)
        {
            var response = Get<GetParticipantGtinsReponse>("/product/gtin",
                new Parameter[]
                {
                    new RestSharp.Parameter("limit", limit, ParameterType.QueryString),
                    new RestSharp.Parameter("page", page, ParameterType.QueryString),
                    new RestSharp.Parameter("pg", productGroup, ParameterType.QueryString),
                    new RestSharp.Parameter("includeSubaccount", includeSubaccount, ParameterType.QueryString),
                });
            return response;
        }

    }
}
