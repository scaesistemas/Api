using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SCAE.Domain.Models.Shared;

namespace SCAE.Service.Interfaces.Shared
{
    public interface IWhatsappService
    {
        MessageWhatsappModel GerarMensagem(string phone, string nome, decimal valor, DateTime dataVencimento, string urlBoleto, int numeroParcela, string nomeEmpresa, string contrato);
        MessageWhatsappModel GerarMensagem(string phone, string nome, decimal valor, DateTime dataVencimento, string linhaDigitavel, string qrcode, int numeroParcela, string nomeEmpresa, string contrato);
        Task<string> EnviarMensagem(MessageWhatsappModel message);
    }
}
