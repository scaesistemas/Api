using SCAE.Data.Context;
using SCAE.Data.Interface.Empreendimento;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Empreendimento;

namespace SCAE.Data.Repository.Empreendimento
{
    public class TipoUnidadeRepository : QueryRepository<ScaeApiContext, TipoUnidade>, ITipoUnidadeRepository
    {
        public TipoUnidadeRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
