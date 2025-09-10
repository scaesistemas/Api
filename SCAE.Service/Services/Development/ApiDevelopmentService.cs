using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using SCAE.Domain.Entities.Base;
using SCAE.Domain.Models.Development;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SCAE.Service.Interfaces.Development;
using SCAE.Domain.Models.Geral;
namespace SCAE.Service.Services.Development
{
    public class ApiDevelopmentService : IApiDevelopmentService
    {
        public readonly ApiDevelopmentSettingModel _appSettings;

        public ApiDevelopmentService(IOptions<ApiDevelopmentSettingModel> settings) 
        {
            
        }

        protected HttpClient GetCabecalho() 
        {
            var client = new HttpClient();
            var url = "https://api-development.scae.adm.br/api/";//_appSettings.UrlBase;
#if (DEBUG)
            //throw new BadRequestException("Não é possível utilizar o serviço de development fora de produção");
#endif
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        private async Task<string> GetToken() 
        {
            using (var client = GetCabecalho())
            {
                //var json = JsonConvert.SerializeObject(remessa, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var json = JsonConvert.SerializeObject(new { login = "master", senha = "scaeAdmin#631*" }, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();

                var response = await client.PostAsync($"autenticador/usuario", stringContent);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);
                return data.token;
            }
        }

        public async Task<string> AutenticarUsuario() 
        {
            return await GetToken();
        }

        public async Task<List<Assinante>> GetAssinante()
        {
            var token = await GetToken();
            using (var client = GetCabecalho())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await client.GetAsync($"Assinante");
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<PageResultModel<Assinante>>(content);
                return data.Items;
            }
        }

        public async Task<Assinante> GetAssinanteById(int id) 
        {
            var token = await GetToken();
            using (var client = GetCabecalho())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await client.GetAsync($"Assinante/{id}");
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Assinante>(content);
                return data;
            }
        }
    }
}
