using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace SCAE.Migracao.Services
{
    public class ApiService
    {
        private readonly bool _development;

        public ApiService()
        {
            _development = false;
        }

        private HttpClient GetCabecalho()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_development ? "http://api-development.scae.adm.br/api/" : "http://api.scae.adm.br/api/");
            client.DefaultRequestHeaders.Clear();
            //client.DefaultRequestHeaders.Add("HostManual", _development ? "development.scae.adm.br" : "viverde.scae.adm.br");
            client.DefaultRequestHeaders.Add("HostManual", _development ? "development.scae.adm.br" : "novarical.scae.adm.br");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy91cG4iOiIxIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZWlkZW50aWZpZXIiOiJtYXN0ZXIiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiTWFzdGVyIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiYWRtaW4iLCJhc3NpbmFudGVJZCI6IjgiLCJwZXJtaXNzb2VzIjoiWzBdIiwiZXhwIjoxNjUyMTY4NTMxLCJpc3MiOiJTY2FlIENvcG9yYXRpdm8iLCJhdWQiOiJTY2FlIENvcG9yYXRpdm8ifQ.ZqwCIPW4pwZNtbiGLNRyQFPot9SCsysUpx5S0zu8yng");

            return client;
        }

        public void Post<T>(string requestUri, T model)
        {
            using (var client = GetCabecalho())
            {
                var jsonVenda = JsonConvert.SerializeObject(model, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(jsonVenda, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();
                var response = client.PostAsync(requestUri, stringContent).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                //var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(content);
            }
        }

        public T Get<T>(string requestUri)
        {
            using (var client = GetCabecalho())
            {
                var response = client.GetAsync(requestUri).Result;
                var content = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<T>(content);

                throw new Exception(content);
            }
        }
    }
}
