using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Shared
{
    public interface IEmailService
    {
        string GerarCorpo(string usuario, string corpoEmail, string assinatura);
        string GerarCorpoCobranca(int layoutId, string clienteNome, string dataVencimento, string contratoNumero, string linkBoleto,string dominio, string caminhoLogo, string empresaNome, string empresaNumero, string empresaEmail);
        string GerarCorpoCobranca(int layoutId, string clienteNome, string dataVencimento, string contratoNumero, string linhaDigitavel, string qrCode, string dominio, string caminhoLogo, string empresaNome, string empresaNumero, string empresaEmail );
        Task EnviarEmail(string destinatario, string assunto, string corpo);
        Task EnviarEmail(string remetente, string remetenteNome, string destinatario, string assunto, string corpo, string clienteSMTP, int portaSMTP, bool usarSSL, string credencialUsuario, string credencialSenha);
    }

}
