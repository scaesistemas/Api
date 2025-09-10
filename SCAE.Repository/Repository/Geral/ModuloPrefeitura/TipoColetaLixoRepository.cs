using SCAE.Data.Context;
using SCAE.Data.Interface.Geral.ModuloPrefeitura;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral.ModuloPrefeitura;

namespace SCAE.Data.Repository.Geral.ModuloPrefeitura
{
    public class TipoColetaLixoRepository : QueryRepository<ScaeApiContext, TipoColetaLixo>, ITipoColetaLixoRepository
    {
        public TipoColetaLixoRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
