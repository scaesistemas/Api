using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Geral
{
    public class PessoaRepository : CrudRepository<ScaeApiContext, Pessoa>, IPessoaRepository
    {
        public PessoaRepository(ScaeApiContext context) : base(context)
        {
            //_query = _query
            //    .Include(x => x.Qualificacao.Profissao)
            //    .Include(x => x.Qualificacao.Nacionalidade)
            //    .Include(x => x.Qualificacao.Naturalidade)
            //    .Include(x => x.Qualificacao.EstadoCivil)
            //    .Include(x => x.Contatos);
        }

        public async Task<List<Pessoa>> AutoComplete(string q, bool isCliente, bool isFornecedor, bool isCorretor, bool isProprietario,
            bool isSeguradora, bool isAdministradora, bool isConstrutora, bool isTransportadora)
        {
            return await (from x in
                  _context.Pessoas.AsNoTracking()
                          where
                            (x.Nome.ToUpper().Contains(q.ToUpper()) || x.CnpjCpf.Contains(q)) &&
                            (
                                x.IsCliente == isCliente || x.IsFornecedor == isFornecedor ||
                                x.IsCorretor == isCorretor || x.IsProprietario == isProprietario ||
                                x.IsSeguradora == isSeguradora || x.IsAdministradora == isAdministradora ||
                                x.IsConstrutora == isConstrutora || x.IsTransportadora == isTransportadora
                            )
                          select x
              ).ToListAsync();
        }

        public async Task<PessoaDocumento> GetDocumentoByIdAsync(int id)
        {
            return await _context.Set<PessoaDocumento>().AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<List<PessoaDocumento>> GetDocumentos(int pessoaId)
        {
            return await _context.Set<PessoaDocumento>().AsNoTracking()
                .Where(x => x.PessoaId == pessoaId)
                .Select(x => new PessoaDocumento(
                    x.Id,
                    x.PessoaId,
                    x.Nome,
                    x.Tamanho,
                    x.Tipo
                )).ToListAsync();
        }

        public async Task<Pessoa> GetByUserId(int usuarioId)
        {
            return await _context.Pessoas.SingleOrDefaultAsync(x => x.UsuarioId == usuarioId);
        }

        public async Task<Pessoa> GetByCPF(string cpf, string include = "")
        {
            string CpfCnpjlimpo = CnpjCpfHelper.LimparCpfCnpj(cpf);
            string formatadoCpfCnpj = CnpjCpfHelper.Formata(CpfCnpjlimpo);

            return await GetAll(include).SingleOrDefaultAsync(x => x.CnpjCpf == formatadoCpfCnpj);
        }

        public async Task InsertList(List<Pessoa> list)
        {
            await _context.AddRangeAsync(list);
        }

        public async Task<PessoaGateway> GetPessoaGatewayByIdAsync(int id)
        {
            IQueryable<PessoaGateway> _queryPessoaGateway = _context.Set<PessoaGateway>();

            return await _queryPessoaGateway.AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public void DetachedPessoaGateway(PessoaGateway pessoa)
        {
            _context.Entry(pessoa).State = EntityState.Detached;
        }

        public async Task RemovePessoaGateway(int id)
        {
            var entity = await GetPessoaGatewayByIdAsync(id);

            if (entity == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            _context.Remove(entity);
        }

    }
}
