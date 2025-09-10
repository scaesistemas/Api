using SCAE.Data.Interface.Empreendimento;
using SCAE.Domain.Entities.Empreendimento;
using SCAE.Service.Interfaces.Empreendimento;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Empreendimento
{
    public class VicioService : CrudService<Vicio, IVicioRepository>, IVicioService
    {
        public VicioService(IVicioRepository repository) : base(repository)
        {

        }
    }
}
