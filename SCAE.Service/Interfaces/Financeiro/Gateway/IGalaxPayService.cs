using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Models.GalaxPay;
using System;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Financeiro.Gateway
{
    public interface IGalaxPayService
    {
        Task<CustomerModel> ToModel(Pessoa pessoa);
        Task CriarCliente(CustomerModel customer, string empresaId, string empresaHash);
        ChargeModel ToBoletoModel(ReceitaParcela parcela, ParametroGatway gateway);
        Task<(string urlBoleto, string linhaDigitavel)> CriarBoleto(ChargeModel charge, string empresaId, string empresaHash);
        Task AtualizarBoleto(ChargeModel charge, string empresaId, string empresaHash);
        Task CancelarBoleto(string parcelaId, string empresaId, string empresaHash);
        Task<ChargeReturnModel> ObterBoletoAsync(string chargeId, string empresaId, string empresaHash);
    }
}
