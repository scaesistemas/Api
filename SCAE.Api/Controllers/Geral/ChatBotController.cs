using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SCAE.Domain.Models.ChatBot;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Interfaces.Shared;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace SCAE.Api.Controllers.Geral
{
    [AllowAnonymous]
    //[Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ChatBotController : ControllerBase
    {
        private readonly IChatBotService _service;
        private readonly IAutenticadorService _autenticador;

        public ChatBotController(IChatBotService service, IAutenticadorService autenticador)
        {
            _service = service;
            _autenticador = autenticador;
        }

        [HttpPost("ChecarContratosCliente")]
        [AllowAnonymous]
        public async Task<ActionResult<(MenuChatBotModel, InformacaoChatBotModel)>> ChecarContratosCliente([FromBody] RequestChatBotModel requisicao)
        {
            try
            {
                if (!_autenticador.AutenticarApiKey("mz-authorization"))
                {
                    return Ok(new InformacaoChatBotModel() { Texto = "401 - Algum erro inesperado aconteceu. \n Por favor, entre em contato diretamente com um dos nossos atendentes.\nPedimos desculpas pelo transtorno." });
                }

                var resposta = await _service.MenuContratosCliente(requisicao);

                if (resposta.menuChatBotRetorno != null)
                    return Ok(resposta.menuChatBotRetorno);

                else if (resposta.InformacaoChatBotRetorno != null)
                    return Ok(resposta.InformacaoChatBotRetorno);

                return Ok(new InformacaoChatBotModel() { Texto = "Algum erro inesperado aconteceu. \n Por favor, entre em contato diretamente com um dos nossos atendentes.\nPedimos desculpas pelo transtorno." });
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

        [HttpPost("GetBoleto")]
        [AllowAnonymous]
        public async Task<ActionResult<InformacaoChatBotModel>> GetBoletoCliente([FromBody] RequestChatBotModel requisicao)
        {
            try
            {
                var boleto = await _service.GetBoletoCliente(requisicao, requisicao.DadosAdicionais.IdAssinante);

                return Ok(boleto);
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

        //[HttpPost("SalvarImagem")]
        //[AllowAnonymous]
        //public async Task<IActionResult> SalvarLogoEmail([FromBody] byte[] logo)
        //{
        //    MemoryStream ms = new MemoryStream(logo);
        //    IFormFile file = new FormFile(ms, 0, logo.Length, "name", "fileName.jpg");
        //    if (file != null)
        //    {
        //        var teste = AppDomain.CurrentDomain.BaseDirectory + "/Template/";

        //        //string pastaFotos = "C:/Users/Dev3/Documents/testeSaveImage";
        //        string pastaFotos = "http://static.scae.adm.br/images/";
        //        var nomeUnicoArquivo = Guid.NewGuid().ToString() + "_" + file.FileName;
        //        string caminhoArquivo = Path.Combine(pastaFotos, nomeUnicoArquivo);
        //        using (var fileStream = new FileStream(caminhoArquivo, FileMode.Create))
        //        {
        //           await file.CopyToAsync(fileStream);
        //        }
        //    }
        //    return Ok();
        //}

    }
}
