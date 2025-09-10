using SCAE.Data.Context;
using SCAE.Data.Interface.ControleAgua;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.ControleAgua;

namespace SCAE.Data.Repository.ControleAgua
{
    public class QualidadeAguaRepository : CrudRepository<ScaeApiContext, QualidadeAgua>, IQualidadeAguaRepository
    {
        public QualidadeAguaRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
