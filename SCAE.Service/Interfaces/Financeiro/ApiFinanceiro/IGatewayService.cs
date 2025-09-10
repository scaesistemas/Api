using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Gateway;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Shared;
using SCAE.Domain.Models.GalaxPay;
using SCAE.Domain.Models.Hokma;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Financeiro.ApiFinanceiro
{
    public interface IGatewayService
    {
        Task<RetornoModel> CriarBoleto(EnumGateway gateway, ReceitaParcela parcelaBoleto, Pessoa pagador, Empresa beneficiario, string empresaId, string empresaHash, string assinanteId = "");
        Task<RetornoModel> CriarBoleto(EnumGateway gateway, ReceitaParcela parcelaBoleto, string codigoPagador, string codigoBeneficiario, string assinanteId = "");
        Task<SubcontaConsultaModel> VerificarSubContaAtiva(EnumGateway gateway, string empresaId);
        Task AtualizarBoleto(EnumGateway gateway, ReceitaParcela parcelaBoleto, Pessoa pagador, Empresa beneficiario, string empresaId, string empresaHash, string assinanteId);
        Task AtualizarBoleto(EnumGateway gateway, ReceitaParcela parcelaBoleto, string codigoPagador, string codigoBeneficiario, string assinanteId);
        Task<string> CriarPagador(EnumGateway gatewayId, Pessoa pagador, string empresaId = "", string empresaHash = "");
        Task AtualizarPagador(EnumGateway gatewayId, Pessoa pagador, string empresaId = "", string empresaHash = "");
        Task ExcluirPagador(EnumGateway gatewayId, string codigo, string empresaId = "", string empresaHash = "");
        Task<string> CriarVendedorPF(EnumGateway gatewayId, Empresa beneficiario);
        Task AtualizarVendedorPF(EnumGateway gatewayId, Empresa beneficiario);
        Task<string> CriarVendedorPJ(EnumGateway gatewayId, Empresa beneficiario);
        Task AtualizarVendedorPJ(EnumGateway gatewayId, Empresa beneficiario);
        Task ExcluirContaBancaria(EnumGateway gatewayId, string codigo);
        Task<(string Id, string BankAccountId)> CriarContaBancaria(EnumGateway gatewayId, ContaCorrente contaCorrente);
        Task<string> AssociarContaBancaria(EnumGateway gatewayId, string pagadorId, string tokenId);
        Task CancelarBoleto(EnumGateway gateway, string codigo, string empresaId = "", string empresaHash = "");
        Task<TransacaoRetornoModel> ObterBoleto(EnumGateway gateway, string codigo, string empresaId = "", string empresaHash = "");
        Task<string> GerarCarne(EnumGateway gateway, List<string> codigos, string empresaId = "", string empresaHash = "");
        Task<RetornoSubContaModel> CriarSubConta(EnumGateway gatewayId, SubContaModel model);
        Task<SubcontaConsultaModel> ConsultarSubconta(EnumGateway gateway, string empresaId);
        Task EnviarDocumentoSubConta(EnumGateway gateway, SubcontaDocumentoScaeModel model, string empresaId, string empresaHash);
    }
}
