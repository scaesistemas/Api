using SCAE.Data.Interface.OrcamentoObras;
using SCAE.Domain.Entities.OrcamentoObras;
using SCAE.Service.Interfaces.OrcamentoObras;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.OrcamentoObras
{
    public class OrigemDadosService : QueryService<OrigemDados, IOrigemDadosRepository>, IOrigemDadosService
    {
        public OrigemDadosService(IOrigemDadosRepository repository) : base(repository)
        {
        }
    }
}
