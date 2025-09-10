using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCAE.Domain.Entities.Compras;
using SCAE.Framework.Helper;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Compras;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Api.Controllers.Compras
{
    [Route("api/compras/[controller]")]
    public class ParametroController : MasterCrudController<Parametro>
    {
        private readonly IParametroService _service;
        public ParametroController(ILogger<ParametroController> logger, IParametroService service) : base(logger, service)
        {
            _service = service;
        }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Compras_Parametro_Cadastrar)]
        public override Task<ActionResult<Parametro>> Post([FromBody] Parametro model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Compras_Parametro_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Parametro> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Compras_Parametro_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] Parametro model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Compras_Parametro_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }

        [CheckPermission(Permissoes.Compras_Parametro_Listar)]
        public override ActionResult<PageResult<Parametro>> Get(ODataQueryOptions<Parametro> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.Compras_Parametro_Listar)]
        public override Task<ActionResult<Parametro>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }

        #endregion

        [HttpGet("First")]
        [CheckPermission(Permissoes.Compras_Parametro_Listar)]
        public async Task<ActionResult<Parametro>> GetFirst()
        {
            try
            {
                var domain = await _service.GetFirst();

                if (domain == null)
                    return NotFound(MensagemHelper.RegistroNaoEncontrato);

                return Ok(domain);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }
    }
}