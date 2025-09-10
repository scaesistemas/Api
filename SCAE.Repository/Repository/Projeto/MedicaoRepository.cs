using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Projeto;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Projeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Projeto
{
    public class MedicaoRepository : CrudRepository<ScaeApiContext, Medicao>, IMedicaoRepository
    {
        public MedicaoRepository(ScaeApiContext context) : base(context)
        {
            //_query = _query.Include(x => x.Execucoes)
            //            .ThenInclude(x => x.ContratoItem)
            //          .Include(x => x.Despesa)
            //            .ThenInclude(x => x.Parcelas);

        }

        public async Task<List<Execucao>> GetExecucoesRelatorio(int? empreendimentoId, DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal, DateTime? dataVencimentoInicial, DateTime? dataVencimentoFinal,
            DateTime? dataBaixaInicial, DateTime? dataBaixaFinal)
        {

            var query = _context.Execucoes.AsNoTracking()
                .Include("ContratoItem")
                .Include("Medicao.Despesa")
                .Include("Medicao.ContratoFornecedor");

            if (empreendimentoId.HasValue)
              query = query.Where(x => x.Medicao.Despesa != null && x.Medicao.ContratoFornecedor.EmpreendimentoId == empreendimentoId);

            if (dataEmissaoInicial.HasValue)
                query = query.Where(x => x.Data.Date >= dataEmissaoInicial.Value.Date);

            if (dataEmissaoFinal.HasValue)
                query = query.Where(x => x.Data.Date <= dataEmissaoFinal.Value.Date);

            if (dataVencimentoInicial.HasValue)
                query = query.Where(x => x.Data.Date >= dataVencimentoInicial.Value.Date);

            if (dataVencimentoFinal.HasValue)
                query = query.Where(x => x.Data.Date <= dataVencimentoFinal.Value.Date);

            if (dataBaixaInicial.HasValue)
                query = query.Where(x => x.Data.Date >= dataBaixaInicial.Value.Date);

            if (dataBaixaFinal.HasValue)
                query = query.Where(x => x.Data.Date <= dataBaixaFinal.Value.Date);

            return await query.ToListAsync();
        }

    }
}
