using Microsoft.Extensions.Options;
using SCAE.Service.Interfaces.Geral;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SCAE.Framework.Exceptions;
using SCAE.Service.Interfaces.Financeiro.ApiFinanceiro;
using Newtonsoft.Json.Serialization;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Gateway;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro;
using SCAE.Domain.Entities.Geral;
using System.Collections.Generic;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Shared;
using System.Linq;
using SCAE.Service.Interfaces.Compras;
using SCAE.Domain.Models.GalaxPay;
using SCAE.Framework.Helper;
using static System.Runtime.InteropServices.JavaScript.JSType;
using BoletoNetCore;
using System.Globalization;

namespace SCAE.Service.Services.Financeiro.ApiFinanceiro
{
    public class GatewayService : ApiFinanceiroBaseService, IGatewayService
    {
        public GatewayService(IOptions<ApiFinanceiroSettingModel> settings) : base(settings)
        {
        }

        public GatewayService(IOptions<ApiFinanceiroSettingModel> settings, IEnderecoService enderecoService) : base(settings, enderecoService)
        {
        }

        public ContaBancariaModel ToModelConta(ContaCorrente contaCorrente)
        {
            var conta = new ContaBancariaModel()
            {
                Codigo = contaCorrente.CodigoZoop,
                CodigoBanco = contaCorrente.Banco.Codigo,
                Titular = contaCorrente.Empresa.Nome,
                Agencia = contaCorrente.NumeroAgencia,
                Conta = contaCorrente.NumeroConta,
                Poupanca = contaCorrente.IsPoupanca,
                DigitoAgencia = contaCorrente.DigitoAgencia,
                DigitoConta = contaCorrente.DigitoConta
            };

            if (contaCorrente.Empresa.PessoaJuridica)
                conta.Cnpj = contaCorrente.Empresa.CpfCnpjLimpo;
            else
                conta.Cpf = contaCorrente.Empresa.CpfCnpjLimpo;

            return conta;
        }

        public async Task<BeneficiarioPessoaFisicaModel> ToModelPF(Empresa empresa)
        {
            var estadoUf = string.Empty;
            var municipioNome = string.Empty;

            if (!empresa.Endereco.EstadoId.HasValue || !empresa.Endereco.MunicipioId.HasValue)
            {
                throw new BadRequestException("Estado ou município da empresa não cadastrado");
            }

            if (empresa.Endereco.Municipio == null || empresa.Endereco.Estado == null)
            {
                estadoUf = (await _enderecoService.ObterEstado(empresa.Endereco.EstadoId.Value)).Uf;
                municipioNome = (await _enderecoService.ObterMunicipio(empresa.Endereco.MunicipioId.Value)).Nome;
            }

            if (empresa.Responsavel == null)
                throw new BadRequestException("Informe o responsável da empresa!");

            var beneficiario = new BeneficiarioPessoaFisicaModel()
            {
                Codigo = empresa.Responsavel.CodigoZoop, //mudar quando criar a tabela nova
                Cpf = empresa.CpfCnpjLimpo,
                Nome = empresa.Nome,
                Telefone = empresa.Telefone1,
                Email = empresa.Email,
                Categoria = empresa.Responsavel.CodigoCategoriaComerciante.ToString(),
                DataNascimento = empresa.DataCriacao,
                Endereco =
                {
                    Logradouro = empresa.Endereco.Logradouro,
                    Numero = empresa.Endereco.Numero,
                    Complemento = empresa.Endereco.Complemento,
                    Cep = empresa.Endereco.Cep,
                    Bairro = empresa.Endereco.Bairro,
                    Cidade = string.IsNullOrEmpty(municipioNome) ? empresa.Endereco.Municipio.Nome : municipioNome,
                    Uf = string.IsNullOrEmpty(estadoUf) ? empresa.Endereco.Estado.Uf : estadoUf
                }
            };

            return beneficiario;
        }

