using SCAE.Data.Context;
using SCAE.Data.Interface.ControleAgua;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.ControleAgua;

namespace SCAE.Data.Repository.ControleAgua
{
    public class MarcacaoAguaRepository : CrudRepository<ScaeApiContext, MarcacaoAgua>, IMarcacaoAguaRepository
    {
        public MarcacaoAguaRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
