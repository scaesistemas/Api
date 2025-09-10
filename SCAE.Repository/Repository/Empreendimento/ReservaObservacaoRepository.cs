using SCAE.Data.Context;
using SCAE.Data.Interface.Empreendimento;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Empreendimento;

namespace SCAE.Data.Repository.Empreendimento
{
    public class ReservaObservacaoRepository : CrudRepository<ScaeApiContext, ReservaObservacao>, IReservaObservacaoRepository
    {
        public ReservaObservacaoRepository(ScaeApiContext context) : base(context) { }
    }
}
