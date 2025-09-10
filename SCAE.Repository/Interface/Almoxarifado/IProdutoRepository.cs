using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Almoxarifado;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.Almoxarifado
{
    public interface IProdutoRepository : ICrudRepository<Produto>
    {
        Task<List<Produto>> AutoComplete(string q);
        Task<Produto> GetByCodigoFornecedor(int fornecedorId, string codigo);
        Task<Produto> GetPrimeiraSugestao(string nomeCodigo);
        void UpdateList(List<Produto> list);
    }
}
