using SCAE.Data.Interface.Compras;
using SCAE.Domain.Entities.Compras;
using SCAE.Service.Interfaces.Compras;
using SCAE.Service.Services.Shared;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Compras
{
    public class ParametroService : CrudService<Parametro, IParametroRepository>, IParametroService
    {
        public ParametroService(IParametroRepository repository) : base(repository)
        {
        }

        public async Task<Parametro> GetFirst()
        {
            return await _repository.GetFirst();
        }
    }
}
