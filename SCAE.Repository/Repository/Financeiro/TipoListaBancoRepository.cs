using SCAE.Data.Context;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Repository.Interface.Financeiro;

namespace SCAE.Repository.Repository.Financeiro
{
    public class TipoListaBancoRepository : QueryRepository<ScaeApiContext, TipoListaBanco>, ITipoListaBancoRepository
    {
        public TipoListaBancoRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}