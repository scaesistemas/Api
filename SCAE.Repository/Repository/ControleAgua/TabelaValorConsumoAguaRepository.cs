using SCAE.Data.Context;
using SCAE.Data.Interface.ControleAgua;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.ControleAgua;

namespace SCAE.Data.Repository.ControleAgua
{
    public class TabelaValorConsumoAguaRepository : CrudRepository<ScaeApiContext, TabelaValorConsumoAgua>, ITabelaValorConsumoAguaRepository
    {
        public TabelaValorConsumoAguaRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
