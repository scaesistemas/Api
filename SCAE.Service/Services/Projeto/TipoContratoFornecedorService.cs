using SCAE.Data.Interface.Projeto;
using SCAE.Domain.Entities.Projeto;
using SCAE.Service.Interfaces.Projeto;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Projeto
{
    public class TipoContratoFornecedorService: QueryService<TipoContratoFornecedor, ITipoContratoFornecedorRepository>, ITipoContratoFornecedorService
    {
        public TipoContratoFornecedorService(ITipoContratoFornecedorRepository repository) : base(repository)
        {

        }
    }
}
