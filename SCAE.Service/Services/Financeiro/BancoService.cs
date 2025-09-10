using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SCAE.Data.Interface.Financeiro;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Banco;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Boleto;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Shared;
using SCAE.Domain.Models.Global;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Financeiro
{
    public class BancoService : CrudService<Banco, IBancoRepository>, IBancoService
    {
        public readonly ApiFinanceiroSettingModel _appSettings;
        public readonly IEnderecoService _enderecoService;
        private readonly string _encryptionKey;
        public BancoService(IBancoRepository repository, IConfiguration configuration, IOptions<ApiFinanceiroSettingModel> settings, IEnderecoService enderecoService) : base(repository)
        {
            _encryptionKey = configuration["EncryptionKey"];
            _appSettings = settings.Value;
            _enderecoService = enderecoService;
        }
        static byte[] GetValidKey(string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            if (keyBytes.Length < 32)
            {
                // Preenche com zeros se a chave for menor
                Array.Resize(ref keyBytes, 32);
            }
            else if (keyBytes.Length > 32)
            {
                // Trunca a chave se for maior
                keyBytes = keyBytes.Take(32).ToArray();
            }

            return keyBytes;
        }


        public static string Decrypt(string cipherText, string key)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            byte[] keyBytes = GetValidKey(key);

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.Padding = PaddingMode.PKCS7;

                // Extrai o IV do início dos bytes criptografados
                byte[] iv = new byte[16];
                Array.Copy(cipherBytes, 0, iv, 0, iv.Length);
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream(cipherBytes, iv.Length, cipherBytes.Length - iv.Length))
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    byte[] decryptedBytes = new byte[cipherBytes.Length];
                    int bytesRead = cs.Read(decryptedBytes, 0, decryptedBytes.Length);
                    return Encoding.UTF8.GetString(decryptedBytes, 0, bytesRead);
                }
            }
        }



        public async Task<SCAE.Domain.Models.Financeiro.ApiFinanceiro.Banco.BoletoModel> ToModel(ReceitaTransacao transacao, Pessoa pagador, Empresa beneficiario, ContaCorrente contaCorrente, ReceitaParcela parcela, EnumBanco bancoId)
        {
            if (pagador.Endereco.EstadoId == null || pagador.Endereco.MunicipioId == null)
            {
                throw new BadRequestException("Estado ou município do pagador não está cadastrado");
            }
            ;
            if (beneficiario.Endereco.EstadoId == null || beneficiario.Endereco.MunicipioId == null)
            {
                throw new BadRequestException("Estado ou município do beneficiário não está cadastrado");
            }
            ;
            var estadoPagador = await _enderecoService.ObterEstado(pagador.Endereco.EstadoId.Value);
            var municipioPagador = await _enderecoService.ObterMunicipio(pagador.Endereco.MunicipioId.Value);
            var estadoBeneficiario = await _enderecoService.ObterEstado(beneficiario.Endereco.EstadoId.Value);
            var municipioBeneficiario = await _enderecoService.ObterMunicipio(beneficiario.Endereco.MunicipioId.Value);
            var codigoCedente = string.IsNullOrEmpty(contaCorrente.CodigoCedente) ? 0 : int.Parse(contaCorrente.CodigoCedente);
            var digitoCedente = string.IsNullOrEmpty(contaCorrente.DigitoCedente) ? 0 : int.Parse(contaCorrente.DigitoCedente);

            SCAE.Domain.Models.Financeiro.ApiFinanceiro.Banco.BoletoModel model = new SCAE.Domain.Models.Financeiro.ApiFinanceiro.Banco.BoletoModel()
            {
                CodigoInterno = transacao.Id.ToString(),
                DataLimiteRecebimento = transacao.EncargoFinanceiro.DiasAposVencimentoNaoReceber > 0 ? transacao.Vencimento.AddDays(transacao.EncargoFinanceiro.DiasAposVencimentoNaoReceber) : null,
                DataVencimento = transacao.Vencimento,
                Instrucao1 = parcela.Instrucao1,
                Instrucao2 = parcela.Instrucao2,
                Instrucao3 = parcela.Instrucao3,
                JurosPercentual = transacao.EncargoFinanceiro.JurosDia,
                MultaPercentual = transacao.EncargoFinanceiro.Multa,
                DiasProtesto = transacao.EncargoFinanceiro.DiasProtesto > 0 ? transacao.EncargoFinanceiro.DiasProtesto : null,
                DiasNegativacao = transacao.EncargoFinanceiro.DiasNegativacao > 0 ? transacao.EncargoFinanceiro.DiasNegativacao : null,
                ContaCorrente = bancoId == EnumBanco.Sicoob ? $"{contaCorrente.NumeroConta}{contaCorrente.DigitoConta}" : contaCorrente.NumeroConta,
                Agencia = contaCorrente.NumeroAgencia,
                Carteira = contaCorrente.Carteira,
                NumeroContrato = bancoId == EnumBanco.Sicoob ? int.Parse($"{codigoCedente}{digitoCedente}") : codigoCedente,
                KeyTypePix = contaCorrente.KeyTypeDict,
                ChavePix = contaCorrente.KeyDictKey,
                Pagador = new PagadorModel()
                {
                    CpfCnpj = StringHelper.LimparCpfCnpj(pagador.CnpjCpf),
                    Email = pagador.Email,
                    Endereco = new EnderecoModel()
                    {
                        Bairro = pagador.Endereco.Bairro ?? "",
                        Cep = pagador.Endereco.Cep,
                        Cidade = municipioPagador.Nome,
                        Complemento = pagador.Endereco.Complemento ?? "",
                        Logradouro = pagador.Endereco.Logradouro ?? "",
                        Numero = pagador.Endereco.Numero ?? "",
                        Uf = estadoPagador.Uf
                    },
                    Nome = pagador.Nome,
                    Telefone = pagador.Telefone
                },
                Beneficiario = new PagadorModel()
                {
                    CpfCnpj = StringHelper.LimparCpfCnpj(beneficiario.CpfCnpj),
                    Email = beneficiario.Email,
                    Nome = beneficiario.Nome,
                    Telefone = beneficiario.Telefone1,
                    Endereco = new EnderecoModel()
                    {
                        Bairro = beneficiario.Endereco.Bairro ?? "",
                        Cep = beneficiario.Endereco.Cep,
                        Complemento = beneficiario.Endereco.Complemento ?? "",
                        Logradouro = beneficiario.Endereco.Logradouro ?? "",
                        Numero = beneficiario.Endereco.Numero ?? "",
                        Uf = estadoBeneficiario.Uf,
                        Cidade = municipioBeneficiario.Nome
                    }
                },
                Valor = parcela.ValorComTaxas > 0 ? parcela.ValorComTaxas : parcela.Valor,
                WorkerSpaceSantander = contaCorrente.CodWorkerSpace ?? "",
                CadastrarComQRCode = contaCorrente.GerarBoletoComPix ? true : false
            };

            if (contaCorrente.Certificados.Count > 0)
            {
                model.Certificados = toModelCertificados(contaCorrente.Certificados);
            }

            if (transacao.EncargoFinanceiro.DiasDescontoVencimento >= 0 && transacao.EncargoFinanceiro.DescontoVencimento > 0)
            {
                model.Descontos.Add(new BoletoDescontoModel()
                {
                    DataLimite = transacao.Vencimento.AddDays(Convert.ToInt32(transacao.EncargoFinanceiro.DiasDescontoVencimento) * -1),
                    Valor = transacao.EncargoFinanceiro.DescontoVencimento,
                    Percentual = transacao.EncargoFinanceiro.IsDescontoVencimentoPercentual
                });
            }

            return model;
        }

        public async Task<DateTime> CertificadoDigital(IFormFile certificado, string assinanteId, string contaCorrenteId, string senhaCertificado)
        {
            using (var client = GetCabecalho())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));

                var arquivo = new MultipartFormDataContent();

                byte[] fileBytes;

                using (var ms = new MemoryStream())
                {
                    certificado.CopyTo(ms);
                    fileBytes = ms.ToArray();
                }
                var byteArrayContent = new ByteArrayContent(fileBytes);
                arquivo.Add(byteArrayContent, "arquivo", certificado.FileName);

                var response = await client.PostAsync($"Banco/CertificadoDigital?assinanteId={assinanteId}&contaCorrenteId={contaCorrenteId}&senha={senhaCertificado}", arquivo);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<DateTime>(content);


                //var data = JsonConvert.DeserializeObject<dynamic>(content);
                throw new BadRequestException(content);

            }
        }

        public async Task<SCAE.Domain.Models.Financeiro.ApiFinanceiro.Banco.RetornoModel> CriarBoleto(EnumBanco bancoId, ReceitaTransacao boleto, Pessoa pagador, Empresa beneficiario, ContaCorrente contaCorrente, ReceitaParcela parcela, string senha, string clienteId, string assinanteId)
        {
            return await CriarBoleto(bancoId, await ToModel(boleto, pagador, beneficiario, contaCorrente, parcela, bancoId), clienteId, assinanteId, contaCorrente.Id.ToString(), senha, contaCorrente.TokenAcesso, contaCorrente.Posto);
        }

        public async Task<SCAE.Domain.Models.Financeiro.ApiFinanceiro.Banco.RetornoModel> CriarBoleto(EnumBanco bancoId, SCAE.Domain.Models.Financeiro.ApiFinanceiro.Banco.BoletoModel boleto, string clienteId, string assinanteId, string contaCorrenteId, string senha, string tokenAcesso, string posto)
        {
            using (var client = GetCabecalho())
            {
                client.DefaultRequestHeaders.Add("clienteId", clienteId);
                client.DefaultRequestHeaders.Add("assinanteId", assinanteId);
                client.DefaultRequestHeaders.Add("contaCorrenteId", contaCorrenteId);
                client.DefaultRequestHeaders.Add("senha", senha);
                client.DefaultRequestHeaders.Add("tokenAcesso", tokenAcesso);
                client.DefaultRequestHeaders.Add("posto", posto);


                var json = JsonConvert.SerializeObject(boleto, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();

                var response = await client.PostAsync($"Banco/{bancoId}/Boleto", stringContent);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<SCAE.Domain.Models.Financeiro.ApiFinanceiro.Banco.RetornoModel>(content);

                var data = JsonConvert.DeserializeObject<dynamic>(content);
                throw new BadRequestException(data.ToString());

            }
        }

        public List<CertificadoBanco> toModelCertificados(List<CertificadoBanco> certificados)
        {
            List<CertificadoBanco> lista = new List<CertificadoBanco>();
            if (certificados.Count > 0)
            {
                foreach (var cert in certificados)
                {
                    var modelo = new CertificadoBanco
                    {
                        Id = cert.Id,
                        Nome = cert.Nome,
                        Formato = cert.Formato,
                        ContaCorrenteId = cert.ContaCorrenteId,
                        Senha = string.IsNullOrEmpty(cert.Senha) ? cert.Senha : Decrypt(cert.Senha, _encryptionKey),
                        Conteudo = cert.Conteudo,
                        DataValidacaoFinal = cert.DataValidacaoFinal,
                        DataValidacaoInicial = cert.DataValidacaoInicial,
                        corrente = cert.corrente
                    };
                    lista.Add(modelo);
                }
            }
            return lista;
        }

        public async Task<byte[]> PdfBoleto(EnumBanco bancoId, string senha, ContaCorrente contaCorrente, string linhaDigitavel, string assinanteId, string cpfPagante)
        {
            var certificados = new CertificadoRequest()
            {

                Certificados = toModelCertificados(contaCorrente.Certificados)
            };

            if (bancoId == EnumBanco.Santander)
            {
                return await PdfBoleto(bancoId, certificados, senha, contaCorrente.SenhaCertificado, contaCorrente.CodigoCedente, contaCorrente.NumeroAgencia, linhaDigitavel, cpfPagante, int.Parse(contaCorrente.CodigoCedente), contaCorrente.ClientId, assinanteId, contaCorrente.Id.ToString());
            }
            else
            {
                return await PdfBoleto(bancoId, certificados, senha, contaCorrente.TokenAcesso, contaCorrente.CodigoCedente, contaCorrente.NumeroAgencia, linhaDigitavel, contaCorrente.Posto, bancoId == EnumBanco.Sicoob ? int.Parse($"{contaCorrente.CodigoCedente}{contaCorrente.DigitoCedente}") : int.Parse(contaCorrente.CodigoCedente), contaCorrente.ClientId, assinanteId, contaCorrente.Id.ToString());
            }
        }

        public async Task<byte[]> PdfBoleto(EnumBanco bancoId, CertificadoRequest certificado, string senha, string tokenAcesso, string codigoBeneficiario, string agencia, string linhaDigitavel, string posto, int numeroContrato, string clienteId, string assinanteId, string contaCorrenteId)
        {
            using (var client = GetCabecalho())
            {
                client.DefaultRequestHeaders.Add("clienteId", clienteId);
                client.DefaultRequestHeaders.Add("assinanteId", assinanteId);
                client.DefaultRequestHeaders.Add("contaCorrenteId", contaCorrenteId);
                client.DefaultRequestHeaders.Add("senha", senha);
                client.DefaultRequestHeaders.Add("tokenAcesso", tokenAcesso);
                client.DefaultRequestHeaders.Add("posto", posto);


                var json = JsonConvert.SerializeObject(certificado, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), NullValueHandling = NullValueHandling.Ignore, ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"Banco/{bancoId}/Boleto/Pdf?codigoBeneficiario={codigoBeneficiario}&agencia={agencia}&linhaDigitavel={linhaDigitavel}&numeroContrato={numeroContrato}", stringContent);

                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsByteArrayAsync();

                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);
                throw new BadRequestException(data.ToString());

            }
        }
        public async Task<byte[]> GerarCarne(List<byte[]> pdfs)
        {
            using (var memoryStream = new MemoryStream())
            {
                var writer = new PdfWriter(memoryStream);
                var pdfDocument = new PdfDocument(writer);
                var merger = new PdfMerger(pdfDocument);

                foreach (var pdf in pdfs)
                {
                    using (var pdfStream = new MemoryStream(pdf))
                    {
                        var reader = new PdfReader(pdfStream);
                        var sourcePdf = new PdfDocument(reader);
                        merger.Merge(sourcePdf, 1, sourcePdf.GetNumberOfPages());
                        sourcePdf.Close();
                    }
                }

                pdfDocument.Close();
                return memoryStream.ToArray();
            }
        }

        public async Task<BaixaRetornoModel> BaixaBoleto(EnumBanco bancoId, string senha, string nossoNumeroTransacao, ContaCorrente contaCorrente, string assinanteId)
        {
            if (contaCorrente.Certificados == null)
                contaCorrente.Certificados = new List<CertificadoBanco>();

            var model = new BaixaModel()
            {
                CodigoBeneficiario = contaCorrente.CodigoCedente,
                NossoNumero = nossoNumeroTransacao,
                Carteira = contaCorrente.Carteira,
                NumeroContrato = bancoId == EnumBanco.Sicoob ? int.Parse($"{contaCorrente.CodigoCedente}{contaCorrente.DigitoCedente}") : int.Parse(contaCorrente.CodigoCedente),
                Certificados = toModelCertificados(contaCorrente.Certificados),
                CpfCnpjBeneficiario = contaCorrente.Empresa.CpfCnpjLimpo,
                NumeroConta = contaCorrente.NumeroConta
            };

            if (EnumBanco.Santander == bancoId)
                model.Agencia = contaCorrente.CodWorkerSpace;

            else
                model.Agencia = contaCorrente.NumeroAgencia;

            if (EnumBanco.Santander == bancoId)
                return await BaixaBoleto(bancoId, senha, contaCorrente.SenhaCertificado, contaCorrente.Posto, model, contaCorrente.ClientId, assinanteId, contaCorrente.Id.ToString());

            else
                return await BaixaBoleto(bancoId, senha, contaCorrente.TokenAcesso, contaCorrente.Posto, model, contaCorrente.ClientId, assinanteId, contaCorrente.Id.ToString());
        }

        public async Task<BaixaRetornoModel> BaixaBoleto(EnumBanco bancoId, string senha, string tokenAcesso, string posto, BaixaModel model, string clienteId, string assinanteId, string contaCorrenteId)
        {
            using (var client = GetCabecalho())
            {
                client.DefaultRequestHeaders.Add("senha", senha);
                client.DefaultRequestHeaders.Add("tokenAcesso", tokenAcesso);
                client.DefaultRequestHeaders.Add("posto", posto);
                client.DefaultRequestHeaders.Add("clienteId", clienteId);
                client.DefaultRequestHeaders.Add("assinanteId", assinanteId);
                client.DefaultRequestHeaders.Add("contaCorrenteId", contaCorrenteId);


                var json = JsonConvert.SerializeObject(model, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();

                var response = await client.PostAsync($"Banco/{bancoId}/Boleto/Baixa", stringContent);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<BaixaRetornoModel>(content);

                var data = JsonConvert.DeserializeObject<dynamic>(content);
                throw new BadRequestException(data.ToString());

            }
        }
        public async Task<RetornoConsultaModel> Obter(EnumBanco bancoId, string senha, ContaCorrente contaCorrente, string nossoNumeroTransacao, string AssinanteId)
        {
            var certificados = new CertificadoRequest()
            {
                Certificados = toModelCertificados(contaCorrente.Certificados)
            };

            if (bancoId == EnumBanco.Santander)
            {
                return await Obter(bancoId, certificados, senha, contaCorrente.SenhaCertificado, contaCorrente.CodigoCedente, contaCorrente.Id.ToString(), nossoNumeroTransacao, AssinanteId, contaCorrente.ClientId);
            }
            else if (bancoId == EnumBanco.Sicoob)
            {
                return await Obter(bancoId, certificados, senha, contaCorrente.TokenAcesso, $"{contaCorrente.CodigoCedente}{contaCorrente.DigitoCedente}", contaCorrente.NumeroAgencia, nossoNumeroTransacao, contaCorrente.Posto, contaCorrente.ClientId);
            }
            else if (bancoId == EnumBanco.Bradesco)
            {
                return await Obter(bancoId, certificados, contaCorrente.ClientSecret, contaCorrente.NumeroAgencia, contaCorrente.Empresa.CpfCnpjLimpo, contaCorrente.NumeroConta, nossoNumeroTransacao, AssinanteId, contaCorrente.ClientId);
            }
            else
            {
                return await Obter(bancoId, certificados, senha, contaCorrente.TokenAcesso, contaCorrente.CodigoCedente, contaCorrente.NumeroAgencia, nossoNumeroTransacao, contaCorrente.Posto, contaCorrente.ClientId);
            }

        }
        public async Task<RetornoConsultaModel> Obter(EnumBanco bancoId, CertificadoRequest certificados, string senha, string tokenAcesso, string codigoBeneficiario, string agencia, string nossoNumero, string posto, string clientId)
        {
            using (var client = GetCabecalho())
            {
                client.DefaultRequestHeaders.Add("senha", senha);
                client.DefaultRequestHeaders.Add("clienteId", clientId);
                client.DefaultRequestHeaders.Add("tokenAcesso", tokenAcesso);
                client.DefaultRequestHeaders.Add("posto", posto);


                var json = JsonConvert.SerializeObject(certificados, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), NullValueHandling = NullValueHandling.Ignore, ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"Banco/{bancoId}/Boleto/obter?codigoBeneficiario={codigoBeneficiario}&agencia={agencia}&nossoNumero={nossoNumero}", stringContent);
                var content = await response.Content.ReadAsStringAsync();


                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<RetornoConsultaModel>(content);

                var data = JsonConvert.DeserializeObject<dynamic>(content);
                throw new BadRequestException(data.ToString());

            }
        }

        public async Task<string> CriarWorkerSpace(List<CertificadoBanco> certificados, string clienteId, string senha, string codigoCedente)
        {
            var certificado = new CertificadoRequest()
            {
                Certificados = toModelCertificados(certificados)
            };
            using (var client = GetCabecalho())
            {
                client.DefaultRequestHeaders.Add("clienteId", clienteId);
                client.DefaultRequestHeaders.Add("senha", senha);
                client.DefaultRequestHeaders.Add("codigoCedente", codigoCedente);

                var json = JsonConvert.SerializeObject(certificado, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), NullValueHandling = NullValueHandling.Ignore, ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"Banco/WorkerSpaceSantander", stringContent);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (response.IsSuccessStatusCode)
                {

                    return data.id;
                }

                throw new BadRequestException(data.ToString());

            }
        }

        public async Task<string> CriarWebhookBradesco(List<CertificadoBanco> certificados, string clienteId, string clientSecret, string cnpjBeneficiario, string assinanteId)
        {
            var certificado = new CertificadoRequest()
            {
                Certificados = toModelCertificados(certificados)
            };
            using (var client = GetCabecalho())
            {
                client.DefaultRequestHeaders.Add("clienteId", clienteId);
                client.DefaultRequestHeaders.Add("clientSecret", clientSecret);
                client.DefaultRequestHeaders.Add("cnpjBeneficiario", cnpjBeneficiario);
                client.DefaultRequestHeaders.Add("assinanteId", assinanteId);

                var json = JsonConvert.SerializeObject(certificado, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), NullValueHandling = NullValueHandling.Ignore, ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"Banco/bradesco/RegistrarWebhook", stringContent);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (response.IsSuccessStatusCode)
                {
                    return data.ToString();
                }

                throw new BadRequestException(data.ToString());

            }
        }

        public async Task<bool> CriarSubcontaGlobal(SubcontaGlobalModel subconta)
        {
            using (var client = GetCabecalho())
            {
                var json = JsonConvert.SerializeObject(subconta, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), NullValueHandling = NullValueHandling.Ignore, ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"Banco/criarSubcontaGlobalPj", stringContent);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                throw new BadRequestException(data.ToString());

            }
        }
        public async Task<bool> EnviarDocumentoSubcontaGlobal(SubcontaGlobalDocumentos documentos)
        {
            using (var client = GetCabecalho())
            {
                var json = JsonConvert.SerializeObject(documentos, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), NullValueHandling = NullValueHandling.Ignore, ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"Banco/SubcontaGlobalPj", stringContent);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(content);

                if (response.IsSuccessStatusCode)
                {

                    return true;
                }

                throw new BadRequestException(data.ToString());

            }
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

        public async Task<ArquivoRemessaDocumento> RemessaBoleto(int codigoBanco, RemessaModel remessa, EnumTipoArquivo enumTipoArquivo)
        {
            using (var client = GetCabecalho())
            {
                var json = JsonConvert.SerializeObject(remessa, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType.Parameters.Clear();

                var response = await client.PostAsync($"Boleto/{codigoBanco}/Cobranca/Remessa/{enumTipoArquivo}", stringContent);

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

        public async Task<string> VisualizarBoleto(int codigoBanco, SCAE.Domain.Models.Financeiro.ApiFinanceiro.Banco.BoletoModel boleto)
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

        public async Task<byte[]> VisualizarBoletoPdf(int codigoBanco, CarneModel carne, bool manterNossoNumero)
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

        public async Task<List<SCAE.Domain.Models.Financeiro.ApiFinanceiro.Boleto.RetornoModel>> ProcessarRetornoBoleto(int codigoBanco, IFormFile arquivoRetorno, EnumTipoArquivo enumTipoArquivo)
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

                var response = await client.PostAsync($"Boleto/{codigoBanco}/Cobranca/Retorno/{enumTipoArquivo}", form);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<List<SCAE.Domain.Models.Financeiro.ApiFinanceiro.Boleto.RetornoModel>>(content);

                var data = JsonConvert.DeserializeObject<dynamic>(content);
                throw new BadRequestException(data.ToString());

            }
        }
        
    }
}
