using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Models.Financeiro.Gateway;
using SCAE.Domain.Models.Zoop;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Financeiro.Gateway;
using SCAE.Service.Interfaces.Geral;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Financeiro.Gateway
{
    public class ZoopService : IZoopService
    {
        private readonly ZoopSettingModel _appSettings;
        private readonly IEnderecoService _enderecoService;

        public ZoopService(IOptions<ZoopSettingModel> settings)
        {
            _appSettings = settings.Value;
        }

        public ZoopService(IOptions<ZoopSettingModel> settings, IEnderecoService enderecoService)
        {
            _appSettings = settings.Value;
            _enderecoService = enderecoService;
        }

        private HttpClient GetCabecalho()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_appSettings.UrlBase);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(_appSettings.Token + ":")));

            return client;
        }

        private HttpClient GetCabecalhoBoleto()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_appSettings.UrlBaseBoleto);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(_appSettings.Token + ":")));

            return client;
        }

        public SellerModel ToModelPJ(Empresa empresa)
        {
            if (empresa.Responsavel == null)
                throw new BadRequestException("Informe o responsável da empresa!");

            var estadoEmpresa = string.Empty;
            var estadoResponsavel = string.Empty;
            var municipioEmpresa = string.Empty;
            var municipioResponsavel = string.Empty;

            if (!empresa.Endereco.EstadoId.HasValue || !empresa.Endereco.MunicipioId.HasValue)
                throw new BadRequestException("Estado ou município do empresa não cadastrado");

            //if (empresa.Endereco.Municipio == null || empresa.Endereco.Estado == null)
            //{
            //    estadoEmpresa = (await _enderecoService.ObterEstado(empresa.Endereco.EstadoId)).Uf;
            //    municipioEmpresa = (await _enderecoService.ObterMunicipio(empresa.Endereco.MunicipioId)).Nome;
            //}

            //if (empresa.Responsavel.Endereco.Municipio == null || empresa.Responsavel.Endereco.Estado == null)
            //{
            //    estadoResponsavel = (await _enderecoService.ObterEstado(empresa.Responsavel.Endereco.EstadoId)).Uf;
            //    municipioResponsavel = (await _enderecoService.ObterMunicipio(empresa.Responsavel.Endereco.MunicipioId)).Nome;
            //}

            var seller = new SellerModel()
            {
                Id = empresa.Responsavel.CodigoZoop,
                Cnpj = empresa.CpfCnpjLimpo,
                Nome = empresa.Nome,
                Telefone = empresa.Telefone1,
                Email = empresa.Email,
                Endereco =
                {
                    Logradouro = empresa.Endereco.Logradouro,
                    Numero = empresa.Endereco.Numero,
                    Complemento = empresa.Endereco.Complemento,
                    Cep = empresa.Endereco.Cep,
                    Bairro = empresa.Endereco.Bairro,
                    Cidade = /*string.IsNullOrEmpty(municipioEmpresa) ?*/ empresa.Endereco.Municipio.Nome /*: municipioEmpresa*/,
                    Estado = /*string.IsNullOrEmpty(estadoEmpresa) ?*/ empresa.Endereco.Estado.Uf /*: estadoEmpresa*/
                },
                Categoria = empresa.Responsavel.CodigoCategoriaComerciante.ToString(),
                Proprietario =
                {
                    Cpf = empresa.Responsavel.CpfLimpo,
                    Nome = empresa.Responsavel.Nome,
                    Sobrenome = empresa.Responsavel.Sobrenome,
                    Email = empresa.Responsavel.Email,
                    Telefone = $"+55{empresa.Responsavel.TelefoneLimpo}",
                    DataNascimento = empresa.Responsavel.DataNascimento.ToString("yyyy-MM-dd"),
                },
                ProprietarioEndereco =
                {
                    Logradouro = empresa.Responsavel.Endereco.Logradouro,
                    Numero = empresa.Responsavel.Endereco.Numero,
                    Complemento = empresa.Responsavel.Endereco.Complemento,
                    Cep = empresa.Responsavel.Endereco.Cep,
                    Bairro = empresa.Responsavel.Endereco.Bairro,
                    Cidade = string.IsNullOrEmpty(municipioResponsavel) ? empresa.Responsavel.Endereco.Municipio.Nome : municipioResponsavel,
                    Estado = string.IsNullOrEmpty(estadoResponsavel) ? empresa.Responsavel.Endereco.Estado.Uf : estadoResponsavel,
                }
            };

            return seller;
        }
        public SellerIndividualModel ToModelPF(Empresa empresa)
        {
            if (empresa.Responsavel == null)
                throw new BadRequestException("Informe o responsável da empresa!");

            //var estadoEmpresa = string.Empty;
            //var municipioEmpresa = string.Empty;

            //if (empresa.Endereco.Municipio == null || empresa.Endereco.Estado == null)
            //{
            //    estadoEmpresa = (await _enderecoService.ObterEstado(empresa.Endereco.EstadoId)).Uf;
            //    municipioEmpresa = (await _enderecoService.ObterMunicipio(empresa.Endereco.MunicipioId)).Nome;
            //}

            if (!empresa.Endereco.EstadoId.HasValue || !empresa.Endereco.MunicipioId.HasValue)
                throw new BadRequestException("Estado ou município da empresa não cadastrado");

            var seller = new SellerIndividualModel()
            {
                Id = empresa.Responsavel.CodigoZoop,
                Cpf = empresa.CpfCnpjLimpo,
                Nome = empresa.Nome.Substring(0, empresa.Nome.IndexOf(" ")).Trim(),
                SobreNome = empresa.Nome.Substring(empresa.Nome.IndexOf(" ")).Trim(),
                Telefone = empresa.Telefone1,
                Email = empresa.Email,
                Endereco =
                {
                    Logradouro = empresa.Endereco.Logradouro,
                    Numero = empresa.Endereco.Numero,
                    Complemento = empresa.Endereco.Complemento,
                    Cep = empresa.Endereco.Cep,
                    Bairro = empresa.Endereco.Bairro,
                    Cidade = /*string.IsNullOrEmpty(municipioEmpresa) ?*/ empresa.Endereco.Municipio.Nome /*: municipioEmpresa*/,
                    Estado = /*string.IsNullOrEmpty(estadoEmpresa) ?*/ empresa.Endereco.Estado.Uf /*: estadoEmpresa*/
                },
                Categoria = empresa.Responsavel.CodigoCategoriaComerciante.ToString(),
                DataNascimento = empresa.DataCriacao,
            };

            return seller;
        }

        public BuyerModel ToModel(Pessoa pessoa)
        {
            //var estado = string.Empty;
            //var municipio = string.Empty;

            //if (pessoa.Endereco.Municipio == null || pessoa.Endereco.Estado == null)
            //{
            //    estado = (await _enderecoService.ObterEstado(pessoa.Endereco.EstadoId)).Uf;
            //    municipio = (await _enderecoService.ObterMunicipio(pessoa.Endereco.MunicipioId)).Nome;
            //}

            if (!pessoa.Endereco.EstadoId.HasValue || !pessoa.Endereco.MunicipioId.HasValue)
                throw new BadRequestException("Estado ou município da pessoa não cadastrado");

            var buyer = new BuyerModel()
            {
                Id = pessoa.CodigoZoop,
                CpfCnpj = pessoa.CpfCnpjLimpo,
                Nome = pessoa.Nome,
                Telefone = pessoa.Telefone,
                Email = pessoa.Email,
                Endereco =
                {
                    Logradouro = pessoa.Endereco.Logradouro,
                    Numero = pessoa.Endereco.Numero,
                    Complemento = pessoa.Endereco.Complemento,
                    Cep = pessoa.Endereco.Cep,
                    Bairro = pessoa.Endereco.Bairro,
                    Cidade = /*string.IsNullOrEmpty(municipio) ?*/ pessoa.Endereco.Municipio.Nome /*: municipio*/,
                    Estado = /*string.IsNullOrEmpty(estado) ?*/ pessoa.Endereco.Estado.Uf /*: estado*/
                }
            };

            return buyer;
        }

        public BankAccountModel ToModel(ContaCorrente contaCorrente)
        {
            var model = new BankAccountModel()
            {
                Id = contaCorrente.CodigoZoop,
                Codigo = contaCorrente.Banco.Codigo.ToString().PadLeft(3, '0'),
                RazaoSocial = contaCorrente.Empresa.Nome,
                Agencia = int.Parse(contaCorrente.NumeroAgencia),
                Conta = int.Parse(contaCorrente.ContaNumeroDigito.Replace("-", "")),
                Tipo = contaCorrente.IsPoupanca ? "savings" : "checking"
            };

            if (contaCorrente.Empresa.PessoaJuridica)
                model.Cnpj = contaCorrente.Empresa.CpfCnpjLimpo;
            else
                model.Cpf = contaCorrente.Empresa.CpfCnpjLimpo;

            return model;
        }

        public TransactionModel ToModel(ReceitaParcela parcela, ParametroGatway gateway, string buyerId, string sellerId)
        {
            if (string.IsNullOrEmpty(sellerId))
                throw new BadRequestException("Empresa não integrada com a Zoop");

            if (string.IsNullOrEmpty(buyerId))
                throw new BadRequestException("Cliente não integrado com a Zoop");

            if (gateway == null)
                throw new BadRequestException("Informe o parâmetro de configuração da Zoop");

            if (gateway.TipoId != TipoGateway.Zoop.Id)
                throw new BadRequestException("Este parâmetro de configuração não é Zoop");

            var model = new TransactionModel()
            {
                Id = parcela.CodigoZoop,
                SellerId = sellerId,
                BuyerId = buyerId,
                ReferenciaId = parcela.Id.ToString(),
                Valor = int.Parse(StringHelper.FormataValor(parcela.Valor)),
                Metodo = {
                    DataVencimento = parcela.DataVencimento,
                    IntrucaoCobranca =
                    {
                        Multa = {
                            Porcentagem = parcela.EncargoFinanceiro.Multa
                        },
                        Juros =
                        {
                            Porcentagem = parcela.EncargoFinanceiro.JurosDia
                        }
                    }
                },
            };

            if (parcela.EncargoFinanceiro.DescontoVencimento > 0)
            {
                model.Metodo.IntrucaoCobranca.Descontos = new List<DescontoModel>();
                var desconto = new DescontoModel()
                {
                    Modo = "PERCENTAGE",
                    Porcentagem = parcela.EncargoFinanceiro.DescontoVencimento,
                    DataLimite = parcela.DataVencimento
                        .AddDays(Convert.ToInt32(parcela.EncargoFinanceiro.DiasDescontoVencimento) * -1)
                };
                model.Metodo.IntrucaoCobranca.Descontos.Add(desconto);
            }

            if (parcela.EncargoFinanceiro.DiasAposVencimentoNaoReceber > 0)
                model.Metodo.DataLimite = parcela.DataVencimento.AddDays(parcela.EncargoFinanceiro.DiasAposVencimentoNaoReceber);

            if (!string.IsNullOrEmpty(parcela.Instrucao1))
                model.Metodo.Instrucoes.Add(parcela.Instrucao1);

            if (!string.IsNullOrEmpty(parcela.Instrucao2))
                model.Metodo.Instrucoes.Add(parcela.Instrucao2);

            if (!string.IsNullOrEmpty(parcela.Instrucao3))
                model.Metodo.Instrucoes.Add(parcela.Instrucao3);
            else if (!string.IsNullOrEmpty(gateway.Instrucao1))
                model.Metodo.Instrucoes.Add(gateway.Instrucao1);

            if (!string.IsNullOrEmpty(gateway.Instrucao2))
                model.Metodo.Instrucoes.Add(gateway.Instrucao2);

            if (!string.IsNullOrEmpty(gateway.Instrucao3))
                model.Metodo.Instrucoes.Add(gateway.Instrucao3);

            return model;
        }

        public async Task<string> CriarVendedor(SellerModel seller)
        {
            //seller.Cnpj = string.Empty;
            using (var client = GetCabecalho())
            {
                var jsonVenda = JsonConvert.SerializeObject(seller, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(jsonVenda, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();
                var response = await client.PostAsync("sellers/businesses", stringContent);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (response.IsSuccessStatusCode)
                {
                    return data.id;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    if (data.error.category == "duplicate_taxpayer_id")
                    {
                        var sellerExisting = await ObterPorCnpj(seller.Cnpj);

                        return sellerExisting?.Id;
                    }
                }

                throw new BadRequestException(data.GetValue("error").GetValue("message").ToString());
            }
        }

        public async Task<string> CriarVendedor(SellerIndividualModel seller)
        {
            //seller.Cnpj = string.Empty;
            using (var client = GetCabecalho())
            {
                var jsonVenda = JsonConvert.SerializeObject(seller, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(jsonVenda, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();
                var response = await client.PostAsync("sellers/individuals", stringContent);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (response.IsSuccessStatusCode)
                {
                    return data.id;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    if (data.error.category == "duplicate_taxpayer_id")
                    {
                        var sellerExisting = await ObterPorCpf(seller.Cpf);

                        return sellerExisting?.Id;
                    }
                }

                throw new BadRequestException(data.GetValue("error").GetValue("message").ToString());
            }
        }

        public async Task<SellerModel> ObterPorCnpj(string cnpj)
        {
            using (var client = GetCabecalho())
            {
                var response = await client.GetAsync($"sellers/search?ein={cnpj}");
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<SellerModel>(content);

                var data = JsonConvert.DeserializeObject<dynamic>(content);
                var erro = data.GetValue("error").GetValue("message").ToString();
                throw new BadRequestException(erro);
            }
        }

        public async Task<SellerIndividualModel> ObterPorCpf(string cpf)
        {
            using (var client = GetCabecalho())
            {
                var response = await client.GetAsync($"sellers/search?ein={cpf}");
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<SellerIndividualModel>(content);

                var data = JsonConvert.DeserializeObject<dynamic>(content);
                var erro = data.GetValue("error").GetValue("message").ToString();
                throw new BadRequestException(erro);
            }
        }

        public async Task AtualizarVendedor(SellerModel seller)
        {
            if (string.IsNullOrEmpty(seller.Id))
                throw new BadRequestException("Informe o id!");

            using (var client = GetCabecalho())
            {
                var jsonVenda = JsonConvert.SerializeObject(seller, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(jsonVenda, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();
                var response = await client.PutAsync($"sellers/businesses/{seller.Id}", stringContent);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (!response.IsSuccessStatusCode)
                    throw new BadRequestException(data.GetValue("error").GetValue("message").ToString());
            }
        }

        public async Task AtualizarVendedor(SellerIndividualModel seller)
        {
            if (string.IsNullOrEmpty(seller.Id))
                throw new BadRequestException("Informe o id!");

            using (var client = GetCabecalho())
            {
                var jsonVenda = JsonConvert.SerializeObject(seller, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(jsonVenda, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();
                var response = await client.PutAsync($"sellers/individuals/{seller.Id}", stringContent);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (!response.IsSuccessStatusCode)
                    throw new BadRequestException(data.GetValue("error").GetValue("message").ToString());
            }
        }

        public async Task EnviarDocumentoVendedor(string id, byte[] documento, string categoria, string descricao)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("category", categoria);
            parameters.Add("description", descricao);
            var dictionaryItems = new FormUrlEncodedContent(parameters);

            using (var client = GetCabecalho())
            {
                using (var formData = new MultipartFormDataContent())
                {
                    formData.Add(new StreamContent(new MemoryStream(documento)), "file", "residencial.pdf");
                    formData.Add(dictionaryItems, "parametros");

                    var response = await client.PostAsync($"sellers/{id}/documents", formData);
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<dynamic>(content);

                    if (!response.IsSuccessStatusCode)
                        throw new BadRequestException(data.GetValue("error").GetValue("message").ToString());
                }
            }

        }

        public async Task<ReturnBankAccountModel> CriarContaBancaria(BankAccountModel bank)
        {
            using (var client = GetCabecalho())
            {
                var jsonVenda = JsonConvert.SerializeObject(bank, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(jsonVenda, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();
                var response = await client.PostAsync("bank_accounts/tokens", stringContent);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (response.IsSuccessStatusCode)
                    return new ReturnBankAccountModel(data.id.ToString(), data.bank_account.id.ToString());
                else
                    throw new BadRequestException(data.GetValue("error").GetValue("message").ToString());
            }
        }

        public async Task<string> AssociarContaBancaria(string sellerId, string tokenId)
        {
            using (var client = GetCabecalho())
            {
                var model = new
                {
                    customer = sellerId,
                    token = tokenId
                };

                var jsonVenda = JsonConvert.SerializeObject(model, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(jsonVenda, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();
                var response = await client.PostAsync("bank_accounts", stringContent);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (response.IsSuccessStatusCode)
                    return data.id;
                else
                    throw new BadRequestException(data.GetValue("error").GetValue("message").ToString());
            }
        }

        public async Task ExcluirContaBancaria(string id)
        {
            using (var client = GetCabecalho())
            {
                var response = await client.DeleteAsync($"bank_accounts/{id}");
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (!response.IsSuccessStatusCode)
                    throw new BadRequestException(data.GetValue("error").GetValue("message").ToString());
            }
        }

        public async Task<string> CriarComprador(BuyerModel buyer)
        {
            using (var client = GetCabecalho())
            {
                var jsonVenda = JsonConvert.SerializeObject(buyer, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(jsonVenda, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();
                var response = await client.PostAsync("buyers", stringContent);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (response.IsSuccessStatusCode)
                {
                    return data.id;
                }
                else
                {
                    throw new BadRequestException(data.GetValue("error").GetValue("message").ToString());
                }
            }
        }

        public async Task AtualizarComprador(BuyerModel buyer)
        {
            if (string.IsNullOrEmpty(buyer.Id))
                throw new BadRequestException("Informe o id!");

            using (var client = GetCabecalho())
            {
                var jsonVenda = JsonConvert.SerializeObject(buyer, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(jsonVenda, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();
                var response = await client.PutAsync($"buyers/{buyer.Id}", stringContent);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (!response.IsSuccessStatusCode)
                    throw new BadRequestException(data.GetValue("error").GetValue("message").ToString());
            }
        }

        public async Task ExcluirComprador(string id)
        {
            using (var client = GetCabecalho())
            {
                var response = await client.DeleteAsync($"buyers/{id}");
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (!response.IsSuccessStatusCode)
                    throw new BadRequestException(data.GetValue("error").GetValue("message").ToString());
            }
        }

        public async Task<Tuple<string, string, string>> CriarBoleto(TransactionModel transaction)
        {
            using (var client = GetCabecalho())
            {
                var jsonVenda = JsonConvert.SerializeObject(transaction, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(jsonVenda, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();
                var response = await client.PostAsync("transactions", stringContent);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (response.IsSuccessStatusCode)
                {
                    return new Tuple<string, string, string>(data.id.ToString(), data.payment_method.url.ToString(), data.payment_method.barcode.ToString());
                }
                else
                {

#if (!DEBUG)
                    File.WriteAllText($"/tmp/{transaction.SellerId}-{transaction.ReferenciaId}.json", jsonVenda);
#endif

                    var titulo = data.GetValue("error").GetValue("message").ToString();

                    var erros = data.GetValue("error").GetValue("reasons") == null ? string.Empty : data.GetValue("error").GetValue("reasons").ToObject<List<string>>();


                    throw new BadRequestException($"{titulo}: {string.Join(",", erros)}");
                }
            }
        }

        public async Task AtualizarBoleto(TransactionModel transaction)
        {
            if (string.IsNullOrEmpty(transaction.Id))
                throw new BadRequestException("Informe o id!");

            using (var client = GetCabecalho())
            {
                var jsonVenda = JsonConvert.SerializeObject(transaction, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(jsonVenda, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();
                var response = await client.PutAsync($"transactions/{transaction.Id}", stringContent);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (!response.IsSuccessStatusCode)
                    throw new BadRequestException(data.GetValue("error").GetValue("message").ToString());
            }
        }

        public async Task<TransactionReturnModel> ObterBoletoAsync(string transactionId)
        {
            using (var client = GetCabecalho())
            {
                var response = await client.GetAsync($"transactions/{transactionId}");
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<TransactionReturnModel>(content);

                var data = JsonConvert.DeserializeObject<dynamic>(content);
                var titulo = data.GetValue("error").GetValue("message").ToString();
                throw new BadRequestException(titulo);
            }
        }

        public TransactionModel ObterBoleto(string transactionId)
        {
            using (var client = GetCabecalho())
            {
                var response = client.GetAsync($"transactions/{transactionId}").Result;
                var content = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<TransactionModel>(content);

                var data = JsonConvert.DeserializeObject<dynamic>(content);
                var titulo = data.GetValue("error").GetValue("message").ToString();
                throw new BadRequestException(titulo);
            }
        }

        public async Task CancelarBoleto(string transactionId)
        {
            using (var client = GetCabecalhoBoleto())
            {
                var response = await client.PostAsync($"transactions/{transactionId}", null);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (!response.IsSuccessStatusCode)
                {
                    var status = data.GetValue("status").ToString();
                    var mensagem = data.GetValue("message").ToString();

                    throw new BadRequestException($"{status}: {mensagem}");
                }
            }
        }

        public async Task<SaldoModel> ObterSaldoPorVendedor(string sellerId)
        {
            using (var client = GetCabecalho())
            {
                var response = await client.GetAsync($"sellers/{sellerId}/balances");
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (response.IsSuccessStatusCode)
                {
                    return new SaldoModel()
                    {
                        ACompensar = data.items.current_balance,
                        Bloqueado = data.items.current_blocked_balance,
                        Disponivel = data.items.account_balance
                    };
                }
                else
                {
                    var titulo = data.GetValue("error").GetValue("message").ToString();
                    throw new BadRequestException(titulo);
                }
            }
        }

        public async Task Transferir(string bankAccountId, TransferModel transfer)
        {
            using (var client = GetCabecalho())
            {
                var json = JsonConvert.SerializeObject(transfer, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();
                var response = await client.PostAsync($"bank_accounts/{bankAccountId}/transfers", stringContent);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (!response.IsSuccessStatusCode)
                {
                    var titulo = data.GetValue("error").GetValue("message").ToString();
                    throw new BadRequestException(titulo);
                }
            }
        }

        public async Task<BalanceInputModel> ListarTransferencias(string sellerId, int limit, int offset)
        {
            using (var client = GetCabecalho())
            {
                var response = await client.GetAsync($"sellers/{sellerId}/transfers?limit={limit}&offset={offset}");
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (response.IsSuccessStatusCode)
                {
                    return new BalanceInputModel();
                }
                else
                {
                    var titulo = data.GetValue("error").GetValue("message").ToString();
                    var erros = data.GetValue("error").GetValue("reasons").ToObject<List<string>>();
                    throw new BadRequestException($"{titulo}: {string.Join(",", erros)}");
                }
            }
        }

        public async Task<List<BalanceOutputModel>> Extrato(string sellerId, DateTime dataInicial, DateTime dataFinal,
            string tipo, int? limit, int? offset)
        {
            using (var client = GetCabecalho())
            {
                var parametro = new StringBuilder("?");
                parametro.Append($"created_date_range[gte]={dataInicial:yyyy-MM-dd}");
                parametro.Append($"&created_date_range[lte]={dataFinal:yyyy-MM-dd}");

                if (string.IsNullOrEmpty(tipo))
                    parametro.Append($"&type={tipo}");

                if (limit.HasValue)
                    parametro.Append($"&limit={limit}");

                if (offset.HasValue)
                    parametro.Append($"&offset={offset}");

                var response = await client.GetAsync($"sellers/{sellerId}/balances/history{parametro}");
                var content = await response.Content.ReadAsStringAsync();
                var balances = new List<BalanceOutputModel>();

                if (response.IsSuccessStatusCode)
                {
                    var extrato = JsonConvert.DeserializeObject<BalanceInputModel>(content);

                    foreach (var item in extrato.Items)
                    {
                        var balance = new BalanceOutputModel()
                        {
                            Data = item.Key,
                            ValorAtual = item.Value.ValorAtual,
                            ValorAtualBloqueado = item.Value.ValorAtualBloqueado,
                        };

                        foreach (var subItem in item.Value.Itens)
                        {
                            balance.Itens.Add(new BalanceOutputItemModel()
                            {
                                DataHora = subItem.DataHora,
                                Descricao = subItem.Descricao,
                                Tipo = subItem.Tipo,
                                SaldoAtual = subItem.SaldoAtual,
                                Valor = subItem.Valor
                            });
                        }

                        balances.Add(balance);
                    }

                    return balances;
                }

                var data = JsonConvert.DeserializeObject<dynamic>(content);
                var titulo = data.GetValue("error").GetValue("message").ToString();
                throw new BadRequestException(titulo);
            }
        }
    }
}
