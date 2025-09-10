using SCAE.Data.Context;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Data.Repository.Geral
{
    public class ProfissaoRepository : QueryRepository<ScaeApiContext, Profissao>, IProfissaoRepository
    {
        public ProfissaoRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
