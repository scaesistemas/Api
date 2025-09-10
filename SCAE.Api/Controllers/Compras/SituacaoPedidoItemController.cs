using SCAE.Domain.Entities.Compras;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Compras;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using System.Threading.Tasks;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Api.Controllers.Compras
{
    public class SituacaoPedidoItemController : MasterQueryController<SituacaoPedidoItem>
    {
        public SituacaoPedidoItemController(ILogger<SituacaoPedidoItemController> logger, ISituacaoPedidoItemService service) : base(logger, service)
        {

        }
        #region OverrideMasterQUERY
        [CheckPermission(Permissoes.Compras_SituacaoPedidoItem_Listar)]
        public override ActionResult<PageResult<SituacaoPedidoItem>> Get(ODataQueryOptions<SituacaoPedidoItem> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Compras_SituacaoPedidoItem_Listar)]
        public override Task<ActionResult<SituacaoPedidoItem>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}