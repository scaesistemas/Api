using Microsoft.EntityFrameworkCore;
using SCAE.Domain.Entities.Clientes;
using SCAE.Data.Context;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Shared;
using SCAE.Service.Interfaces.Clientes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using System.Threading.Tasks;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Api.Controllers.Clientes
{
    public class TipoOperacaoContratoController : MasterQueryController<TipoOperacaoContrato>
    {
        public TipoOperacaoContratoController(ILogger<TipoOperacaoContratoController> logger, ITipoOperacaoContratoService service) : base(logger, service)
        {

        }
        #region OverrideMasterQUERY
        [CheckPermission(Permissoes.Clientes_TipoOperacaoContrato_Listar)]
        public override ActionResult<PageResult<TipoOperacaoContrato>> Get(ODataQueryOptions<TipoOperacaoContrato> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Clientes_TipoOperacaoContrato_Listar)]
        public override Task<ActionResult<TipoOperacaoContrato>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}