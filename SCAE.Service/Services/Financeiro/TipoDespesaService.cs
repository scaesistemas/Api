using SCAE.Data.Interface.Financeiro;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Financeiro
{
    public class TipoDespesaService : QueryService<TipoDespesa, ITipoDespesaRepository>, ITipoDespesaService
    {
        public TipoDespesaService(ITipoDespesaRepository repository) : base(repository)
        {

        }
    }
}
