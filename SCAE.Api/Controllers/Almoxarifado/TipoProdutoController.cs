using SCAE.Domain.Entities.Almoxarifado;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Almoxarifado;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using System.Threading.Tasks;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Api.Controllers.Almoxarifado
{
    public class TipoProdutoController : MasterQueryController<TipoProduto>
    {
        public TipoProdutoController(ILogger<TipoProdutoController> logger, ITipoProdutoService service) : base(logger, service)
        {
        }
        #region OverrideMasterQUERY
        [CheckPermission(Permissoes.Almoxarifado_TipoProduto_Listar)]
        public override ActionResult<PageResult<TipoProduto>> Get(ODataQueryOptions<TipoProduto> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Almoxarifado_TipoProduto_Listar)]
        public override Task<ActionResult<TipoProduto>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}