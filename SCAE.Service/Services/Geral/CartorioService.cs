using SCAE.Data.Interface.Geral;
using SCAE.Domain.Entities.Geral;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Services.Shared;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Geral
{
    public class CartorioService : CrudService<Cartorio, ICartorioRepository>, ICartorioService
    {
        public CartorioService(ICartorioRepository repository) : base(repository)
        {

        }

        public async Task<Cartorio> GetByNome(string nome)
        {
            return await _repository.GetByNome(nome);
        }
    }
}