        public async Task<BeneficiarioPessoaJuridicaModel> ToModelPJ(Empresa empresa)
        {
            if (!empresa.Endereco.EstadoId.HasValue || !empresa.Endereco.MunicipioId.HasValue)
                throw new BadRequestException("Estado ou município da empresa não cadastrado");


            if (empresa.Responsavel == null)
                throw new BadRequestException("Informe o responsável da empresa!");

            var estadoEmpresaUf = string.Empty;
            var estadoResponsavelUf = string.Empty;
            var municipioEmpresaNome = string.Empty;
            var municipioResponsavelNome = string.Empty;

            if (empresa.Endereco.Municipio == null || empresa.Endereco.Estado == null)
            {
                estadoEmpresaUf = (await _enderecoService.ObterEstado(empresa.Endereco.EstadoId.Value)).Uf;
                municipioEmpresaNome = (await _enderecoService.ObterMunicipio(empresa.Endereco.MunicipioId.Value)).Nome;
            }

            if (empresa.Responsavel.Endereco.Municipio == null || empresa.Responsavel.Endereco.Estado == null)
            {
                estadoResponsavelUf = (await _enderecoService.ObterEstado(empresa.Responsavel.Endereco.EstadoId.Value)).Uf;
                municipioResponsavelNome = (await _enderecoService.ObterMunicipio(empresa.Responsavel.Endereco.MunicipioId.Value)).Nome;
            }



            var beneficiario = new BeneficiarioPessoaJuridicaModel()
            {
                Codigo = empresa.Responsavel.CodigoZoop, //mudar quando criar a tabela nova
                Cnpj = empresa.CpfCnpjLimpo,
                Nome = empresa.Nome,
                Telefone = empresa.Telefone1,
                Email = empresa.Email,
                Categoria = empresa.Responsavel.CodigoCategoriaComerciante.ToString(),
                Banco = new BancoInfo
                {
                    Agencia = empresa.BancoInfoEmpresa.Agencia ?? "",
                    ChavePix = empresa.BancoInfoEmpresa.ChavePix ?? "",
                    CodigoBanco = empresa.BancoInfoEmpresa.CodigoBanco ?? "",
                    NumeroConta = empresa.BancoInfoEmpresa.NumeroConta ?? ""
                },
                Endereco =
                {
                    Logradouro = empresa.Endereco.Logradouro,
                    Numero = empresa.Endereco.Numero,
                    Complemento = empresa.Endereco.Complemento,
                    Cep = empresa.Endereco.Cep,
                    Bairro = empresa.Endereco.Bairro,
                    Cidade = string.IsNullOrEmpty(municipioEmpresaNome) ? empresa.Endereco.Municipio.Nome : municipioEmpresaNome,
                    Uf = string.IsNullOrEmpty(estadoEmpresaUf) ?  empresa.Endereco.Estado.Uf : estadoEmpresaUf
                },
                Proprietario =
                {
                    Cpf = empresa.Responsavel.CpfLimpo,
                    Nome = $"{ empresa.Responsavel.Nome } {empresa.Responsavel.Sobrenome}",
                    Email = empresa.Responsavel.Email,
                    Telefone = $"+55{empresa.Responsavel.TelefoneLimpo}",
                    DataNascimento = empresa.Responsavel.DataNascimento,
                    Endereco =
                    {
                        Logradouro = empresa.Responsavel.Endereco.Logradouro,
                        Numero = empresa.Responsavel.Endereco.Numero,
                        Complemento = empresa.Responsavel.Endereco.Complemento,
                        Cep = empresa.Responsavel.Endereco.Cep,
                        Bairro = empresa.Responsavel.Endereco.Bairro,
                        Cidade = string.IsNullOrEmpty(municipioResponsavelNome) ? empresa.Responsavel.Endereco.Municipio.Nome : municipioResponsavelNome,
                        Uf = string.IsNullOrEmpty(estadoResponsavelUf) ? empresa.Responsavel.Endereco.Estado.Uf : estadoResponsavelUf
                    }
                }

            };

            return beneficiario;
        }

        public async Task<PagadorModel> ToModelPessoa(EnumGateway gateway, Pessoa pessoa)
        {
            if (pessoa == null)
                return null;

            if (!pessoa.Endereco.EstadoId.HasValue || !pessoa.Endereco.MunicipioId.HasValue)
                throw new BadRequestException("Estado ou município da pessoa não cadastrado");

            var estadoUf = string.Empty;
            var municipioNome = string.Empty;

            if (pessoa.Endereco.Municipio == null || pessoa.Endereco.Estado == null)
            {
                estadoUf = (await _enderecoService.ObterEstado(pessoa.Endereco.EstadoId.Value)).Uf;
                municipioNome = (await _enderecoService.ObterMunicipio(pessoa.Endereco.MunicipioId.Value)).Nome;
            }




            var model = new PagadorModel()
            {
                Codigo = pessoa.Id.ToString(),
                CpfCnpj = pessoa.CnpjCpf,
                Email = pessoa.Email,
                Nome = pessoa.Nome,
                Telefone = pessoa.Telefone,
                DataNascimento = pessoa.DataNascimento ?? new DateTime(),
                Endereco =
                {
                    Logradouro = pessoa.Endereco.Logradouro,
                    Numero = pessoa.Endereco.Numero,
                    Complemento = pessoa.Endereco.Complemento,
                    Cep = pessoa.Endereco.Cep,
                    Bairro = pessoa.Endereco.Bairro,
                    Cidade = string.IsNullOrEmpty(municipioNome) ? pessoa.Endereco.Municipio.Nome : municipioNome,
                    Uf = string.IsNullOrEmpty(estadoUf) ? pessoa.Endereco.Estado.Uf : estadoUf
                }
            };

            if (gateway == EnumGateway.Zoop)
            {
                model.Codigo = pessoa.CodigoZoop;
            }

            model.banco = new BancoInfo
            {
                Agencia = pessoa.BancoInfoPessoa.Agencia ?? "",
                CodigoBanco = pessoa.BancoInfoPessoa.CodigoBanco ?? "",
                ChavePix = pessoa.BancoInfoPessoa.ChavePix ?? "",
                NumeroConta = pessoa.BancoInfoPessoa.NumeroConta ?? ""
            };

            return model;
        }

