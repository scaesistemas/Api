using SCAE.Data.Interface.Financeiro.PlanoDePagamento;
using SCAE.Domain.Entities.Financeiro.PlanoDePagamento;
using SCAE.Service.Interfaces.Empreendimento;
using SCAE.Service.Interfaces.Financeiro.PlanoDePagamento;
using SCAE.Service.Services.Shared;


namespace SCAE.Service.Services.Financeiro.PlanoDePagamento
{
    public class PlanoPagamentoService : CrudService<PlanoPagamentoModelo, IPlanoPagamentoRepository>, IPlanoPagamentoService
    {
        private readonly IEmpreendimentoService _empreendimentoService;
        public PlanoPagamentoService(IPlanoPagamentoRepository repository,IEmpreendimentoService empreendimentoService) : base(repository)
        {
            _empreendimentoService = empreendimentoService;
        }
    }
}

