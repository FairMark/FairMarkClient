namespace FairMark.TrueApi
{
    using DataContracts;
    using RestSharp;

    public partial class TrueApiClient
    {
        public string[] GetCisesByOrderId(string docNum)//TODO Сделать поддержку второго параметра pg (товарная группа)
        {
            return Get<string[]>("/cises/doc/{docNum}", new[] { new Parameter("docNum", docNum, ParameterType.UrlSegment) });
        }



    }
}
