using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.Projeto;
using SCAE.Service.Interfaces.Projeto;
using SCAE.Service.Interfaces.Shared;
using System.Threading.Tasks;

namespace SCAE.Api.Controllers.Projeto
{
    public class TipoContratoFornecedorController : MasterQueryController<TipoContratoFornecedor>
    {
        public TipoContratoFornecedorController(ILogger<MasterQueryController<TipoContratoFornecedor>> logger, ITipoContratoFornecedorService service) : base(logger, service)
        {
        }

        #region OverrideMasterCRUD-QUERY

        [CheckPermission(Permissoes.Projeto_TipoContratoFornecedor_Listar)]
        public override ActionResult<PageResult<TipoContratoFornecedor>> Get(ODataQueryOptions<TipoContratoFornecedor> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Projeto_TipoContratoFornecedor_Listar)]
        public override Task<ActionResult<TipoContratoFornecedor>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }

        #endregion

    }
}
