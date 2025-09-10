using SCAE.Data.Interface.Financeiro;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Financeiro
{
    public class SituacaoReceitaParcelaService : QueryService<SituacaoReceitaParcela, ISituacaoReceitaParcelaRepository>, ISituacaoReceitaParcelaService
    {
        public SituacaoReceitaParcelaService(ISituacaoReceitaParcelaRepository repository) : base(repository)
        {

        }
    }
}
