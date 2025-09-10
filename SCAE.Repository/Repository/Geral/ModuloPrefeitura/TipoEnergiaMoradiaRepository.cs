using SCAE.Data.Context;
using SCAE.Data.Interface.Geral.ModuloPrefeitura;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral.ModuloPrefeitura;

namespace SCAE.Data.Repository.Geral.ModuloPrefeitura
{
    public class TipoEnergiaMoradiaRepository : QueryRepository<ScaeApiContext, TipoEnergiaMoradia>, ITipoEnergiaMoradiaRepository
    {
        public TipoEnergiaMoradiaRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
