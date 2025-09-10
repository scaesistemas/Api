using SCAE.Data.Interface.Financeiro;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Financeiro
{
    public class RetornoBancarioService : CrudService<RetornoBancario, IRetornoBancarioRepository>, IRetornoBancarioService
    {
        public RetornoBancarioService(IRetornoBancarioRepository repository) : base(repository)
        {
        }
    }
}
