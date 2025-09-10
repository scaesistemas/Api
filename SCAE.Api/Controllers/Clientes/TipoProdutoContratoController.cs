using SCAE.Domain.Entities.Clientes;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Clientes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using System.Threading.Tasks;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Api.Controllers.Clientes
{
    public class TipoProdutoContratoController : MasterQueryController<TipoProdutoContrato>
    {
        public TipoProdutoContratoController(ILogger<TipoProdutoContratoController> logger, ITipoProdutoContratoService service) : base(logger, service)
        {

        }

        #region OverrideMasterQUERY
        [CheckPermission(Permissoes.Clientes_TipoProdutoContrato_Listar)]
        public override ActionResult<PageResult<TipoProdutoContrato>> Get(ODataQueryOptions<TipoProdutoContrato> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Clientes_TipoProdutoContrato_Listar)]
        public override Task<ActionResult<TipoProdutoContrato>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }

        #endregion
    }
}