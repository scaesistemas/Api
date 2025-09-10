using SCAE.Data.Interface.Compras;
using SCAE.Domain.Entities.Compras;
using SCAE.Service.Interfaces.Compras;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Compras
{
    public class SituacaoOrcamentoService : QueryService<SituacaoOrcamento, ISituacaoOrcamentoRepository>, ISituacaoOrcamentoService
    {
        public SituacaoOrcamentoService(ISituacaoOrcamentoRepository repository) : base(repository)
        {

        }
    }
}
