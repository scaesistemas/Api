using SCAE.Data.Interface.Base;
using SCAE.Domain.Entities.Base;
using SCAE.Service.Interfaces.Base;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Base
{
    public class TipoTermoEmpresaService : QueryService<TipoTermoEmpresa, ITipoTermoEmpresaRepository>, ITipoTermoEmpresaService
    {
        public TipoTermoEmpresaService(ITipoTermoEmpresaRepository repository) : base(repository)
        {

        }
    }
}
