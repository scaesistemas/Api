using SCAE.Data.Context;
using SCAE.Data.Interface.Empreendimento;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Empreendimento;

namespace SCAE.Data.Repository.Empreendimento
{
    public class TipoEmpreendimentoRepository : QueryRepository<ScaeApiContext, TipoEmpreendimento>, ITipoEmpreendimentoRepository
    {
        public TipoEmpreendimentoRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
