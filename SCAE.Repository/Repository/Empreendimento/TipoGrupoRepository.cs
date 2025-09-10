using SCAE.Data.Context;
using SCAE.Data.Interface.Empreendimento;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Empreendimento;

namespace SCAE.Data.Repository.Empreendimento
{
    public class TipoGrupoRepository : QueryRepository<ScaeApiContext, TipoGrupo>, ITipoGrupoRepository
    {
        public TipoGrupoRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
