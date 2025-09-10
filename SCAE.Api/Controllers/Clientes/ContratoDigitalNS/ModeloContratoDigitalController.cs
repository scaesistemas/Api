using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Clientes.ContratoDigitalNS;
using SCAE.Service.Interfaces.Clientes.ContratoDigitalNS;

namespace SCAE.Api.Controllers.Clientes.ContratoDigitalNS
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloContratoDigitalController : MasterCrudController<ModeloContratoDigital>
    {
        public ModeloContratoDigitalController(ILogger<ModeloContratoDigitalController> logger, IModeloContratoDigitalService service) : base(logger, service)
        {
            
        }
    }
}
