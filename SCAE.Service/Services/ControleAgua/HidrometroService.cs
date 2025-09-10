using SCAE.Data.Interface.ControleAgua;
using SCAE.Domain.Entities.ControleAgua;
using SCAE.Service.Interfaces.ControleAgua;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.ControleAgua
{
    public class HidrometroService : CrudService<Hidrometro, IHidrometroRepository>, IHidrometroService
    {
        public HidrometroService(IHidrometroRepository repository) : base(repository)
        {
        }
    }
}
