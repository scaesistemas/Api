using SCAE.Data.Interface.ControleAgua;
using SCAE.Domain.Entities.ControleAgua;
using SCAE.Service.Interfaces.ControleAgua;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.ControleAgua
{
    public class QualidadeAguaService : CrudService<QualidadeAgua, IQualidadeAguaRepository>, IQualidadeAguaService
    {
        public QualidadeAguaService(IQualidadeAguaRepository repository) : base(repository)
        {

        }
    }
}
