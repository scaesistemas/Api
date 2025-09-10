using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Shared;

namespace SCAE.Api.Controllers
{
    public class MasterCrudController<TEntity> : MasterQueryController<TEntity> where TEntity : class, IEntity
    {
        private readonly ICrudService<TEntity> _service;
        protected readonly string _includePatch;

        public MasterCrudController(ILogger<MasterCrudController<TEntity>> logger, ICrudService<TEntity> service, string includePatch = "") : base(logger, service)
        {
            _service = service;
            _includePatch = includePatch;
        }

        /// <response code="201"> Operação realizada com sucesso! </response>
        /// <response code="400"> Erros de validação do objeto. </response>
        /// <response code="500"> Algum erro o ocorreu! -> **Detalhamento da aplicação referente ao erro** </response>
        /// <param name="model"> Objeto com os dados a serem incluído. </param>
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public virtual async Task<ActionResult<TEntity>> Post([FromBody] TEntity model)
        {
            try
            {
                await _service.Post(model);

                return Created(string.Empty, model);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError("{0} - {1}", e.Message, e.InnerException?.Message);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }

        /// <response code="200"> Operação realizada com sucesso! </response>
        /// <response code="400"> Id informado é diferente do objeto a ser alterado! </response>
        /// <response code="404"> Registro não encontrado! </response>
        /// <response code="500"> Algum erro o ocorreu! -> **Detalhamento da aplicação referente ao erro** </response>
        /// <param name="id"> Id do objeto que deseja alterar. </param>
        /// <param name="model"> Objeto com os dados completo (alterados e não alterados). </param>
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public virtual async Task<IActionResult> Put(int id, [FromBody] TEntity model)
        {
            if (id != model.Id)
            {
                _logger.LogInformation("{0}", MensagemHelper.IdInformadoDiferenteAlterado);
                return BadRequest(MensagemHelper.IdInformadoDiferenteAlterado);
            }

            try
            {
                var domain = await _service.Get(id);

                if (domain == null)
                {
                    _logger.LogInformation("{0}", MensagemHelper.RegistroNaoEncontrato);
                    return NotFound(MensagemHelper.RegistroNaoEncontrato);
                }

                await _service.Put(model);

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
                _logger.LogError("{0} - {1}", e.Message, e.InnerException?.Message);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }

        /// <response code="200"> Operação realizada com sucesso! </response>
        /// <response code="404"> Registro não encontrado! </response>
        /// <response code="500"> Algum erro o ocorreu! -> **Detalhamento da aplicação referente ao erro** </response>
        /// <param name="id"> Id do objeto que deseja excluir. </param>
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.Delete(id);

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
                _logger.LogError("{0} - {1}", e.Message, e.InnerException?.Message);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }

        /// <response code="200"> Operação realizada com sucesso! </response>
        /// <response code="400"> Id informado é diferente do objeto a ser alterado! </response>
        /// <response code="404"> Registro não encontrado! </response>
        /// <response code="500"> Algum erro o ocorreu! -> **Detalhamento da aplicação referente ao erro** </response>
        /// <param name="id"> Id do objeto que deseja alterar. </param>
        /// <param name="model"> Objeto com os dados completo (alterados e não alterados). </param>
        [HttpPatch("{id}")]
        [Authorize(Roles = "admin")]
        public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<TEntity> model)
        {
            try
            {
                await _service.Patch(id, model, _includePatch);

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
                _logger.LogError("{0} - {1}", e.Message, e.InnerException?.Message);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }
    }
    class Answer<T>
    {
        public T Value;

        public Answer(T value)
        {
            Value = value;
        }
    }
}