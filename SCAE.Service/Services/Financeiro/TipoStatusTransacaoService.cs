using SCAE.Domain.Entities.Financeiro;
using SCAE.Data.Interface.Financeiro;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Financeiro
{
    public class TipoStatusTransacaoService : CrudService<TipoStatusTransacao, ITipoStatusTransacaoRepository>, ITipoStatusTransacaoService
    {
        public TipoStatusTransacaoService(ITipoStatusTransacaoRepository repository) : base(repository)
        {

        }
    }
}