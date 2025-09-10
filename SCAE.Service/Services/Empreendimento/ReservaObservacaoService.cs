using SCAE.Data.Interface.Empreendimento;
using SCAE.Domain.Entities.Empreendimento;
using SCAE.Service.Interfaces.Empreendimento;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Empreendimento
{
    public class ReservaObservacaoService : CrudService<ReservaObservacao, IReservaObservacaoRepository>, IReservaObservacaoService
    {
        public ReservaObservacaoService(IReservaObservacaoRepository repository) : base(repository) { }
    }
}
