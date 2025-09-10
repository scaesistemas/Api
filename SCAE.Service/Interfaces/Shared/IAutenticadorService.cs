using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SCAE.Domain.Models.Shared;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Shared
{
    public interface IAutenticadorService
    {
        Task<object> Autenticar(LoginModel model);
        Task<object> AutenticarCliente(LoginModel model);
        Task<object> AutenticarCorretor(LoginModel model);

        Task<object> AutenticarAdm(LoginModel model);
        Task<string> ConfirmaEmail(string token);
        Task<string> ResetarSenha(string usuarioLogin, string token, string novaSenha);
        TokenValidationParameters GetValidationParameters();
        bool AutenticarApiKey(string headerKey);
    }
}
