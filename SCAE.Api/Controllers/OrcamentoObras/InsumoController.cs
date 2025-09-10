using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.OrcamentoObras;
using SCAE.Service.Interfaces.OrcamentoObras;
using System.Threading.Tasks;
using SCAE.Data.Interface.Geral;

namespace SCAE.Api.Controllers.OrcamentoObras
{
    public class InsumoController : MasterCrudController<Insumo>
    {
        public readonly IInsumoService _service;
        public readonly IEstadoRepository _estadoRepository;
        public InsumoController(ILogger<InsumoController> logger, IInsumoService service, IEstadoRepository estadoRepository) : base(logger, service)
        {
            _service = service;
            _estadoRepository = estadoRepository;
        }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.OrcamentoObras_Insumo_Cadastrar)]
        public override Task<ActionResult<Insumo>> Post([FromBody] Insumo model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.OrcamentoObras_Insumo_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Insumo> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.OrcamentoObras_Insumo_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] Insumo model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.OrcamentoObras_Insumo_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.OrcamentoObras_Insumo_Listar)]
        public override ActionResult<PageResult<Insumo>> Get(ODataQueryOptions<Insumo> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.OrcamentoObras_Insumo_Listar)]
        public override Task<ActionResult<Insumo>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
        #endregion

    }
}
