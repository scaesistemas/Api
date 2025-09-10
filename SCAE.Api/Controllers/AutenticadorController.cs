using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SCAE.Domain.Models.Shared;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Shared;

namespace SCAE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticadorController : ControllerBase
    {
        private readonly IAutenticadorService _service;

        public AutenticadorController(IAutenticadorService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Usuario")]
        public async Task<IActionResult> Autenticar([FromBody] LoginModel model)
        {
            try
            {
                return Ok(await _service.Autenticar(model));
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

        [HttpPost]
        [Route("Cliente")]
        public async Task<IActionResult> AutenticarCliente([FromBody] LoginModel model)
        {
            try
            {
                return Ok(await _service.AutenticarCliente(model));
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

        [HttpPost]
        [Route("Corretor")]
        public async Task<IActionResult> AutenticarCorretor([FromBody] LoginModel model)
        {
            try
            {
                return Ok(await _service.AutenticarCorretor(model));
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


        [HttpPost]
        [Route("Adm")]
        public async Task<IActionResult> AutenticarAdm([FromBody] LoginModel model)
        {
            try
            {
                return Ok(await _service.AutenticarAdm(model));
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
        //resetar Api::
        [AllowAnonymous]
        [HttpPost("ResetarSenha")]
        public async Task<IActionResult> ResetarSenha([FromBody] ResetarSenhaModel model)
        {
            try
            {
                return Ok(await _service.ResetarSenha(model.Login, model.Token, model.SenhaNova));
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
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }
        //autenticar
        [AllowAnonymous]
        [HttpPost("ConfirmarEmail")]        
        public async Task<ActionResult<string>> ConfirmarEmail(string token)
        {
            try
            {
                return await _service.ConfirmaEmail(token);
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

        [HttpGet("ValidaToken")]
        public bool ValidaToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = _service.GetValidationParameters();

                SecurityToken validatedToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

                return true;
            }
            catch
            {
                return false;
            }
        }

    }

}