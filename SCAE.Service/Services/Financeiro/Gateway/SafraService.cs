using Microsoft.Extensions.Options;
using SCAE.Domain.Models.Financeiro.Gateway;
using SCAE.Service.Interfaces.Financeiro.Gateway;
using System.Net.Http.Headers;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using SCAE.Framework.Exceptions;
using Newtonsoft.Json.Serialization;
using System.Text;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Data.Interface.Provider;
using SCAE.Service.Interfaces.Geral;
using SCAE.Framework.Helper;
using System.IO;

namespace SCAE.Service.Services.Financeiro.Gateway
{
    public class SafraService : ISafraService
    {
        private readonly SafraSettingModel _appSettings;
        private readonly IAssinanteProvider _provider;
        private readonly IEnderecoService _enderecoService;

        public SafraService(IOptions<SafraSettingModel> appSettings, IAssinanteProvider provider, IEnderecoService enderecoService)
        {
            _appSettings = appSettings.Value;
            _provider = provider;
            _enderecoService = enderecoService;
        }

        private HttpClient GetCabecalho()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_appSettings.UrlBase);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

            return client;
        }

        private HttpClient GetCabecalho(string token)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_appSettings.UrlBase);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Safra-Correlation-ID", "1");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return client;
        }

        public async Task<string> GetToken(string clientId, string userName, string password)
        {
            using (var client = GetCabecalho())
            {
                var content = new FormUrlEncodedContent(new[]                            {
                    new KeyValuePair<string, string>("client_id", clientId),
                    new KeyValuePair<string, string>("username", userName),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("grant_type", "password")
                });

                //client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");

                var response = await client.PostAsync("v1/oauth2/token", content);

                if (!response.IsSuccessStatusCode)
                    throw new BadRequestException("Algum problema ocorreu ao tentar obter o token do banco Safra!");

                var result = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(result);

                return data.access_token;
            };
        }

        private async void GravarJson(string texto)
        {
            using (var writer = File.CreateText("json-safra.txt"))
            {
                await writer.WriteLineAsync(texto);
            }
        }

        public async Task<Tuple<string, string, string>> CriarBoleto(string token, BoletoSafraModel boleto)
        {
            using (var client = GetCabecalho(token))
            {
                var json = JsonConvert.SerializeObject(boleto, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

                GravarJson(json);

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("cobrancas/v1/boletos", content);
                var result = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(result);

                if (!response.IsSuccessStatusCode)
                    throw new BadRequestException($"Erro: {data.message}");

                var guid = Guid.NewGuid().ToString().Replace("-", "");
                var url = $"{_provider.GetHost(false)}/boleto/{guid}";
                string codigobarras = data.data.codigoBarras;
                //return new Tuple<string, string, string>(data.data.numero, "", data.data.codigoBarras);
                return new Tuple<string, string, string>(guid, url, codigobarras);
            }
        }

        public BoletoSafraModel ToModel(ReceitaParcela parcela, ParametroGatway gateway)
        {
            var cliente = parcela.Receita.Cliente;
            //var estado = string.Empty;
            //var municipio = string.Empty;

            //if (cliente.Endereco.Municipio == null || cliente.Endereco.Estado == null)
            //{
            //    estado = (await _enderecoService.ObterEstado(cliente.Endereco.EstadoId)).Uf;
            //    municipio = (await _enderecoService.ObterMunicipio(cliente.Endereco.MunicipioId)).Nome;
            //}

            if (!cliente.Endereco.EstadoId.HasValue || !cliente.Endereco.MunicipioId.HasValue)
                throw new BadRequestException("Estado ou município do cliente não cadastrado");

            var model = new BoletoSafraModel()
            {
                Agencia = int.Parse(StringHelper.RemoverHifen(gateway.Safra.Agencia)),
                Conta = int.Parse(StringHelper.RemoverHifen(gateway.Safra.Conta)),
                Documento =
                {
                    Numero = parcela.NossoNumero,
                    NumeroCliente = parcela.NossoNumero,
                    DiasDevolucao = 0,
                    Especie = "01",
                    DataVencimento = parcela.DataVencimento.ToString("yyyy-MM-dd"),
                    Valor = parcela.Valor,
                    CodigoMoeda = 9,
                    QuantidadeDiasProtesto = 0, //*
                    IdentificacaoAceite = 'N',
                    CampoLivre = string.Empty,
                    ValorAbatimento = 0,
                    Pagador =
                    {
                        Nome = cliente.Nome.ToUpper(),
                        TipoPessoa = cliente.TipoPessoaId == TipoPessoa.Juridica.Id ? 'J' : 'F',
                        NumeroDocumento = cliente.CpfCnpjLimpo,
                        Endereco =
                        {
                            Logradouro = $"{cliente.Endereco.Logradouro.ToUpper()}, {cliente.Endereco.Numero}",
                            Bairro = cliente.Endereco.Bairro.Length > 10 ? cliente.Endereco.Bairro.ToUpper().Substring(0,10) : cliente.Endereco.Bairro.ToUpper(),
                            Cep = StringHelper.RemoverHifen(cliente.Endereco.Cep),
                            Uf = /*string.IsNullOrEmpty(estado) ?*/ cliente.Endereco.Estado.Uf.ToUpper() /*: estado.ToUpper()*/,
                            Cidade = /*string.IsNullOrEmpty(municipio) ?*/ cliente.Endereco.Municipio.Nome.Length > 13 ? cliente.Endereco.Municipio.Nome.ToUpper().Substring(0,13) : cliente.Endereco.Municipio.Nome.ToUpper() /*: municipio.Length > 13 ? municipio.ToUpper().Substring(0,13) : municipio.ToUpper(),*/
                        }
                    },
                    Multa =
                    {
                        dataMulta = parcela.DataVencimento.AddDays(1).ToString("yyyy-MM-dd"),
                        TaxaMulta = parcela.EncargoFinanceiro.Multa,
                        dataJuros =parcela.DataVencimento.AddDays(1).ToString("yyyy-MM-dd"),
                        TaxaJuros = parcela.EncargoFinanceiro.JurosDia,
                    }
                },

            };

            if (parcela.EncargoFinanceiro.DescontoVencimento > 0)
            {
                model.Documento.Desconto = new BoletoSafraDescontoModel();
                model.Documento.Desconto.Valor = parcela.Valor * (parcela.EncargoFinanceiro.DescontoVencimento / 100);
                model.Documento.Desconto.Data = parcela.DataVencimento
                        .AddDays(Convert.ToInt32(parcela.EncargoFinanceiro.DiasDescontoVencimento) * -1).ToString("yyyy-MM-dd");
            }

            if (!string.IsNullOrEmpty(parcela.Instrucao1))
                model.Documento.Mensagens.Add(new BoletoSafraMensagemModel("1", parcela.Instrucao1));

            if (!string.IsNullOrEmpty(parcela.Instrucao2))
                model.Documento.Mensagens.Add(new BoletoSafraMensagemModel("2", parcela.Instrucao2));

            if (!string.IsNullOrEmpty(parcela.Instrucao3))
                model.Documento.Mensagens.Add(new BoletoSafraMensagemModel("3", parcela.Instrucao3));
            else if (!string.IsNullOrEmpty(gateway.Instrucao1))
                model.Documento.Mensagens.Add(new BoletoSafraMensagemModel("3", gateway.Instrucao1));

            if (!string.IsNullOrEmpty(gateway.Instrucao1))
                model.Documento.Mensagens.Add(new BoletoSafraMensagemModel("4", gateway.Instrucao2));

            if (!string.IsNullOrEmpty(gateway.Instrucao1))
                model.Documento.Mensagens.Add(new BoletoSafraMensagemModel("5", gateway.Instrucao3));

            return model;
        }
    }
}
