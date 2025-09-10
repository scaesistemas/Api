using SCAE.Data.Context;
using SCAE.Data.Interface.OrcamentoObras;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.OrcamentoObras;

namespace SCAE.Data.Repository.OrcamentoObras
{
    public class OrigemDadosRepository : QueryRepository<ScaeApiContext, OrigemDados>, IOrigemDadosRepository
    {
        public OrigemDadosRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
