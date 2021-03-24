namespace FairMark.TrueApi
{
    using DataContracts;
    using RestSharp;

    partial class TrueApiClient
    {
        private void GetKIsByDoumentNumber(string docNum)//TODO Сделать поддержку второго параметра pg (товарная группа)
        {
            var response = Get<RegistrationResponse>("/cises/doc/{docNum}", new[] { new Parameter("docNum", "asdf", ParameterType.RequestBody) });
        }



    }
}
