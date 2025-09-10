using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Almoxarifado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.Almoxarifado
{
    public interface IRequisicaoRepository : ICrudRepository<Requisicao>
    {
        IQueryable<RequisicaoItem> ObterItens(string include = "");
        Task<List<Requisicao>> ObterRequisicoesExecutadas(int? empreendimentoId, DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal, DateTime? dataVencimentoInicial, DateTime? dataVencimentoFinal,
            DateTime? dataBaixaInicial, DateTime? dataBaixaFinal, string include = "");
    }
}
