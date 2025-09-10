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
    public class TipoMovimentacaoController : MasterQueryController<TipoMovimentacao>
    {
        public TipoMovimentacaoController(ILogger<TipoMovimentacaoController> logger, ITipoMovimentacaoService service) : base(logger, service)
        {
        }
        #region OverrideMasterQUERY
        [CheckPermission(Permissoes.Almoxarifado_TipoMovimentacao_Listar)]
        public override ActionResult<PageResult<TipoMovimentacao>> Get(ODataQueryOptions<TipoMovimentacao> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Almoxarifado_TipoMovimentacao_Listar)]
        public override Task<ActionResult<TipoMovimentacao>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion
    }
}