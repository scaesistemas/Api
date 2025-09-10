using SCAE.Domain.Entities.Geral;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Geral;

namespace SCAE.Api.Controllers.Geral
{
    public class TipoEmpresaController : MasterQueryController<TipoEmpresa>
    {
        public TipoEmpresaController(ILogger<TipoEmpresaController> logger, ITipoEmpresaService service) : base(logger, service)
        {

        }

    }
}