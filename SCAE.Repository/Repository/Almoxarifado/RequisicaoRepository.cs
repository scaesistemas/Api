using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Almoxarifado;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Almoxarifado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Almoxarifado
{
    public class RequisicaoRepository : CrudRepository<ScaeApiContext, Requisicao>, IRequisicaoRepository
    {
        public RequisicaoRepository(ScaeApiContext context) : base(context)
        {

        }

        private IQueryable<RequisicaoItem> SetInclude(IQueryable<RequisicaoItem> query, string include)
        {
            if (string.IsNullOrEmpty(include))
                return query;

            var includes = include.Split(",");

            foreach (var item in includes)
                query = query.Include(item.Trim());

            return query;
        }

        public IQueryable<RequisicaoItem> ObterItens(string include = "")
        {
            var queryItens = _context.Set<RequisicaoItem>();

            if (string.IsNullOrEmpty(include))
                return queryItens;

            return SetInclude(queryItens, include);
        }

        public async Task<List<Requisicao>> ObterRequisicoesExecutadas(int? empreendimentoId, DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal, DateTime? dataVencimentoInicial, DateTime? dataVencimentoFinal,
            DateTime? dataBaixaInicial, DateTime? dataBaixaFinal,string include = "")
        {
            var queryItens = _context.Requisicoes
                    .AsNoTracking()
                    .Include(include)
                    .Where(x => x.DataHoraExecucao != null);


            if (empreendimentoId.HasValue)
                queryItens = queryItens.Where(x => x.EmpreendimentoId == empreendimentoId);

            if (dataEmissaoInicial.HasValue)
                queryItens = queryItens.Where(x => x.DataHoraExecucao >= dataEmissaoInicial);

            if (dataEmissaoFinal.HasValue)
                queryItens = queryItens.Where(x => x.DataHoraExecucao <= dataEmissaoFinal);

            if (dataVencimentoInicial.HasValue)
                queryItens = queryItens.Where(x => x.DataHoraExecucao >= dataVencimentoInicial);

            if (dataVencimentoFinal.HasValue)
                queryItens = queryItens.Where(x => x.DataHoraExecucao <= dataVencimentoFinal);

            if (dataBaixaInicial.HasValue)
                queryItens = queryItens.Where(x => x.DataHoraExecucao >= dataBaixaInicial);

            if (dataBaixaFinal.HasValue)
                queryItens = queryItens.Where(x => x.DataHoraExecucao <= dataBaixaFinal);


            return await queryItens.ToListAsync();
        }
    }
}
