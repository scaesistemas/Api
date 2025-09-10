using SCAE.Data.Interface.Geral;
using SCAE.Domain.Entities.Geral;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Geral
{
    public class SeguradoraService : CrudService<Seguradora, ISeguradoraRepository>, ISeguradoraService
    {
        public SeguradoraService(ISeguradoraRepository repository) : base(repository)
        {

        }
    }
}