        public async Task<PagadorModel> ToModelPessoaBoleto(EnumGateway gateway, Pessoa pessoa)
        {
            if (pessoa == null)
                return null;

            if (!pessoa.Endereco.EstadoId.HasValue || !pessoa.Endereco.MunicipioId.HasValue)
                throw new BadRequestException("Estado ou município da pessoa não cadastrado");

            var estadoUf = string.Empty;
            var municipioNome = string.Empty;

            if (pessoa.Endereco.Municipio == null || pessoa.Endereco.Estado == null)
            {
                estadoUf = (await _enderecoService.ObterEstado(pessoa.Endereco.EstadoId.Value)).Uf;
                municipioNome = (await _enderecoService.ObterMunicipio(pessoa.Endereco.MunicipioId.Value)).Nome;
            }




            var model = new PagadorModel()
            {
                Codigo = pessoa.Id.ToString(),
                CpfCnpj = pessoa.CnpjCpf,
                Email = pessoa.Email,
                Nome = pessoa.Nome,
                Telefone = pessoa.Telefone,
                DataNascimento = pessoa.DataNascimento ?? new DateTime(),
                Endereco =
                {
                    Logradouro = pessoa.Endereco.Logradouro,
                    Numero = pessoa.Endereco.Numero,
                    Complemento = pessoa.Endereco.Complemento,
                    Cep = pessoa.Endereco.Cep,
                    Bairro = pessoa.Endereco.Bairro,
                    Cidade = string.IsNullOrEmpty(municipioNome) ? pessoa.Endereco.Municipio.Nome : municipioNome,
                    Uf = string.IsNullOrEmpty(estadoUf) ? pessoa.Endereco.Estado.Uf : estadoUf
                }
            };

            if (gateway == EnumGateway.Zoop)
            {
                model.Codigo = pessoa.CodigoZoop;
            }
            if (gateway == EnumGateway.Global)
            {
                model.Codigo = pessoa.Gateways.First(x => x.TipoGatewayId == TipoGateway.Global.Id).CodigoIntegracao;
            }

            model.banco = new BancoInfo
            {
                Agencia = pessoa.BancoInfoPessoa.Agencia ?? "",
                CodigoBanco = pessoa.BancoInfoPessoa.CodigoBanco ?? "",
                ChavePix = pessoa.BancoInfoPessoa.ChavePix ?? "",
                NumeroConta = pessoa.BancoInfoPessoa.NumeroConta ?? ""
            };

            return model;
        }

        public async Task<PagadorModel> ToModelEmpresa(EnumGateway gateway, Empresa empresa)
        {
            if (empresa == null)
                return null;

            if (!empresa.Endereco.EstadoId.HasValue || !empresa.Endereco.MunicipioId.HasValue)
                throw new BadRequestException("Estado ou município da pessoa não cadastrado");

            var estadoUf = string.Empty;
            var municipioNome = string.Empty;

            if (empresa.Endereco.Municipio == null || empresa.Endereco.Estado == null)
            {
                estadoUf = (await _enderecoService.ObterEstado(empresa.Endereco.EstadoId.Value)).Uf;
                municipioNome = (await _enderecoService.ObterMunicipio(empresa.Endereco.MunicipioId.Value)).Nome;
            }




            var model = new PagadorModel()
            {
                Codigo = empresa.Id.ToString(),
                CpfCnpj = empresa.Responsavel.CpfLimpo,
                Email = empresa.Email,
                Nome = empresa.Nome,
                Telefone = empresa.Responsavel.Telefone,
                DataNascimento = empresa.Responsavel.DataNascimento,
                Endereco =
                {
                    Logradouro = empresa.Endereco.Logradouro,
                    Numero = empresa.Endereco.Numero,
                    Complemento = empresa.Endereco.Complemento,
                    Cep = empresa.Endereco.Cep,
                    Bairro = empresa.Endereco.Bairro,
                    Cidade = string.IsNullOrEmpty(municipioNome) ? empresa.Endereco.Municipio.Nome : municipioNome,
                    Uf = string.IsNullOrEmpty(estadoUf) ? empresa.Endereco.Estado.Uf : estadoUf
                }
            };

            if (gateway == EnumGateway.Zoop)
            {
                model.Codigo = empresa.Responsavel.CodigoZoop;
            }
            if (gateway == EnumGateway.Global)
            {
                model.Codigo = empresa.Gateways.First(x => x.TipoGatewayId == TipoGateway.Global.Id).CodigoIntegracao;
            }

            model.banco = new BancoInfo
            {
                Agencia = empresa.BancoInfoEmpresa.Agencia ?? "",
                CodigoBanco = empresa.BancoInfoEmpresa.CodigoBanco ?? "",
                ChavePix = empresa.BancoInfoEmpresa.ChavePix ?? "",
                NumeroConta = empresa.BancoInfoEmpresa.NumeroConta ?? ""
            };

            return model;
        }
        public async Task<BoletoModel> ToModel(EnumGateway gateway, ReceitaParcela parcela, Pessoa pagador, Empresa beneficiario, string dominioAssinante)
        {
            var codigoPagador = pagador.Gateways.Where(x => x.TipoGatewayId == (int)gateway)?.FirstOrDefault()?.CodigoIntegracao ?? "";
            return await ToModel(gateway, parcela, pagador, beneficiario, codigoPagador, "", dominioAssinante);
        }

