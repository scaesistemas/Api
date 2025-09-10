using SCAE.Data.Interface.Financeiro;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Financeiro
{
    public class FormaPagamentoService : CrudService<FormaPagamento, IFormaPagamentoRepository>, IFormaPagamentoService
    {
        public FormaPagamentoService(IFormaPagamentoRepository repository) : base(repository)
        {

        }
    }
}
