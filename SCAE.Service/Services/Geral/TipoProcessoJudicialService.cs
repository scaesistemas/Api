using SCAE.Data.Interface.Geral;
using SCAE.Domain.Entities.Geral;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Geral
{
    public class TipoProcessoJudicialService : CrudService<TipoProcessoJudicial, ITipoProcessoJudicialRepository>, ITipoProcessoJudicialService
    {
        public TipoProcessoJudicialService(ITipoProcessoJudicialRepository repository) : base(repository)
        {
        }
    }
}
