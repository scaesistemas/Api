using SCAE.Data.Context;
using SCAE.Data.Interface.Geral.ModuloPrefeitura;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral.ModuloPrefeitura;

namespace SCAE.Data.Repository.Geral.ModuloPrefeitura
{
    public class TipoAbastecimentoAguaRepository : QueryRepository<ScaeApiContext, TipoAbastecimentoAgua>, ITipoAbastecimentoAguaRepository
    {
        public TipoAbastecimentoAguaRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
