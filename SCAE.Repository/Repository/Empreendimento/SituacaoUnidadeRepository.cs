using SCAE.Data.Context;
using SCAE.Data.Interface.Empreendimento;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Empreendimento;

namespace SCAE.Data.Repository.Empreendimento
{
    public class SituacaoUnidadeRepository : QueryRepository<ScaeApiContext, SituacaoUnidade>, ISituacaoUnidadeRepository
    {
        public SituacaoUnidadeRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
