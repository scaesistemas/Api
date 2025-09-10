using SCAE.Data.Interface.Clientes;
using SCAE.Domain.Entities.Clientes;
using SCAE.Service.Interfaces.Clientes;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Clientes
{
    public class TipoOperacaoContratoService : QueryService<TipoOperacaoContrato, ITipoOperacaoContratoRepository>, ITipoOperacaoContratoService
    {
        public TipoOperacaoContratoService(ITipoOperacaoContratoRepository repository) : base(repository)
        {

        }
    }
}
