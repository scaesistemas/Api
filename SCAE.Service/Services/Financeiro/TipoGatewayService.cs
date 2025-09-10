using SCAE.Data.Interface.Financeiro;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Financeiro
{
    public class TipoGatewayService : QueryService<TipoGateway, ITipoGatewayRepository>, ITipoGatewayService
    {
        public TipoGatewayService(ITipoGatewayRepository repository) : base(repository)
        {
        }
    }
}
