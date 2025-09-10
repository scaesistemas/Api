using SCAE.Data.Interface.ControleAgua;
using SCAE.Domain.Entities.ControleAgua;
using SCAE.Service.Interfaces.ControleAgua;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.ControleAgua
{
    public class MarcacaoAguaService : CrudService<MarcacaoAgua, IMarcacaoAguaRepository>, IMarcacaoAguaService
    {
        public MarcacaoAguaService(IMarcacaoAguaRepository repository) : base(repository)
        {

        }
    }
}
