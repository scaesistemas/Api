using Microsoft.Extensions.Options;
using SCAE.Domain.Models.Shared;
using SCAE.Service.Interfaces.Geral;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SCAE.Domain.Models.GalaxPay;
using SCAE.Domain.Entities.Geral;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using SCAE.Framework.Exceptions;
using SCAE.Service.Interfaces.Financeiro.Gateway;
using System.Text.RegularExpressions;
using SCAE.Framework.Helper;
using SCAE.Domain.Entities.Financeiro;

namespace SCAE.Service.Services.Financeiro.Gateway
{
    public class GalaxPayService : IGalaxPayService
    {
        private readonly GalaxPaySettingModel _appSettings;
        private readonly IEnderecoService _enderecoService;

        public GalaxPayService(IOptions<GalaxPaySettingModel> settings)
        {
            _appSettings = settings.Value;
        }
        public GalaxPayService(IOptions<GalaxPaySettingModel> settings, IEnderecoService enderecoService)
        {
            _appSettings = settings.Value;
            _enderecoService = enderecoService;
        }

        private HttpClient GetHeaderInicial(string empresaId, string empresaHash)
        {
            // empresaId = "36473";
            // empresaHash = "W3FxIhUf922u9zT88kVx10Rb1yTu0iX1V4IeU2Ke";
            if (String.IsNullOrEmpty(empresaId) || String.IsNullOrEmpty(empresaHash))
                throw new BadRequestException("Id ou hash da galaxPay não foi cadastrado");

            var client = new HttpClient();
            client.BaseAddress = new Uri(_appSettings.UrlBase);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(empresaId + ":" + empresaHash)));
            client.DefaultRequestHeaders.Add("AuthorizationPartner", Convert.ToBase64String(Encoding.ASCII.GetBytes(_appSettings.GalaxIdPartner + ":" + _appSettings.GalaxHashPartner)));


