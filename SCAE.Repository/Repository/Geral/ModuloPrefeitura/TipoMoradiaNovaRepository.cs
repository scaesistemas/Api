using SCAE.Data.Context;
using SCAE.Data.Interface.Geral.ModuloPrefeitura;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral.ModuloPrefeitura;

namespace SCAE.Data.Repository.Geral.ModuloPrefeitura
{
    public class TipoMoradiaNovaRepository : QueryRepository<ScaeApiContext, TipoMoradiaNova>, ITipoMoradiaNovaRepository
    {
        public TipoMoradiaNovaRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
