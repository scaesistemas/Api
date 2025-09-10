using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.OrcamentoObras;
using ObrasDomain = SCAE.Domain.Entities.OrcamentoObras;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.OrcamentoObras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Api.Controllers.OrcamentoObras
{
    public class ModeloOrcamentoEtapaController : MasterCrudController<ModeloOrcamentoEtapa>
    {
        private readonly IModeloOrcamentoEtapaService _service;
        public ModeloOrcamentoEtapaController(ILogger<ModeloOrcamentoEtapaController> logger, IModeloOrcamentoEtapaService service) : base(logger, service, "Itens")
        {
            _service = service;
        }
        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.OrcamentoObras_ClasseComposicao_Cadastrar)]
        public override Task<ActionResult<ModeloOrcamentoEtapa>> Post([FromBody] ModeloOrcamentoEtapa model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.OrcamentoObras_ClasseComposicao_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ModeloOrcamentoEtapa> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.OrcamentoObras_ClasseComposicao_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] ModeloOrcamentoEtapa model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.OrcamentoObras_ClasseComposicao_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
        [CheckPermission(Permissoes.OrcamentoObras_ClasseComposicao_Listar)]
        public override ActionResult<PageResult<ModeloOrcamentoEtapa>> Get(ODataQueryOptions<ModeloOrcamentoEtapa> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        [CheckPermission(Permissoes.OrcamentoObras_ClasseComposicao_Listar)]
        public override Task<ActionResult<ModeloOrcamentoEtapa>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }
#endregion

    /// <summary>
    /// Salva OrcamentoEtapa como ModeloOrcamentoEtapa
    /// </summary>
    /// <param name="orcamentoEtapaId">Id válido de OrcamentoEtapa no sistema</param>
    /// <param name="estadoId">Id válido de Estado no sistema. Se não for informado, autmaticamente será preenchido com o Id de São Paulo</param>
    /// <returns></returns>
    /// stac
    [HttpPost("SalvarComoModelo/{orcamentoEtapaId}")]
        [CheckPermission(Permissoes.OrcamentoObras_OrcamentoObras_Cadastrar)]
        public async Task<IActionResult> SalvarComoModelo(int orcamentoEtapaId, [FromQuery] int estadoId = 0)
        {
            try
            {
                //var estadoIdMaximo = Estado.ObterDados().Max(x => x.Id);

                //if (estadoId < 1 || estadoId > estadoIdMaximo)
                var isValido = Estado.ObterDados().Select(x => x.Id).Contains(estadoId);
                if (!isValido)
                    throw new NotFoundException($"Valor de { estadoId } inválido.");

                await _service.SalvarComoModelo(orcamentoEtapaId, estadoId);

                return Ok(MensagemHelper.OperacaoSucesso);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }

        //[HttpGet("GetMenorId")]
        //[CheckPermission(Permissoes.OrcamentoObras_OrcamentoEtapa_Listar)]
        //public async Task<ActionResult<ModeloOrcamentoEtapa>> GetMenorId([FromHeader] string include)
        //{
        //    try
        //    {
        //        var modelo = await _service.GetMenorIdNoTracking(include);

        //        if (modelo == null)
        //            return NotFound(MensagemHelper.RegistroNaoEncontrato);

        //        return Ok(modelo);
        //    }
        //    catch (NotFoundException e)
        //    {
        //        return NotFound(e.Message);
        //    }
        //    catch (BadRequestException e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
        //    }
        //}

        [HttpGet("TreeView/{id}")]
        [CheckPermission(Permissoes.OrcamentoObras_OrcamentoEtapa_Listar)]
        public async Task<ActionResult<ModeloOrcamentoEtapa>> GetTreeView(int id)
        {
            try
            {
                var modelo = await _service.GetTreeViewNoTracking(id);

                if (modelo == null)
                    return NotFound(MensagemHelper.RegistroNaoEncontrato);

                return Ok(modelo);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }

        [HttpGet("TreeView")]
        [CheckPermission(Permissoes.OrcamentoObras_OrcamentoEtapa_Listar)]
        public async Task<ActionResult<List<ModeloOrcamentoEtapa>>> GetTreeView()
        {
            try
            {
                var modelos = await _service.GetTreeViewNoTracking();

                return Ok(modelos);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }

        [HttpPost("Aplicar/{id}")]
        [CheckPermission(Permissoes.OrcamentoObras_OrcamentoEtapa_Listar)]
        public async Task<ActionResult<int>> AplicarModelo(int id, [FromBody] ObrasDomain.OrcamentoObras orcamento, [FromQuery] int? etapaPaiId)
        {
            try
            {
                var IdRetorno = await _service.AplicarModelo(id, orcamento, etapaPaiId);

                return Ok(IdRetorno);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }

    }

}