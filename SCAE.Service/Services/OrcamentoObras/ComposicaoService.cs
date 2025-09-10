using SCAE.Data.Interface.OrcamentoObras;
using SCAE.Domain.Entities.OrcamentoObras;
using SCAE.Service.Interfaces.OrcamentoObras;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.OrcamentoObras
{
    public class ComposicaoService : CrudService<Composicao, IComposicaoRepository>, IComposicaoService
    {
        public ComposicaoService(IComposicaoRepository repository) : base(repository)
        {
        }

    }

}