        public async Task<BoletoModel> ToModel(EnumGateway gateway, ReceitaParcela parcela, string codigoPagador, string codigoBeneficiario, string dominioAssinante)
        {
            return await ToModel(gateway, parcela, null, null, codigoPagador, codigoBeneficiario, dominioAssinante);
        }
        public async Task<BoletoModel> ToModel(EnumGateway gateway, ReceitaParcela parcela, Pessoa pagador, Empresa beneficiario, string codigoPagador, string codigoBeneficiario = "", string dominioAssinante = "")
        {

            var codigo = "";

            switch (gateway)
            {
                case EnumGateway.GalaxPay:
                    codigo = parcela.UltimaTransacao == null ? Guid.NewGuid().ToString() : parcela.UltimaTransacao.CodigoIntegracao;
                    break;
                case EnumGateway.Global:
                    codigo = parcela.UltimaTransacao == null ? Guid.NewGuid().ToString() : parcela.UltimaTransacao.CodigoIntegracao;
                    break;

                case EnumGateway.Zoop:
                    codigo = parcela.CodigoZoop;

                    if (string.IsNullOrEmpty(codigoBeneficiario))
                        throw new BadRequestException("código do beneficiário não informado!");
                    break;
            }

            var model = new BoletoModel()
            {
                Codigo = codigo,
                CodigoInterno = parcela.Id.ToString(),
                CodigoBeneficiario = codigoBeneficiario,
                CodigoPagador = codigoPagador,
                DataLimiteRecebimento = parcela.EncargoFinanceiro.DiasAposVencimentoNaoReceber > 0 ? parcela.DataVencimento.AddDays(parcela.EncargoFinanceiro.DiasAposVencimentoNaoReceber) : null,
                DataVencimento = parcela.DataVencimento,
                Instrucao1 = parcela.Instrucao1,
                Instrucao2 = parcela.Instrucao2,
                Instrucao3 = parcela.Instrucao3,
                JurosPercentual = parcela.EncargoFinanceiro.JurosDia,
                MultaPercentual = parcela.EncargoFinanceiro.Multa,
                Valor = parcela.ValorComTaxas,
                Pagador = await ToModelPessoaBoleto(gateway, pagador),
                Beneficiario = await ToModelEmpresa(gateway, beneficiario),
                AssinanteDominio = dominioAssinante
            };

            if (EnumGateway.GalaxPay == gateway)
            {
                if (parcela.SplitPagamento != null)
                {
                    model.SplitPagamento = new SplitPagamentoBoletoBase
                    {
                        BoletoSplitConfigBase = new BoletoSplitConfigBase()
                        {

                            TipoSplit = parcela.SplitPagamento.TipoSplit.ToUpper().Equals("FIXED") ? TipoSplit.Fixo : TipoSplit.Percentual,
                            EmpresasSplitConfigBase = new List<EmpresaSplitConfigBase>()
                            {
                                new EmpresaSplitConfigBase()
                                {
                                    GalaxPayId = parcela.SplitPagamento.GalaxyPayId,
                                    Valor = parcela.SplitPagamento.Valor
                                }
                            }
                        }
                    };
                }
            }
            model.Descontos.Add(new BoletoDescontoModel()
            {
                DataLimite = parcela.DataVencimento.AddDays(Convert.ToInt32(parcela.EncargoFinanceiro.DiasDescontoVencimento) * -1),
                Valor = parcela.EncargoFinanceiro.DescontoVencimento,
                Percentual = parcela.EncargoFinanceiro.IsDescontoVencimentoPercentual
            });

            return model;
        }

        public async Task<SubcontaConsultaModel> VerificarSubContaAtiva(EnumGateway gateway, string empresaId)
        {
            using (var client = GetCabecalho())
            {
                client.DefaultRequestHeaders.Add("empresaId", empresaId);

                var response = await client.GetAsync($"Gateway/{gateway}/VerificarSubConta");
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var dataErro = JsonConvert.DeserializeObject<dynamic>(content);
                    string resultadoerro = JsonConvert.SerializeObject(dataErro.error.details);
                    throw new BadRequestException("Validação subconta - " + resultadoerro.Replace("{", "").Replace("[", "").Replace("}", "").Replace("]", "").Replace("\"", " "));

                }

                return JsonConvert.DeserializeObject<SubcontaConsultaModel>(content);

            }
        }