            return client;
        }

        private HttpClient GetHeaderToken(string token)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_appSettings.UrlBase);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return client;
        }

        public async Task<CustomerModel> ToModel(Pessoa pessoa)
        {
            var estado = string.Empty;
            var municipio = string.Empty;
            var telefones = new List<long>();

            //if (pessoa.Endereco.Municipio == null || pessoa.Endereco.Estado == null)
            //{
            //    estado = (await _enderecoService.ObterEstado(pessoa.Endereco.EstadoId)).Uf;
            //    municipio = (await _enderecoService.ObterMunicipio(pessoa.Endereco.MunicipioId)).Nome;
            //}

            if (!pessoa.Endereco.EstadoId.HasValue || !pessoa.Endereco.MunicipioId.HasValue)
                throw new BadRequestException("Estado ou município da pessoa não cadastrado");

            if (StringHelper.IsTelefone(StringHelper.LimparTelefone(pessoa.Telefone)))
            {
                telefones.Add(long.Parse(StringHelper.LimparTelefone(pessoa.Telefone)));
            }

            var customer = new CustomerModel()
            {
                Id = pessoa.Id.ToString(),
                CpfCnpj = pessoa.CpfCnpjLimpo,
                Nome = pessoa.Nome,
                Telefones = telefones,
                Emails = { pessoa.Email },
                Address =
                {
                    Logradouro = pessoa.Endereco.Logradouro,
                    Numero = string.IsNullOrEmpty(pessoa.Endereco.Numero) ? "0" : pessoa.Endereco.Numero,
                    Complemento = pessoa.Endereco.Complemento,
                    Cep = pessoa.Endereco.Cep.Replace("-",""),
                    Bairro = pessoa.Endereco.Bairro,
                    Cidade = /*string.IsNullOrEmpty(municipio) ?*/ pessoa.Endereco.Municipio.Nome /*: municipio*/,
                    Estado = /*string.IsNullOrEmpty(estado) ?*/ pessoa.Endereco.Estado.Uf /*: estado*/
                }
            };

            return customer;
        }

        public async Task CriarCliente(CustomerModel customer, string empresaId, string empresaHash)
        {
            var token = await ObterTokenAcesso(empresaId, empresaHash);
            using (var client = GetHeaderToken(token))
            {
                var jsonCadastroCliente = JsonConvert.SerializeObject(customer, new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() });
                var stringContent = new StringContent(jsonCadastroCliente, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();
                var response = await client.PostAsync("customers", stringContent);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (!response.IsSuccessStatusCode)
                {
                    //return "okay";//JsonConvert.DeserializeObject<CustomerModel>(data.Customer.ToString());

                    string resultadoerro = JsonConvert.SerializeObject(data.error.details);
                    throw new BadRequestException("Validação GalaxPay - " + resultadoerro.Replace("{", "\n").Replace("[", "").Replace("}", "").Replace("]", "").Replace("\"", " "));

                }
            }
        }

        public async Task<string> ObterTokenAcesso(string empresaId, string empresaHash)
        {
            var tokenParametros =
                new
                {
                    grant_type = _appSettings.GrantType,
                    scope = _appSettings.Scope,
                };

            using (var client = GetHeaderInicial(empresaId, empresaHash))
            {
                var jsonCadastroCliente = JsonConvert.SerializeObject(tokenParametros, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(jsonCadastroCliente, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();
                var response = await client.PostAsync("token", stringContent);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (response.IsSuccessStatusCode)
                {
                    return data.access_token;
                }
                else
                {
                    throw new BadRequestException(data.GetValue("error").GetValue("message").ToString());
                }
            }
        }

        public ChargeModel ToBoletoModel(ReceitaParcela parcela, ParametroGatway gateway)
        {

            if (gateway == null)
                throw new BadRequestException("Informe o parâmetro de configuração da GalaxPay");

            if (gateway.TipoId != TipoGateway.GalaxPay.Id)
                throw new BadRequestException("Este parâmetro de configuração não é GalaxPay");

            if (parcela.EncargoFinanceiro.DiasDescontoVencimento > 20 || parcela.EncargoFinanceiro.DiasDescontoVencimento < 0)
                throw new BadRequestException("Os dias de desconto para vencimento devem estar entre 0 e 20");

            var model = new ChargeModel()
            {
                ParcelaId = parcela.CodigoZoop,
                Valor = int.Parse(StringHelper.FormataValor(parcela.Valor)),
                Vencimento = parcela.DataVencimento.ToString("yyyy-MM-dd"),
                ConfiguracoesBoleto =
                {
                    Multa = int.Parse(StringHelper.FormataValor(parcela.EncargoFinanceiro.Multa)),
                    Juros = int.Parse(StringHelper.FormataValor(parcela.EncargoFinanceiro.JurosDia)),
                   // DiasPosVencimento = parcela.EncargoFinanceiro.DiasAposVencimentoNaoReceber,
                  //  Instrucoes = $"{parcela.Instrucao1} \n {parcela.Instrucao2}\n{parcela.Instrucao3}"

                }
            };



            if (parcela.EncargoFinanceiro.DescontoVencimento > 0)
            {
                model.Desconto = new Discount
                {
                    DiasDescontoVencimento = parcela.EncargoFinanceiro.DiasDescontoVencimento,
                    Tipo = "percent",
                    Porcentagem = Convert.ToInt32(parcela.EncargoFinanceiro.DescontoVencimento)
                };

            }

            if (parcela.EncargoFinanceiro.DiasAposVencimentoNaoReceber > 0)
                model.ConfiguracoesBoleto.DiasPosVencimento = parcela.EncargoFinanceiro.DiasAposVencimentoNaoReceber;

            if (!String.IsNullOrEmpty(parcela.Instrucao1))
                model.ConfiguracoesBoleto.Instrucoes += $"{parcela.Instrucao1} \n";

            if (!String.IsNullOrEmpty(parcela.Instrucao2))
                model.ConfiguracoesBoleto.Instrucoes += $"{parcela.Instrucao2} \n";

            if (!String.IsNullOrEmpty(parcela.Instrucao3))
                model.ConfiguracoesBoleto.Instrucoes += $"{parcela.Instrucao3}";

            model.Cliente.Id = parcela.Receita.Cliente.Id.ToString();
            return model;
        }

        public async Task<(string urlBoleto, string linhaDigitavel)> CriarBoleto(ChargeModel charge, string empresaId, string empresaHash)
        {
            var token = await ObterTokenAcesso(empresaId, empresaHash);
            using (var client = GetHeaderToken(token))
            {
                var jsonBoleto = JsonConvert.SerializeObject(charge, new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() });
                var stringContent = new StringContent(jsonBoleto, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();
                var response = await client.PostAsync("charges", stringContent);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (response.IsSuccessStatusCode)
                {
                    return (data.Charge.Transactions[0].Boleto.pdf, data.Charge.Transactions[0].Boleto.bankLine); //data.Transactions.galaxPayId.ToString()
                }
                else
                {
                    string resultadoerro = JsonConvert.SerializeObject(data.error.details);
                    throw new BadRequestException("Validação GalaxPay - " + resultadoerro.Replace("{", "").Replace("[", "").Replace("}", "").Replace("]", "").Replace("\"", " "));
                }
            }
        }

        public async Task<ChargeReturnModel> ObterBoletoAsync(string chargeId, string empresaId, string empresaHash)
        {
            var token = await ObterTokenAcesso(empresaId, empresaHash);
            using (var client = GetHeaderToken(token))
            {
                var response = await client.GetAsync($"charges?myIds={chargeId}&startAt=0&limit=100");
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<ChargeReturnModel>(content);

                var data = JsonConvert.DeserializeObject<dynamic>(content);
                string resultadoerro = JsonConvert.SerializeObject(data.error.details);
                throw new BadRequestException("Validação GalaxPay - " + resultadoerro.Replace("{", "").Replace("[", "").Replace("}", "").Replace("]", "").Replace("\"", " "));

            }
        }

        public async Task AtualizarBoleto(ChargeModel charge, string empresaId, string empresaHash)
        {
            var token = await ObterTokenAcesso(empresaId, empresaHash);
            using (var client = GetHeaderToken(token))
            {
                var jsonBoleto = JsonConvert.SerializeObject(charge, new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() });
                var stringContent = new StringContent(jsonBoleto, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();
                var response = await client.PutAsync($"charges/{charge.ParcelaId}/myId", stringContent);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (!response.IsSuccessStatusCode)
                {
                    string resultadoerro = JsonConvert.SerializeObject(data.error.details);
                    throw new BadRequestException("Validação GalaxPay - " + resultadoerro.Replace("{", "").Replace("[", "").Replace("}", "").Replace("]", "").Replace("\"", " "));

                }

            }
        }

        public async Task CancelarBoleto(string parcelaId, string empresaId, string empresaHash)
        {
            var token = await ObterTokenAcesso(empresaId, empresaHash);
            using (var client = GetHeaderToken(token))
            {
                var response = await client.DeleteAsync($"charges/{parcelaId}/myId");
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (!response.IsSuccessStatusCode)
                {
                    string resultadoerro = JsonConvert.SerializeObject(data.error.details);
                    throw new BadRequestException("Validação GalaxPay - " + resultadoerro.Replace("{", "").Replace("[", "").Replace("}", "").Replace("]", "").Replace("\"", " "));

                }

            }
        }

        public async Task ObterBoleto(string parcelaId, string empresaId, string empresaHash)
        {
            var token = await ObterTokenAcesso(empresaId, empresaHash);
            using (var client = GetHeaderToken(token))
            {
                var response = await client.GetAsync($"charges/{parcelaId}/myId");
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (!response.IsSuccessStatusCode)
                {
                    string resultadoerro = JsonConvert.SerializeObject(data.error.details);
                    throw new BadRequestException("Validação GalaxPay - " + resultadoerro.Replace("{", "").Replace("[", "").Replace("}", "").Replace("]", "").Replace("\"", " "));

                }

            }
        }
    }
}
