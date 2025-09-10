using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.Extensions.Logging;
using SCAE.Domain.Interfaces.Shared;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Shared;

namespace SCAE.Api.Controllers
{
    [Authorize]
    public class MasterQueryController<TEntity> : MasterBaseController where TEntity : class, IEntity
    {
        protected readonly ILogger<MasterQueryController<TEntity>> _logger;
        private readonly IQueryService<TEntity> _service;
        
        public MasterQueryController(ILogger<MasterQueryController<TEntity>> logger, IQueryService<TEntity> service) : base()
        {
            _logger = logger;
            _service = service;

        }

        /// <response code="200"> Consulta realizada com sucesso! </response>
        /// <response code="500"> Algum erro o ocorreu! -> **Detalhamento da aplicação referente ao erro** </response>
        /// <param name="options">Opções de parâmetros de consulta, que podem ser omitidos ou combinados: 
        /// $select => Filtra as propriedades (colunas). /usuario?$select=id,nome
        /// $orderby => Ordena os resultados. (pode acompanhar desc para descrecente no final) /usuario?$orderby=nome desc
        /// $skip => Índices em um conjunto de resultados.Também usado por algumas APIs para implementar a paginação e pode ser usado com $top para paginar. /usuario?$skip=2
        /// $top => Define o tamanho de página de resultados. /usuario?$top=25
        /// $filter => Filtra os resultados(linhas). /usuario?filter=nome eq 'admin'
        /// Operadores Lógicos => igual a (eq) | não é igual a(ne) | maior que(gt) | maior ou igual a(ge) | menor que(lt), menor ou igual a(le) | e(and) | ou(or) | não(not) | contains(campo, 'valor')
        /// </param>
        /// <param name="include">Recupera os recursos relacionados. *Quando necessário, esse parametro deve ser informado no cabeçalho</param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "admin")]

        public virtual ActionResult<PageResult<TEntity>> Get(ODataQueryOptions<TEntity> options, [FromHeader] string include)
        {
            try
            {
                var pageResult = GetPageResult(_service.GetAllNoTracking(include), options);

                return Ok(pageResult);
            }
            catch (Exception e)
            {
                _logger.LogError("{0} - {1}", e.Message, e.InnerException?.Message);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }

        /// <response code="200"> Consulta realizada com sucesso! </response>
        /// <response code="404">Registro não encontrado!</response>
        /// <response code="500"> Algum erro o ocorreu! -> **Detalhamento da aplicação referente ao erro** </response>
        /// <param name="id"> Id do objeto que deseja buscar. </param>
        /// <param name="include">Recupera os recursos relacionados. *Quando necessário, esse parametro deve ser informado no cabeçalho</param>
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public virtual async Task<ActionResult<TEntity>> GetById(int id, [FromHeader] string include)
        {
            try
            {
                var domain = await _service.Get(id, include);

                if (domain == null)
                    return NotFound(MensagemHelper.RegistroNaoEncontrato);

                return Ok(domain);
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
}