using SCAE.Data.Context;
using SCAE.Domain.Entities.Base;
using SCAE.Service.Interfaces.Shared;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Base
{
    public interface IAssinanteService : ICrudService<Assinante>
    {
        Assinante ObterAssinante(string host);
        Task<string> WhatsApp(int id);
        Task<ScaeApiContext> GetApiContext(int assinanteId);
    }
}
