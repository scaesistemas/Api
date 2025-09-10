using SCAE.Data.Interface.Projeto;
using SCAE.Domain.Entities.Projeto;
using SCAE.Service.Interfaces.Projeto;
using SCAE.Service.Services.Shared;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Projeto
{
    public class ContratoFornecedorService: CrudService<ContratoFornecedor, IContratoFornecedorRepository>, IContratoFornecedorService
    {
        public ContratoFornecedorService(IContratoFornecedorRepository repository) : base(repository)
        {
        }

        public override async Task Post(ContratoFornecedor contrato)
        {
            contrato.Numero = _repository.ProximoNumero();
            await base.Post(contrato);
        }

       
    }
}

