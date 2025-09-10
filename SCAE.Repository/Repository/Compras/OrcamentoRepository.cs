using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Compras;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Compras;

namespace SCAE.Data.Repository.Compras
{
    public class OrcamentoRepository : CrudRepository<ScaeApiContext, Orcamento>, IOrcamentoRepository
    {
        public OrcamentoRepository(ScaeApiContext context) : base(context)
        {
            //_query = _query
            //    //.Include(x => x.CentroCusto)
            //    //.Include(x => x.ContaGerencial)
            //    .Include(x => x.Classificacao)
            //    .Include(x => x.Situacao)
            //    .Include(x => x.Itens)
            //        .ThenInclude(x => x.Produto)
            //    .Include(x => x.Itens)
            //        .ThenInclude(x => x.ItemFornecedores)
            //    .Include(x => x.Fornecedores)
            //        .ThenInclude(x => x.Fornecedor)
            //    .Include(x => x.Fornecedores)
            //        .ThenInclude(x => x.FormaPagamento)
            //    .Include(x => x.Documentos);
        }
    }
}
