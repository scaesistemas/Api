using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Geral;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.Geral
{
    public interface ICartorioRepository : ICrudRepository<Cartorio>
    {
        Task<Cartorio> GetByNome(string nome);
    }
}
