using SCAE.Data.Context;
using SCAE.Data.Interface.Empreendimento;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Empreendimento;

namespace SCAE.Data.Repository.Empreendimento
{
    public class TipoImovelRepository : QueryRepository<ScaeApiContext, TipoImovel>, ITipoImovelRepository
    {
        public TipoImovelRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
