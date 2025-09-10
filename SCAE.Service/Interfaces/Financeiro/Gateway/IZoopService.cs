using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Models.Zoop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Financeiro.Gateway
{
    public interface IZoopService
    {
        SellerModel ToModelPJ(Empresa empresa);
        SellerIndividualModel ToModelPF(Empresa empresa);
        BankAccountModel ToModel(ContaCorrente contaCorrente);
        BuyerModel ToModel(Pessoa pessoa);
        TransactionModel ToModel(ReceitaParcela parcela, ParametroGatway gateway, string buyerId, string sellerId);
        Task<string> CriarVendedor(SellerModel seller);
        Task<string> CriarVendedor(SellerIndividualModel seller);
        Task<SellerModel> ObterPorCnpj(string cnpj);
        Task<SellerIndividualModel> ObterPorCpf(string cpf);
        Task AtualizarVendedor(SellerModel seller);
        Task AtualizarVendedor(SellerIndividualModel seller);
        Task EnviarDocumentoVendedor(string id, byte[] documento, string categoria, string descricao);
        Task<ReturnBankAccountModel> CriarContaBancaria(BankAccountModel bank);
        Task<string> AssociarContaBancaria(string sellerId, string tokenId);
        Task ExcluirContaBancaria(string id);
        Task<string> CriarComprador(BuyerModel buyer);
        Task AtualizarComprador(BuyerModel buyer);
        Task ExcluirComprador(string id);
        Task<Tuple<string, string, string>> CriarBoleto(TransactionModel transaction);
        Task AtualizarBoleto(TransactionModel transaction);
        Task<TransactionReturnModel> ObterBoletoAsync(string transactionId);
        TransactionModel ObterBoleto(string transactionId);
        Task CancelarBoleto(string transactionId);
        Task<SaldoModel> ObterSaldoPorVendedor(string sellerId);
        Task Transferir(string bankAccountId, TransferModel transfer);
        Task<BalanceInputModel> ListarTransferencias(string sellerId, int limit, int offset);
        Task<List<BalanceOutputModel>> Extrato(string sellerId, DateTime dataInicial, DateTime dataFinal,
            string tipo, int? limit, int? offset);
    }
}
