using SCAE.Data.Interface.Almoxarifado;
using SCAE.Domain.Entities.Almoxarifado;
using SCAE.Service.Interfaces.Almoxarifado;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Almoxarifado
{
    public class TipoProdutoService : QueryService<TipoProduto, ITipoProdutoRepository>, ITipoProdutoService
    {
        public TipoProdutoService(ITipoProdutoRepository repository) : base(repository)
        {
        }
    }
}
