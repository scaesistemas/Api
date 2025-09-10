using SCAE.Data.Interface.Financeiro;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Services.Shared;


namespace SCAE.Service.Services.Financeiro
{
    public class TipoAntecipacaoService : QueryService<TipoAntecipacao, ITipoAntecipacaoRepository>, ITipoAntecipacaoService
    {
        public TipoAntecipacaoService(ITipoAntecipacaoRepository repository) : base(repository)
        {
        }
    }
}
