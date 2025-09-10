using Microsoft.Extensions.Options;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro;
using SCAE.Service.Interfaces.Financeiro.ApiFinanceiro;
using SCAE.Service.Interfaces.Geral;
using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SCAE.Framework.Exceptions;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Boleto;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Http;

using SCAE.Domain.Entities.Financeiro;
using System.Collections.Generic;
using System.IO;

namespace SCAE.Service.Services.Financeiro.ApiFinanceiro
{
    public class ApiFinanceiroBaseService : IApiFinanceiroBaseService
    {
        public readonly ApiFinanceiroSettingModel _appSettings;
        public readonly IEnderecoService _enderecoService;

        public ApiFinanceiroBaseService(IOptions<ApiFinanceiroSettingModel> settings)
        {
            _appSettings = settings.Value;
        }

        public ApiFinanceiroBaseService(IOptions<ApiFinanceiroSettingModel> settings, IEnderecoService enderecoService)
        {
            _appSettings = settings.Value;
            _enderecoService = enderecoService;
        }

        protected HttpClient GetCabecalho()
        {
            var client = new HttpClient();
            var url = _appSettings.UrlBase;
#if (DEBUG)
            //url = "http://192.168.1.118:5147/v1/";
            url = "http://localhost:5147/v1/";
#endif
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(_appSettings.Token + ":")));

            return client;
        }

        public async Task<ArquivoRemessaDocumento> RemessaBoleto(int codigoBanco,RemessaModel remessa,EnumTipoArquivo enumTipoArquivo)
        {
            using (var client = GetCabecalho())
            {
                var json = JsonConvert.SerializeObject(remessa, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();

                var response = await client.PostAsync($"Boleto/{codigoBanco}/Cobranca/Remessa/{enumTipoArquivo}",stringContent);

                if (response.IsSuccessStatusCode)
                {
                   var arquivoRemessa = new ArquivoRemessaDocumento()
                   {
                       Dados = await response.Content.ReadAsByteArrayAsync(),
                       DataEmissao = DateTime.Now,
                       Nome = response.Content.Headers.ContentDisposition.FileName,
                       Tamanho = (decimal)response.Content.Headers.ContentLength,
                       Tipo = response.Content.Headers.ContentType.MediaType
                   };

                    return arquivoRemessa;

                }

                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);
                throw new BadRequestException(data.ToString());

            }
        }

        public async Task<string> VisualizarBoleto(int codigoBanco, BoletoModel boleto)
        {
            using (var client = GetCabecalho())
            {
                var json = JsonConvert.SerializeObject(boleto, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();

                var response = await client.PostAsync($"Boleto/{codigoBanco}/Impressao/HTML", stringContent);
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)                
                    return content;

                var data = JsonConvert.DeserializeObject<dynamic>(content);
                throw new BadRequestException(data.ToString());

            }
        }

        public async Task<byte[]> VisualizarBoletoPdf(int codigoBanco, CarneModel carne,bool manterNossoNumero)
        {
            using (var client = GetCabecalho())
            {
                var json = JsonConvert.SerializeObject(carne, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();

                var response = await client.PostAsync($"Boleto/{codigoBanco}/Impressao/PDF?manterNossoNumero={manterNossoNumero}", stringContent);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsByteArrayAsync();
                }
                var content = await response.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<dynamic>(content);
                throw new BadRequestException(data.ToString());

            }
        }

        public async Task<List<RetornoModel>> ProcessarRetornoBoleto(int codigoBanco, IFormFile arquivoRetorno, EnumTipoArquivo enumTipoArquivo)
        {
            using (var client = GetCabecalho())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));

                //var json = JsonConvert.SerializeObject(arquivoRetorno, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                //var stringContent = new StringContent(json, Encoding.UTF8, "multipart/form-data");
                //stringContent.Headers.ContentType.Parameters.Clear();

                var form = new MultipartFormDataContent();

                byte[] fileBytes;

                using (var ms = new MemoryStream())
                {
                    arquivoRetorno.CopyTo(ms);
                    fileBytes = ms.ToArray();
                }
                var byteArrayContent = new ByteArrayContent(fileBytes);
                form.Add(byteArrayContent, "arquivoRetorno", arquivoRetorno.FileName);

                var response = await client.PostAsync($"Boleto/{codigoBanco}/Cobranca/Retorno/{enumTipoArquivo}",form);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<List<RetornoModel>>(content);

                var data = JsonConvert.DeserializeObject<dynamic>(content);
                throw new BadRequestException(data.ToString());

            }
        }

    }
}
