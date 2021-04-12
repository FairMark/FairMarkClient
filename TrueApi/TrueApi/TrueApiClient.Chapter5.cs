namespace FairMark.TrueApi
{
    using DataContracts;
    using RestSharp;

    public partial class TrueApiClient
    {
        /// <summary>
        /// 6.9. Метод получения списка КИ по номеру документа.
        /// </summary>
        /// <param name="docNum"></param>
        /// <returns>Список КИ</returns>
        public string[] GetCisesByOrderId(string docNum) // TODO Сделать поддержку второго параметра pg (товарная группа)
        {
            return Get<string[]>("/cises/doc/{docNum}", new[] { new Parameter("docNum", docNum, ParameterType.UrlSegment) });
        }
    }
}
