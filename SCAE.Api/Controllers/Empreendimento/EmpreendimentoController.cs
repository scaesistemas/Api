using Microsoft.Extensions.Logging;
using SCAE.Service.Interfaces.Empreendimento;

namespace SCAE.Api.Controllers.Empreendimento
{
    public class EmpreendimentoController : MasterCrudController<Domain.Entities.Empreendimento.Empreendimento>
    {
        public EmpreendimentoController(ILogger<EmpreendimentoController> logger, IEmpreendimentoService service) : base(logger, service, "Proprietarios,Fotos, DocumentosCompartilhados, Grupos.Unidades.Lote, Documentos, Grupos.Unidades.Imovel, Grupos.Unidades.Jazigo, LadosAdicionaisPadroes,Grupos.Unidades.PlanoPagamento,PlanoPagamento, EmpreendimentosPessoas")
        {
        }
    }
}