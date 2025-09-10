using SCAE.Data.Interface.Clientes;
using SCAE.Domain.Entities.Clientes;
using SCAE.Service.Interfaces.Clientes;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Clientes
{
    public class TipoAditamentoContratoService : QueryService<TipoAditamentoContrato, ITipoAditamentoContratoRepository>, ITipoAditamentoContratoService
    {
        public TipoAditamentoContratoService(ITipoAditamentoContratoRepository repository) : base(repository)
        {

        }

    }
}
