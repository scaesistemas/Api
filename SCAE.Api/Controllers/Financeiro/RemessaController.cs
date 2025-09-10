using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCAE.Api.Attributes;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Boleto;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Services.Financeiro;
using System;
using System.Threading.Tasks;

namespace SCAE.Api.Controllers.Financeiro
{
    public class RemessaController : MasterCrudController<Remessa>
    {
        public readonly IRemessaService _service;
        public RemessaController(ILogger<RemessaController> logger, IRemessaService service) : base(logger, service, "Transacoes")
        {
            _service = service;
        }

        [HttpPut("{id}/Processar/{enumTipoArquivo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ArquivoRemessaDocumento>> Processar(int id, EnumTipoArquivo enumTipoArquivo)
        {
            try
            {

                //enumTipoArquivo = EnumTipoArquivo.CNAB240; 

                var arquivoRemessa = await _service.Processar(id,enumTipoArquivo);
                return Ok(arquivoRemessa);
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
                    $"{e.Message} - {e.InnerException?.Message}");
            }
        }

        [HttpPost("SalvarProcessar/{enumTipoArquivo}")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ArquivoRemessaDocumento>> SalvarEProcessar([FromBody] Remessa remessa, EnumTipoArquivo enumTipoArquivo)
        {
            try
            {
                //enumTipoArquivo = EnumTipoArquivo.CNAB240;

                var arquivoRemessa = await _service.SalvarEProcessar(remessa, enumTipoArquivo);
                return Ok(arquivoRemessa);
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
                    $"{e.Message} - {e.InnerException?.Message}");
            }
        }

    }
}
