using Microsoft.Extensions.Options;
using SCAE.Domain.Models.Shared;
using System;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using SCAE.Service.Interfaces.Messenger;
using System.Net;
using Microsoft.Extensions.Logging;

namespace SCAE.Service.Services.Messenger
{
    public class TelegramService : ITelegramService
    {
        private readonly TelegramSettingModel _appSettings;

        public TelegramService(IOptions<TelegramSettingModel> settings)
        {
            _appSettings = settings.Value;
        }

        private HttpClient GetCabecalho()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_appSettings.UrlBase);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public int AssinanteIdToTopicoId(int assinanteId)
        {
            switch (assinanteId)
            {
                case 01: return 40;
                case 03: return 42;
                case 04: return 20;
                case 05: return 23;
                case 06: return 26;
                case 07: return 28;
                case 08: return 02;
                case 11: return 12; //DRS
                case 12: return 46;
                case 13: return 49;
                case 15: return 34;
                case 16: return 36;
                case 18: return 33292; //DRS BRAZIL
                case 19: return 51;
                case 20: return 57;
                case 21: return 60;
                case 22: return 63;
                case 23: return 66;
                case 24: return 69;
                case 25: return 72;
                case 26: return 79;
                case 27: return 82;
                case 28: return 85;
                case 29: return 88;
                case 30: return 91;
                case 33: return 93;
                case 34: return 37269;  //PRIDDE EMPREENDIMENTOS
                case 38: return 117497; //GPX LOTEAMENTOS
                default: return 0;
            }
        }

        public async Task Enviar(int topicoId, string texto, ILogger logger)
        {
            using (var client = GetCabecalho())
            {
                var model = new
                {
                    chat_id = _appSettings.ChatId,
                    message_thread_id = topicoId,
                    text = texto
                };

                var json = JsonConvert.SerializeObject(model, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();
                var response = await client.PostAsync(WebUtility.UrlEncode($"bot{_appSettings.Token}/sendMessage"), stringContent);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"ERRO TELEGRAM: {data.description}");
                    //throw new BadRequestException(data.description);
                }
            }
        }
    }
}
