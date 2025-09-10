using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Service.Interfaces.Financeiro;

namespace SCAE.Api.Controllers.Financeiro
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoListaBancoController : MasterQueryController<TipoListaBanco>
    {
        public TipoListaBancoController(ILogger<TipoListaBancoController> logger, ITipoListaBancoService service) : base(logger, service)
        {
        }
    }
}