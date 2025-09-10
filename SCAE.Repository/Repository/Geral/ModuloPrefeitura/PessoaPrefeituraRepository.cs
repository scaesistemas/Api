using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Geral.ModuloPrefeitura;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.Geral.ModuloPrefeitura;
using SCAE.Framework.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Geral.ModuloPrefeitura
{
    public class PessoaPrefeituraRepository : CrudRepository<ScaeApiContext, PessoaPrefeitura>, IPessoaPrefeituraRepository
    {
        public PessoaPrefeituraRepository(ScaeApiContext context) : base(context)
        {
        }

        public async Task<PessoaPrefeituraDocumento> GetDocumentoByIdAsync(int id)
        {
            return await _context.Set<PessoaPrefeituraDocumento>().AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<List<PessoaPrefeituraDocumento>> GetDocumentos(int pessoaId)
        {
            return await _context.Set<PessoaPrefeituraDocumento>().AsNoTracking()
                .Where(x => x.PessoaPrefeituraId == pessoaId)
                .Select(x => new PessoaPrefeituraDocumento(
                    x.Id,
                    x.PessoaPrefeituraId,
                    x.Nome,
                    x.Tamanho,
                    x.Tipo
                )).ToListAsync();
        }

        public async Task<PessoaPrefeitura> GetByUserId(int usuarioId)
        {
            return await _context.pessoaPrefeituras.SingleOrDefaultAsync(x => x.UsuarioId == usuarioId);
        }

        public async Task<PessoaPrefeitura> GetByCPF(string cpf, string include = "")
        {
            string CpfCnpjlimpo = CnpjCpfHelper.LimparCpfCnpj(cpf);
            string formatadoCpfCnpj = CnpjCpfHelper.Formata(CpfCnpjlimpo);

            return await GetAll(include).SingleOrDefaultAsync(x => x.CnpjCpf == formatadoCpfCnpj);
        }

        public async Task InsertList(List<PessoaPrefeitura> list)
        {
            await _context.AddRangeAsync(list);
        }
    }
}
