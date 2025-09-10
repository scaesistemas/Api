using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Interface.Projeto;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;

namespace SCAE.Data.Repository.Financeiro
{
    public class BancoRepository : CrudRepository<ScaeApiContext, Banco>, IBancoRepository
    {
        public BancoRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
