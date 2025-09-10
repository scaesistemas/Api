using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Shared
{
    public interface ISmsService
    {
        string GerarCorpoCobranca(int layoutId, string clienteNome, string dataVencimento, string contratoNumero, string linhaDigitavel, string linkBoleto, string dominio, string empresaNome, string empresaNumero, string empresaEmail);
        Task EnviarSms(string destinatario, string texto);
    }
}