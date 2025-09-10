using SCAE.Data.Context;
using SCAE.Domain.Entities.Geral;
using SCAE.Service.Interfaces.Shared;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Geral
{
    public interface IUsuarioService : ICrudService<Usuario>
    {
        Task Post(Usuario usuario, string dominio);
        Task<Usuario> Login(string login, string senha);
        Task AlterarSenha(int id, string senhaAntiga, string senhaNova);
        Task<bool> MudarTema(int id);
        Task ResetarSenha(int id);
        Task ResetarSenha(int id, string senhaNova);
        Task<byte[]> CarregarFoto(int id);
        Task SalvarPermissoes(int id, Permissoes[] permissoes);
        Task PermissoesPadraoAllUsuarios();
        Task AlterarMasterParaAdministrador(ScaeApiContext context);
    }
}
