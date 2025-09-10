using SCAE.Domain.Entities.Geral;
using SCAE.Service.Interfaces.Shared;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Geral
{
    public interface ICartorioService : ICrudService<Cartorio>
    {
        Task<Cartorio> GetByNome(string nome);
    }
}