        public async Task<TransacaoRetornoModel> ObterBoleto(EnumGateway gateway, string codigo, string empresaId = "", string empresaHash = "")
        {
            if (string.IsNullOrEmpty(codigo))
                throw new BadRequestException("O campo código de integração da parcela ou transação encontra-se vazio");

            using (var client = GetCabecalho())
            {
                client.DefaultRequestHeaders.Add("empresaId", empresaId);
                client.DefaultRequestHeaders.Add("empresaHash", empresaHash);

                var response = await client.GetAsync($"Gateway/{gateway}/Boleto/{codigo}");
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<TransacaoRetornoModel>(content);


                var data = JsonConvert.DeserializeObject<dynamic>(content);
                throw new BadRequestException(data.ToString());

            }
        }

        public async Task<RetornoModel> CriarBoleto(EnumGateway gateway, ReceitaParcela parcelaBoleto, Pessoa pagador, Empresa beneficiario, string empresaId, string empresaHash, string assinanteId)
        {
            var boletoModel = await ToModel(gateway, parcelaBoleto, pagador, beneficiario, assinanteId);

            if (gateway == EnumGateway.GalaxPay)
                boletoModel.JurosPercentual *= 30;

            return await CriarBoleto(gateway, boletoModel, empresaId, empresaHash);
        }


        public async Task<RetornoModel> CriarBoleto(EnumGateway gateway, ReceitaParcela parcelaBoleto, string codigoPagador, string codigoBeneficiario, string assinanteId)
        {
            return await CriarBoleto(gateway, await ToModel(gateway, parcelaBoleto, codigoPagador, codigoBeneficiario, assinanteId));
        }

        public async Task<RetornoModel> CriarBoleto(EnumGateway gateway, BoletoModel boleto, string empresaId = "", string empresaHash = "")
        {
            using (var client = GetCabecalho())
            {
                client.DefaultRequestHeaders.Add("empresaId", empresaId);
                client.DefaultRequestHeaders.Add("empresaHash", empresaHash);

                var json = JsonConvert.SerializeObject(boleto, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();

                var response = await client.PostAsync($"Gateway/{gateway}/Boleto", stringContent);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<RetornoModel>(content);


                var data = JsonConvert.DeserializeObject<dynamic>(content);
                throw new BadRequestException(data.ToString());

            }
        }

        public async Task CancelarBoleto(EnumGateway gateway, string codigo, string empresaId = "", string empresaHash = "")
        {
            using (var client = GetCabecalho())
            {
                client.DefaultRequestHeaders.Add("empresaId", empresaId);
                client.DefaultRequestHeaders.Add("empresaHash", empresaHash);

                var response = await client.PostAsync($"Gateway/{gateway}/Boleto/Cancelar/{codigo}", null);

                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<dynamic>(content);
                    throw new BadRequestException(data.ToString());
                }

            }
        }

