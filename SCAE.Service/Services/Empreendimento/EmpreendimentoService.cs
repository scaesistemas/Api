using SCAE.Data.Interface.Empreendimento;
using SCAE.Service.Interfaces.Empreendimento;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Empreendimento
{
    public class EmpreendimentoService : CrudService<Domain.Entities.Empreendimento.Empreendimento, IEmpreendimentoRepository>, IEmpreendimentoService
    {
        public EmpreendimentoService(IEmpreendimentoRepository repository) : base(repository)
        {
        }
    }

}
