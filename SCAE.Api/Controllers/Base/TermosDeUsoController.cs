using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Base;
using SCAE.Service.Interfaces.Base;

namespace SCAE.Api.Controllers.Base
{
    public class TermosDeUsoController : MasterCrudController<TermosDeUso>
    {
        private readonly ITermosDeUsoService _service;
        public TermosDeUsoController(ILogger<TermosDeUsoController> logger, ITermosDeUsoService service) : base(logger, service)
        {
            _service = service;
        }
    }
}
