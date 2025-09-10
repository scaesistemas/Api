using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SCAE.Data.Interface.Financeiro;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Boleto;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Shared;
using SCAE.Financeiro.Api.Models.Boleto.Shared;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Financeiro.ApiFinanceiro;
using SCAE.Service.Interfaces.Geral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Financeiro.ApiFinanceiro
{
    public class BoletoService : ApiFinanceiroBaseService, IBoletoService
    {
        private readonly IRemessaRepository _remessaRepository;
        private readonly IReceitaRepository _receitaRepository;
        public BoletoService(IOptions<ApiFinanceiroSettingModel> settings) : base(settings)
        {
        }

        public BoletoService(IOptions<ApiFinanceiroSettingModel> settings, IEnderecoService enderecoService, IRemessaRepository remessaRepository,IReceitaRepository receitaRepository) : base(settings, enderecoService)
        {
            _remessaRepository = remessaRepository;
            _receitaRepository = receitaRepository;
        }

        public BoletoModel ToModel(ReceitaTransacao transacao)
        {
            if (transacao.ContaCorrente == null)
                throw new BadRequestException("Transação sem conta corrente cadastrada");

            return new BoletoModel
            {
                AplicarJurosMulta = transacao.Juros > 0 || transacao.Multa > 0 ? true : false,
                DataDesconto = transacao.Vencimento.AddDays(transacao.EncargoFinanceiro.DiasDescontoVencimento * -1),
                DataJuros = transacao.Vencimento.AddDays(1),
                DataMulta = transacao.Vencimento.AddDays(1),
                DataEmissao = transacao.DataEmissao,
                DataVencimento = transacao.Vencimento,
                Pagador = new SCAE.Financeiro.Api.Models.Boleto.Shared.PagadorModel()
                {
                    CpfCnpj = transacao.Parcela.Receita.Cliente.CnpjCpf,
                    Endereco = new EnderecoModel()
                    {
                        Bairro = transacao.Parcela.Receita.Cliente.Endereco.Bairro,
                        Cep = transacao.Parcela.Receita.Cliente.Endereco.Cep,
                        Complemento = transacao.Parcela.Receita.Cliente.Endereco.Complemento,
                        Logradouro = transacao.Parcela.Receita.Cliente.Endereco.Logradouro,
                        Numero = transacao.Parcela.Receita.Cliente.Endereco.Numero,
                        Cidade = transacao.Parcela.Receita.Cliente.Endereco.Municipio.Nome,
                        Uf = transacao.Parcela.Receita.Cliente.Endereco.Estado.Uf
                    },
                    Nome = transacao.Parcela.Receita.Cliente.Nome
                },
                Beneficiario = new BeneficiarioModel()
                {
                    Agencia = transacao.ContaCorrente.NumeroAgencia,
                    AgenciaDigito = transacao.ContaCorrente.DigitoAgencia,
                    Carteira = transacao.ContaCorrente.Carteira,
                    CarteiraDigito = transacao.ContaCorrente.DigitoCarteira,
                    Conta = transacao.ContaCorrente.NumeroConta,
                    ContaDigito = transacao.ContaCorrente.DigitoConta,
                    CpfCnpj = transacao.ContaCorrente.Empresa.CpfCnpj,
                    Nome = transacao.ContaCorrente.Empresa.Nome,
                    Endereco = new EnderecoModel()
                    {
                        Logradouro = transacao.ContaCorrente.Empresa.Endereco.Logradouro,
                        Bairro = transacao.ContaCorrente.Empresa.Endereco.Bairro,
                        Cep = transacao.ContaCorrente.Empresa.Endereco.Cep,
                        Cidade = transacao.ContaCorrente.Empresa.Endereco.Municipio.Nome,
                        Uf = transacao.ContaCorrente.Empresa.Endereco.Estado.Uf,
                        Complemento = transacao.ContaCorrente.Empresa.Endereco.Complemento,
                        Numero = transacao.ContaCorrente.Empresa.Endereco.Numero
                    },
                    Codigo = transacao.ContaCorrente.CodigoCedente,
                    CodigoDigito = transacao.ContaCorrente.DigitoCedente
                },
                NossoNumero = string.IsNullOrEmpty(transacao.Parcela.NossoNumero) ? "" : transacao.Parcela.NossoNumero,
                NumeroDocumento = transacao.Id,
                PercentualDesconto = transacao.EncargoFinanceiro.DescontoVencimento,
                PercentualJuros = transacao.EncargoFinanceiro.JurosDia,
                PercentualMulta = transacao.EncargoFinanceiro.Multa,
                Valor = transacao.Parcela?.ValorComTaxas  > 0 ? transacao.Parcela.ValorComTaxas : transacao.Valor,
                Instrucao1 = transacao.Parcela.Instrucao1,
                Instrucao2 = transacao.Parcela.Instrucao2,
                Instrucao3 = transacao.Parcela.Instrucao3,
                NumeroContrato = Int32.TryParse(transacao.ContaCorrente.CodigoCedente, out int numeroContrato) ? numeroContrato : 0,
            };
        }

        public async Task<RemessaModel> ToModel(int remessaId)
        {
            var remessa = await _remessaRepository.GetByIdAsync(remessaId, "Transacoes.Parcela.Receita.Cliente.Endereco.Municipio,Transacoes.Parcela.Receita.Cliente.Endereco.Estado, Transacoes.ContaCorrente.Empresa.Endereco.Municipio, Transacoes.ContaCorrente.Empresa.Endereco.Estado");
            var model = new RemessaModel()
            {
                Sequencia = remessa.NumeroSequencia
            };

            foreach (var transacao in remessa.Transacoes)
            {
                model
                    .Boletos.Add(ToModel(transacao));              
            }

            return model;
        }

        public async Task<ArquivoRemessaDocumento> RemessaBoleto(int codigoBanco, int remessaId, EnumTipoArquivo enumTipoArquivo)
        {
            return await RemessaBoleto(codigoBanco, await ToModel(remessaId),enumTipoArquivo);
        }

        public async Task<List<RetornoModel>> RetornoBoleto(int codigoBanco, IFormFile arquivoRetorno, EnumTipoArquivo enumTipoArquivo)
        {
            return await ProcessarRetornoBoleto(codigoBanco, arquivoRetorno, enumTipoArquivo);
        }

        public async Task<string> VisualizarBoleto(int transacaoId)
        {
            var transacao = _receitaRepository.GetTransacaoAll("Parcela.Receita.Cliente.Endereco.Municipio,Parcela.Receita.Cliente.Endereco.Estado,ContaCorrente.Empresa.Endereco.Municipio,ContaCorrente.Empresa.Endereco.Estado,ContaCorrente.Banco").SingleOrDefault(x => x.Id == transacaoId);

            if (transacao == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            if (transacao.TipoOperacaoId != TipoOperacaoFinanceira.Boleto.Id)
                throw new BadRequestException("Tipo de operação financeira diferente de boleto");

            return await VisualizarBoleto(transacao.ContaCorrente.Banco.Codigo, ToModel(transacao));

        }

        public async Task<BoletoModel> MontarBoletoByTransacaoId(int transacaoId)
        {
            var transacao = _receitaRepository.GetTransacaoAll("Parcela.Receita.Cliente.Endereco.Municipio,Parcela.Receita.Cliente.Endereco.Estado,ContaCorrente.Empresa.Endereco.Municipio,ContaCorrente.Empresa.Endereco.Estado,ContaCorrente.Banco").SingleOrDefault(x => x.Id == transacaoId);

            if (transacao == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            return ToModel(transacao);
        }


    }
}
