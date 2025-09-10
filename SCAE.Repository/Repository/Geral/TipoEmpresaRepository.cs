using SCAE.Data.Context;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Data.Repository.Geral
{
    public class TipoEmpresaRepository : QueryRepository<ScaeApiContext, TipoEmpresa>, ITipoEmpresaRepository
    {
        public TipoEmpresaRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
