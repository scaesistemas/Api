using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Geral;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.Geral
{
    public interface IUsuarioRepository : ICrudRepository<Usuario>
    {
        Task<Usuario> Login(string login);
        Task<bool> LoginDuplicado(string login);
    }
}
