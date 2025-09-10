using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCAE.Domain.Entities.Geral;
using SCAE.Framework.Helper;
using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Geral;
using SCAE.Framework.Exceptions;
using SCAE.Api.Models.Geral;
using Microsoft.AspNetCore.Authorization;
using SCAE.Api.Helpers;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using SCAE.Api.Attributes;
using SCAE.Service.Interfaces.Base;
using SCAE.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace SCAE.Api.Controllers.Geral
{
    [AllowAnonymous]
    [CustomAuthorize("admin,cliente")]
    public class UsuarioController : MasterCrudController<Usuario>
    {

        private readonly IUsuarioService _service;
        private readonly IAssinanteService _assinanteService;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioService service, IAssinanteService assinanteService) : base(logger, service)
        {
            _service = service;
            _assinanteService = assinanteService;
        }

        #region OverrideMasterCRUD-QUERY
        [CheckPermission(Permissoes.Geral_Usuario_Cadastrar)]
        public override Task<ActionResult<Usuario>> Post([FromBody] Usuario model)
        {
            return base.Post(model);
        }
        [CheckPermission(Permissoes.Geral_Usuario_Alterar)]
        public override Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Usuario> model)
        {
            return base.Patch(id, model);
        }
        [CheckPermission(Permissoes.Geral_Usuario_Alterar)]
        public override Task<IActionResult> Put(int id, [FromBody] Usuario model)
        {
            return base.Put(id, model);
        }
        [CheckPermission(Permissoes.Geral_Usuario_Excluir)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }

        // [CheckPermission(Permissoes.Geral_Usuario_Listar)]
        public override ActionResult<PageResult<Usuario>> Get(ODataQueryOptions<Usuario> options, [FromHeader] string include)
        {
            return base.Get(options, include);
        }
        //  [CheckPermission(Permissoes.Geral_Usuario_Listar)]
        public override Task<ActionResult<Usuario>> GetById(int id, [FromHeader] string include)
        {
            return base.GetById(id, include);
        }

        #endregion

        [HttpPut("{id}/MudarTema")]
        [CheckPermission(Permissoes.Geral_Usuario_MudarTema)]
        public async Task<ActionResult<bool>> MudarTema(int id)
        {
            try
            {
                var temaEscuro = await _service.MudarTema(id);

                return Ok(temaEscuro);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError("{0} - {1}", e.Message, e.InnerException?.Message);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }

        }

        [HttpPost("AlterarSenha")]
        [CheckPermission(Permissoes.Geral_Usuario_AlterarSenha)]
        public async Task<IActionResult> AlterarSenha([FromBody] AlteraSenhaModel model)
        {
            try
            {
                await _service.AlterarSenha(model.UsuarioId, model.SenhaAntiga, model.SenhaNova);

                return Ok(MensagemHelper.OperacaoSucesso);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError("{0} - {1}", e.Message, e.InnerException?.Message);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }

        }

        [HttpPost("{id}/ResetarSenha")]
        [CheckPermission(Permissoes.Geral_Usuario_ResetarSenha)]
        public async Task<IActionResult> ResetarSenha(int id)
        {
            try
            {
                await _service.ResetarSenha(id);

                return Ok(MensagemHelper.OperacaoSucesso);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError("{0} - {1}", e.Message, e.InnerException?.Message);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }

        }

        [HttpGet("{id}/CarregarFoto")]
        //[CheckPermission(Permissoes.Geral_Usuario_Listar)]
        public async Task<ActionResult<byte[]>> CarregarFoto(int id)
        {
            try
            {
                var foto = await _service.CarregarFoto(id);

                return Ok(foto);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError("{0} - {1}", e.Message, e.InnerException?.Message);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }

        }


        [HttpPost("{id}/SalvarPermissoes")]
        [CheckPermission(Permissoes.Geral_Usuario_CadastrarPermissoes)]
        public async Task<IActionResult> SalvarPermissoes(int id, [FromBody] Permissoes[] permissoes)
        {
            try
            {
                await _service.SalvarPermissoes(id, permissoes);

                return Ok(MensagemHelper.OperacaoSucesso);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError("{0} - {1}", e.Message, e.InnerException?.Message);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }

        }

        [HttpPost("PermissoesAllUsuarios")]
        public async Task<IActionResult> PermissoesAllUsuarios()
        {
            try
            {
                await _service.PermissoesPadraoAllUsuarios();

                return Ok(MensagemHelper.OperacaoSucesso);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError("{0} - {1}", e.Message, e.InnerException?.Message);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }
        
        [HttpPost("AlterarMasterParaAdministrador")]
        public async Task<IActionResult> AlterarMasterParaAdministrador(int? assinanteId, bool mudarTodosAssinantes = false)
        {
            try
            {
                ScaeApiContext context;
                if ((assinanteId == null || assinanteId == 0) && mudarTodosAssinantes)
                {
                    var assinantes = await _assinanteService.GetAllNoTracking().ToListAsync();
                    foreach (var assinante in assinantes)
                    {
                        context = await _assinanteService.GetApiContext(assinante.Id);
                        await _service.AlterarMasterParaAdministrador(context);
                    }
                    return Ok(MensagemHelper.OperacaoSucesso);
                }

                if(assinanteId == null || assinanteId == 0)
                    throw new Exception("Assinante id vazio, se deseja mudar todos os assinantes informe o parametro mudarTodosAssinantes como true ou passe um assinanteId para mudar apenas um banco.");

                context = await _assinanteService.GetApiContext(assinanteId.Value);
                await _service.AlterarMasterParaAdministrador(context);
                return Ok(MensagemHelper.OperacaoSucesso);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError("{0} - {1}", e.Message, e.InnerException?.Message);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }
    }
}