using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Models.Financeiro.Gateway;
using System;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Financeiro.Gateway
{
    public interface ISafraService
    {
        Task<string> GetToken(string clientId, string userName, string password);
        Task<Tuple<string, string, string>> CriarBoleto(string token, BoletoSafraModel boleto);
        BoletoSafraModel ToModel(ReceitaParcela parcela, ParametroGatway gateway);
    }
}
