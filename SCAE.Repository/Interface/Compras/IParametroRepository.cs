using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Compras;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.Compras
{
    public interface IParametroRepository : ICrudRepository<Parametro>
    {
        Task<Parametro> GetFirst();
    }
}
