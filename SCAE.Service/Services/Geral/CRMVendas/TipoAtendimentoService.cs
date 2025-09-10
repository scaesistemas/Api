using SCAE.Data.Interface.Geral.CRMVendas;
using SCAE.Domain.Entities.Geral.CRMVendas;
using SCAE.Service.Interfaces.Geral.CRMVendas;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Geral.CRMVendas
{
    public class TipoAtendimentoService : QueryService<TipoAtendimento, ITipoAtendimentoRepository>, ITipoAtendimentoService
    {
        public TipoAtendimentoService(ITipoAtendimentoRepository repository) : base(repository)
        {

        }
    }
}