        public async Task<string> GerarCarne(EnumGateway gateway, List<string> codigos, string empresaId = "", string empresaHash = "")
        {
            using (var client = GetCabecalho())
            {
                client.DefaultRequestHeaders.Add("empresaId", empresaId);
                client.DefaultRequestHeaders.Add("empresaHash", empresaHash);

                var json = JsonConvert.SerializeObject(codigos, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();

                var response = await client.PostAsync($"Gateway/{gateway}/Boleto/Carne", stringContent);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<string>(content);

                var data = JsonConvert.DeserializeObject<dynamic>(content);
                throw new BadRequestException(data.ToString());


            }
        }

        public async Task AtualizarBoleto(EnumGateway gateway, ReceitaParcela parcelaBoleto, Pessoa pagador, Empresa beneficiario, string empresaId, string empresaHash, string assinanteId)
        {
            await AtualizarBoleto(gateway, await ToModel(gateway, parcelaBoleto, pagador, beneficiario, assinanteId), empresaId, empresaHash);
        }

        public async Task AtualizarBoleto(EnumGateway gateway, ReceitaParcela parcelaBoleto, string codigoPagador, string codigoBeneficiario, string assinanteId)
        {
            await AtualizarBoleto(gateway, await ToModel(gateway, parcelaBoleto, codigoPagador, codigoBeneficiario, assinanteId));
        }

        public async Task AtualizarBoleto(EnumGateway gateway, BoletoModel boleto, string empresaId = "", string empresaHash = "")
        {
            using (var client = GetCabecalho())
            {
                client.DefaultRequestHeaders.Add("empresaId", empresaId);
                client.DefaultRequestHeaders.Add("empresaHash", empresaHash);

                var json = JsonConvert.SerializeObject(boleto, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();

                var response = await client.PutAsync($"Gateway/{gateway}/Boleto", stringContent);

                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<dynamic>(content);
                    throw new BadRequestException(data.ToString());
                }

            }
        }

        public async Task<string> CriarPagador(EnumGateway gatewayId, Pessoa pagador, string empresaId = "", string empresaHash = "")
        {
            if (gatewayId == EnumGateway.ContaPay)
            {
                return await CriarPagador(gatewayId, await ToModelPessoa(gatewayId, pagador), empresaId, empresaHash);
            }
            else
            {
                return await CriarPagador(gatewayId, await ToModelPessoa(gatewayId, pagador), empresaId, empresaHash);
            }
        }
        public async Task<string> CriarPagador(EnumGateway gatewayId, PagadorModel pagador, string empresaId = "", string empresaHash = "")
        {
            using (var client = GetCabecalho())
            {
                client.DefaultRequestHeaders.Add("empresaId", empresaId);
                client.DefaultRequestHeaders.Add("empresaHash", empresaHash);

                var json = JsonConvert.SerializeObject(pagador, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();

                var response = await client.PostAsync($"Gateway/{gatewayId}/Pagador", stringContent);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<string>(content);


                var data = JsonConvert.DeserializeObject<dynamic>(content);
                throw new BadRequestException(data.ToString());

            }
        }

        public async Task AtualizarPagador(EnumGateway gatewayId, Pessoa pagador, string empresaId = "", string empresaHash = "")
        {
            await AtualizarPagador(gatewayId, await ToModelPessoa(gatewayId, pagador), empresaId, empresaHash);
        }

        public async Task AtualizarPagador(EnumGateway gatewayId, PagadorModel pagador, string empresaId = "", string empresaHash = "")
        {
            using (var client = GetCabecalho())
            {
                client.DefaultRequestHeaders.Add("empresaId", empresaId);
                client.DefaultRequestHeaders.Add("empresaHash", empresaHash);

                var json = JsonConvert.SerializeObject(pagador, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();

                var response = await client.PutAsync($"Gateway/{gatewayId}/Pagador", stringContent);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var data = JsonConvert.DeserializeObject<dynamic>(content);
                    throw new BadRequestException(data.ToString());
                }

            }
        }

        public async Task ExcluirPagador(EnumGateway gatewayId, string codigo, string empresaId = "", string empresaHash = "")
        {
            using (var client = GetCabecalho())
            {
                client.DefaultRequestHeaders.Add("empresaId", empresaId);
                client.DefaultRequestHeaders.Add("empresaHash", empresaHash);

                var response = await client.DeleteAsync($"Gateway/{gatewayId}/Pagador/{codigo}");
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var data = JsonConvert.DeserializeObject<dynamic>(content);
                    throw new BadRequestException(data.ToString());
                }

            }
        }

        public async Task<string> CriarVendedorPF(EnumGateway gatewayId, Empresa beneficiario)
        {
            return await CriarVendedorPF(gatewayId, await ToModelPF(beneficiario));
        }

        public async Task<string> CriarVendedorPF(EnumGateway gatewayId, BeneficiarioPessoaFisicaModel beneficiario)
        {
            using (var client = GetCabecalho())
            {
                var json = JsonConvert.SerializeObject(beneficiario, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();

                var response = await client.PostAsync($"Gateway/{gatewayId}/Beneficiario/PessoaFisica", stringContent);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<string>(content);


                var data = JsonConvert.DeserializeObject<dynamic>(content);
                throw new BadRequestException(data.ToString());

            }
        }

        public async Task AtualizarVendedorPF(EnumGateway gatewayId, Empresa beneficiario)
        {
            await AtualizarVendedorPF(gatewayId, await ToModelPF(beneficiario));
        }
        public async Task AtualizarVendedorPF(EnumGateway gatewayId, BeneficiarioPessoaFisicaModel beneficiario)
        {
            using (var client = GetCabecalho())
            {
                var json = JsonConvert.SerializeObject(beneficiario, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();

                var response = await client.PutAsync($"Gateway/{gatewayId}/Beneficiario/PessoaFisica", stringContent);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var data = JsonConvert.DeserializeObject<dynamic>(content);
                    throw new BadRequestException(data.ToString());
                }

            }
        }


        public async Task<string> CriarVendedorPJ(EnumGateway gatewayId, Empresa beneficiario)
        {
            return await CriarVendedorPJ(gatewayId, await ToModelPJ(beneficiario));
        }

        public async Task<string> CriarVendedorPJ(EnumGateway gatewayId, BeneficiarioPessoaJuridicaModel beneficiario)
        {
            using (var client = GetCabecalho())
            {
                var json = JsonConvert.SerializeObject(beneficiario, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();

                var response = await client.PostAsync($"Gateway/{gatewayId}/Beneficiario/PessoaJuridica", stringContent);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<string>(content);


                var data = JsonConvert.DeserializeObject<dynamic>(content);
                throw new BadRequestException(data.ToString());

            }
        }

        public async Task AtualizarVendedorPJ(EnumGateway gatewayId, Empresa beneficiario)
        {
            await AtualizarVendedorPJ(gatewayId, await ToModelPJ(beneficiario));
        }
        public async Task AtualizarVendedorPJ(EnumGateway gatewayId, BeneficiarioPessoaJuridicaModel beneficiario)
        {
            using (var client = GetCabecalho())
            {
                var json = JsonConvert.SerializeObject(beneficiario, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();

                var response = await client.PutAsync($"Gateway/{gatewayId}/Beneficiario/PessoaJuridica", stringContent);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var data = JsonConvert.DeserializeObject<dynamic>(content);
                    throw new BadRequestException(data.ToString());
                }

            }
        }

        public async Task<(string Id, string BankAccountId)> CriarContaBancaria(EnumGateway gatewayId, ContaCorrente contaCorrente)
        {
            return await CriarContaBancaria(gatewayId, ToModelConta(contaCorrente));
        }

        public async Task<(string Id, string BankAccountId)> CriarContaBancaria(EnumGateway gatewayId, ContaBancariaModel contaBancaria)
        {
            using (var client = GetCabecalho())
            {
                var json = JsonConvert.SerializeObject(contaBancaria, new JsonSerializerSettings { ContractResolver = new DefaultContractResolver(), NullValueHandling = NullValueHandling.Ignore });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();

                var response = await client.PostAsync($"Gateway/{gatewayId}/ContaBancaria", stringContent);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (response.IsSuccessStatusCode)
                    return (data.id.ToString(), data.bankAccount.id.ToString());//new Tuple<string, string> (data.id.ToString(), data.payment_method.url.ToString());



                throw new BadRequestException(data.ToString());

            }
        }

        public async Task<string> AssociarContaBancaria(EnumGateway gatewayId, string pagadorId, string tokenId)
        {
            using (var client = GetCabecalho())
            {
                var stringCountent = new StringContent(string.Empty);
                var response = await client.PostAsync($"Gateway/{gatewayId}/ContaBancaria/Associar?pagadorId={pagadorId}&tokenId={tokenId}", stringCountent);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<string>(content);


                var data = JsonConvert.DeserializeObject<dynamic>(content);
                throw new BadRequestException(data.ToString());

            }
        }

        public async Task ExcluirContaBancaria(EnumGateway gatewayId, string codigo)
        {
            using (var client = GetCabecalho())
            {
                var response = await client.DeleteAsync($"Gateway/{gatewayId}/ContaBancaria/{codigo}");
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var data = JsonConvert.DeserializeObject<dynamic>(content);
                    throw new BadRequestException(data.ToString());
                }

            }
        }
        // public async Task<RetornoSubContaModel> CriarSubContaCpf(Pessoa pessoa)
        // {

        //     var subContaModel = ToModelSubContaCpf(pessoa);
        //     subContaModel.ValidarDocumentos();
        //     var response = await CriarSubContaCpf(subContaModel);
        //     return response;
        // }

        public async Task<RetornoSubContaModel> CriarSubConta(EnumGateway gatewayId, SubContaModel model)
        {
            var subContaModel = await ToModel(model);

            using (var client = GetCabecalho())
            {
                var json = JsonConvert.SerializeObject(subContaModel, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();

                var response = await client.PostAsync($"Gateway/{gatewayId}/subconta", stringContent);
                var content = await response.Content.ReadAsStringAsync();


                if (!response.IsSuccessStatusCode)
                {
                    throw new BadRequestException("Validação Subconta - " + content);
                }
                var retorno = JsonConvert.DeserializeObject<RetornoSubContaModel>(content);
                return retorno;
            }
        }

        public SubContaCPFModel ToModelSubContaCpf(Pessoa pessoa)
        {
            return new SubContaCPFModel()
            {
                Nome = pessoa.Nome,
                CPF = pessoa.CpfCnpjLimpo,
                Telefone = pessoa.Telefone,
                Email = pessoa.Email,
                Logo = null,
                PodeAcessarPlataforma = true,
                NomeFatura = pessoa.Nome,
                // Endereco = new EnderecoSubContaModel
                // {
                //     Cep = pessoa.Endereco.Cep,
                //     Logradouro = pessoa.Endereco.Logradouro,
                //     Numero = pessoa.Endereco.Numero,
                //     Complemento = pessoa.Endereco.Complemento,
                //     Bairro = pessoa.Endereco.Bairro,
                //     Cidade = pessoa.Endereco.Municipio.Nome,
                //     Estado = pessoa.Endereco.Estado.Uf
                // }

            };
        }
        public async Task<SubcontaScaeModel> ToModel(SubContaModel parametro)
        {
            return new SubcontaScaeModel()
            {
                Nome = parametro.Nome,
                CPFCNPJ = StringHelper.LimparCpfCnpj(parametro.CPFCNPJ),
                NomeFantasia = parametro.NomeFantasia,
                Telefone = StringHelper.LimparTelefone(parametro.Telefone),
                Email = parametro.Email,
                CPFCNPJResponsavel = StringHelper.LimparCpfCnpj(parametro.ResponsavelModel.Cpf),

                SubcontaEndereco = new EnderecoModel()
                {
                    Cep = StringHelper.RemoverHifen(parametro.SubcontaEndereco.Cep),
                    Logradouro = parametro.SubcontaEndereco.Logradouro,
                    Numero = parametro.SubcontaEndereco.Numero,
                    Complemento = parametro.SubcontaEndereco.Complemento,
                    Bairro = parametro.SubcontaEndereco.Bairro,
                    Cidade = (await _enderecoService.ObterMunicipio(parametro.SubcontaEndereco.MunicipioId.Value)).Nome,
                    Uf = (await _enderecoService.ObterEstado(parametro.SubcontaEndereco.EstadoId.Value)).Uf
                },
                ResponsavelModel = new ResponsavelModel()
                {
                    senha = parametro.ResponsavelModel.senha,
                    Email = parametro.ResponsavelModel.Email,
                    Cpf = parametro.ResponsavelModel.Cpf,
                    Nome = parametro.ResponsavelModel.Nome,
                    DataNascimento = DateTime.TryParseExact(
                                        parametro.ResponsavelModel.DataNascimento,
                                        "dd/MM/yyyy",
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None,
                                        out var data
                                    ) ? data : DateTime.MinValue,
                    Telefone = parametro.ResponsavelModel.Telefone,            
                    SubcontaResponsavelEndereco = new EnderecoModel()
                    {
                        Cep = StringHelper.RemoverHifen(parametro.ResponsavelModel.SubcontaResponsavelEndereco.Cep),
                        Logradouro = parametro.ResponsavelModel.SubcontaResponsavelEndereco.Logradouro,
                        Numero = parametro.ResponsavelModel.SubcontaResponsavelEndereco.Numero,
                        Complemento = parametro.ResponsavelModel.SubcontaResponsavelEndereco.Complemento,
                        Bairro = parametro.ResponsavelModel.SubcontaResponsavelEndereco.Bairro,
                        Cidade = (await _enderecoService.ObterMunicipio(parametro.ResponsavelModel.SubcontaResponsavelEndereco.MunicipioId.Value)).Nome,
                        Uf = (await _enderecoService.ObterEstado(parametro.ResponsavelModel.SubcontaResponsavelEndereco.EstadoId.Value)).Uf
                    }

                }
            };
        }

        public async Task<RetornoSubContaModel> CriarSubContaCpf(SubContaCPFModel model)
        {
            //Teste para scae
            //var token = await ObterTokenAcesso("5558", "66I31fYh7q783yS5XnGsV301HaY8O2760kK1QlD6");

            using (var client = GetCabecalho())
            {
                var json = JsonConvert.SerializeObject(model, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();

                var response = await client.PostAsync($"Gateway/GalaxPay/subcontaCpf", stringContent);
                var content = await response.Content.ReadAsStringAsync();


                if (!response.IsSuccessStatusCode)
                {
                    throw new BadRequestException("Validação GalaxPay - " + content);
                }

                return JsonConvert.DeserializeObject<RetornoSubContaModel>(content);

            }
        }

        public async Task EnviarDocumentosSubContaCpf(SubContaCPFModel model, string empresaId, string empresaHash)
        {

            using (var client = GetCabecalho())
            {
                var json = JsonConvert.SerializeObject(model, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();
                client.DefaultRequestHeaders.Add("empresaId", empresaId);
                client.DefaultRequestHeaders.Add("empresaHash", empresaHash);

                var response = await client.PostAsync($"Gateway/GalaxPay/subconta/documentos", stringContent);
                var content = await response.Content.ReadAsStringAsync();


                if (!response.IsSuccessStatusCode)
                {
                    var dataErro = JsonConvert.DeserializeObject<dynamic>(content);
                    string resultadoerro = JsonConvert.SerializeObject(dataErro.error.details);
                    throw new BadRequestException("Validação GalaxPay - " + resultadoerro.Replace("{", "").Replace("[", "").Replace("}", "").Replace("]", "").Replace("\"", " "));

                }
            }
        }

        public async Task EnviarDocumentoSubConta(EnumGateway gateway, SubcontaDocumentoScaeModel model, string empresaId, string empresaHash)
        {

            using (var client = GetCabecalho())
            {
                var json = JsonConvert.SerializeObject(model, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();
                client.DefaultRequestHeaders.Add("empresaId", empresaId);
                client.DefaultRequestHeaders.Add("empresaHash", empresaHash);

                var response = await client.PostAsync($"Gateway/{gateway}/subconta/documentos", stringContent);
                var content = await response.Content.ReadAsStringAsync();


                if (!response.IsSuccessStatusCode)
                {
                    var dataErro = JsonConvert.DeserializeObject<dynamic>(content);
                    string resultadoerro = JsonConvert.SerializeObject(dataErro.error.details);
                    throw new BadRequestException("Validação GalaxPay - " + resultadoerro.Replace("{", "").Replace("[", "").Replace("}", "").Replace("]", "").Replace("\"", " "));

                }
                
            }
        }
        
        public async Task<SubcontaConsultaModel> ConsultarSubconta(EnumGateway gateway, string empresaId)
        {

            using (var client = GetCabecalho())
            {
                client.DefaultRequestHeaders.Add("empresaId", empresaId);

                var response = await client.GetAsync($"Gateway/{gateway}/VerificarSubConta");
                var content = await response.Content.ReadAsStringAsync();


                if (!response.IsSuccessStatusCode)
                {
                    var dataErro = JsonConvert.DeserializeObject<dynamic>(content);
                    string resultadoerro = JsonConvert.SerializeObject(dataErro.error.details);
                    throw new BadRequestException("Validação subconta - " + resultadoerro.Replace("{", "").Replace("[", "").Replace("}", "").Replace("]", "").Replace("\"", " "));

                }

                return JsonConvert.DeserializeObject<SubcontaConsultaModel>(content);
            }
        }

    }
}
