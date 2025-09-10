using SCAE.Domain.Entities.Financeiro;
using SCAE.Service.Interfaces.Shared;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Financeiro
{
    public interface IIndiceService : ICrudService<Indice>
    {
        Task<string> DeleteDataInferior(string ano);
    }
}
