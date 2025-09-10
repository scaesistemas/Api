using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Service.Interfaces.Financeiro;

namespace SCAE.Api.Controllers.Financeiro
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoStatusTransacaoController : MasterQueryController<TipoStatusTransacao>
    {
        public TipoStatusTransacaoController(ILogger<TipoStatusTransacaoController> logger, ITipoStatusTransacaoService service) : base(logger, service)
        {
        }
    }
}