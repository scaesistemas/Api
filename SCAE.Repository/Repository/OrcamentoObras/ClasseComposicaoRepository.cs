using SCAE.Data.Context;
using SCAE.Data.Interface.OrcamentoObras;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.OrcamentoObras;

namespace SCAE.Data.Repository.OrcamentoObras
{
    public class ClasseComposicaoRepository : CrudRepository<ScaeApiContext, ClasseComposicao>, IClasseComposicaoRepository
    {
        public ClasseComposicaoRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
