using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;

namespace SCAE.Data.Repository.Financeiro
{
    public class ContaCorrenteRepository : CrudRepository<ScaeApiContext, ContaCorrente>, IContaCorrenteRepository
    {
        public ContaCorrenteRepository(ScaeApiContext context) : base(context)
        {
            //_query = _query
            //    .Include(x => x.Empresa)
            //    .Include(x => x.Banco);
        }
    }
}
