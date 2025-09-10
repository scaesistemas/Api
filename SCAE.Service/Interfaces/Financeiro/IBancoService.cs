using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Banco;
using SCAE.Domain.Models.Global;
using SCAE.Service.Interfaces.Shared;

namespace SCAE.Service.Interfaces.Financeiro
{
    public interface IBancoService : ICrudService<Banco>
    {
        Task<DateTime> CertificadoDigital(IFormFile certificado, string assinanteId, string contaCorrenteId, string senha);
        Task<RetornoModel> CriarBoleto(EnumBanco bancoId, ReceitaTransacao boleto, Pessoa pagador, Empresa beneficiario, ContaCorrente contaCorrente, ReceitaParcela parcela, string senha, string clienteId, string assinanteId);
        Task<RetornoModel> CriarBoleto(EnumBanco bancoId, BoletoModel boleto, string clienteId, string assinanteId, string contaCorrenteId, string senha, string tokenAcesso, string posto);
        Task<byte[]> PdfBoleto(EnumBanco bancoId, string senha, ContaCorrente contaCorrente, string linhaDigitavel, string assinanteId, string cpfPagante);
        Task<byte[]> PdfBoleto(EnumBanco bancoId, CertificadoRequest certificado, string senha, string tokenAcesso, string codigoBeneficiario, string agencia, string linhaDigitavel, string posto, int numeroContrato, string clienteId, string assinanteId, string contaCorrenteId);
        Task<byte[]> GerarCarne(List<byte[]> listaPdf);
        Task<BaixaRetornoModel> BaixaBoleto(EnumBanco bancoId, string senha, string nossoNumeroTransacao, ContaCorrente contaCorrente, string assinanteId);
        Task<BaixaRetornoModel> BaixaBoleto(EnumBanco bancoId, string senha, string tokenAcesso, string posto, BaixaModel model, string clienteId, string assinanteId, string contaCorrenteId);
        Task<RetornoConsultaModel> Obter(EnumBanco bancoId, string senha, ContaCorrente contaCorrente, string nossoNumeroTransacao, string assinanteId);
        Task<RetornoConsultaModel> Obter(EnumBanco bancoId, CertificadoRequest certificados, string senha, string tokenAcesso, string codigoBeneficiario, string agencia, string nossoNumero, string posto, string clientId);
        Task<string> CriarWorkerSpace(List<CertificadoBanco> certificados, string clienteId, string senha, string codigoCedente);
        Task<string> CriarWebhookBradesco(List<CertificadoBanco> certificados, string clienteId, string clientSecret, string cnpjBeneficiario, string assinanteId);
        Task<bool> CriarSubcontaGlobal(SubcontaGlobalModel subconta);
        Task<bool> EnviarDocumentoSubcontaGlobal(SubcontaGlobalDocumentos subconta);

    }
}
