using SCAE.Data.Interface.Almoxarifado;
using SCAE.Domain.Entities.Almoxarifado;
using SCAE.Service.Interfaces.Almoxarifado;
using SCAE.Service.Services.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Almoxarifado
{
    public class ProdutoService : CrudService<Produto, IProdutoRepository>, IProdutoService
    {
        public ProdutoService(IProdutoRepository repository) : base(repository)
        {

        }
    }
}
