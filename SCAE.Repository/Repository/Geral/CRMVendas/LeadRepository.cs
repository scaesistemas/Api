using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Geral.CRMVendas;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral.CRMVendas;
using SCAE.Framework.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Geral.CRMVendas
{
    public class LeadRepository : CrudRepository<ScaeApiContext, Lead>, ILeadRepository
    {
        public LeadRepository(ScaeApiContext context) : base(context)
        {

        }


        public int ProximaPosicao(int colunaFunilId = -1)
        {
            return _context.Leads.AsNoTracking().Where(x => x.ColunaFunilId == colunaFunilId)
                .OrderByDescending(x => x.PosicaoFunil).Take(1)
                .SingleOrDefault()?.PosicaoFunil + 1 ?? 1;
        }

        public async Task<LeadDocumento> GetDocumentoByIdAsync(int id)
        {
            return await _context.Set<LeadDocumento>().AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<List<LeadDocumento>> GetDocumentos(int leadId)
        {
            return await _context.Set<LeadDocumento>().AsNoTracking()
                .Where(x => x.LeadId == leadId)
                .Select(x => new LeadDocumento(
                    x.Id,
                    x.LeadId,
                    x.Nome,
                    x.Tamanho,
                    x.Tipo
                )).ToListAsync();
        }

        public async Task InsertList(List<Lead> list)
        {
            await _context.AddRangeAsync(list);
        }

        public async Task<Lead> GetByCPF(string cpf, string include = "")
        {
            string CpfCnpjlimpo = CnpjCpfHelper.LimparCpfCnpj(cpf);
            string formatadoCpfCnpj = CnpjCpfHelper.Formata(CpfCnpjlimpo);

            return await GetAll(include).SingleOrDefaultAsync(x => x.Cpf == formatadoCpfCnpj);
        }
    }
}
