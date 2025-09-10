using SCAE.Domain.Entities.Compras;
using SCAE.Service.Interfaces.Shared;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Compras
{
    public interface IParametroService : ICrudService<Parametro>
    {
        Task<Parametro> GetFirst();
    }
}
