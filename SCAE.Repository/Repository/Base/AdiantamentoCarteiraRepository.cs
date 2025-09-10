using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Base;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Base;
using SCAE.Domain.Entities.Empreendimento;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Base
{
    public class AdiantamentoCarteiraRepository : CrudRepository<ScaeBaseContext, AdiantamentoCarteira>, IAdiantamentoCarteiraRepository
    {
        public AdiantamentoCarteiraRepository(ScaeBaseContext context) : base(context)
        {

        }

        public IQueryable<ContratoAdiantamento> SetIncludeContrato(IQueryable<ContratoAdiantamento> query, string include)
        {
            if (string.IsNullOrEmpty(include))
                return query;

            var includes = include.Split(",");

            foreach (var item in includes)
                query = query.Include(item.Trim());

            return query;
        }

        public async Task<ContratoAdiantamento> GetContrato(int contratoId, string include = "")
        {
            var query = SetIncludeContrato(_context.Set<ContratoAdiantamento>(), include);

            return await query.AsNoTracking().FirstOrDefaultAsync(x => x.Id == contratoId);
        }

        public async Task RemoveContrato(int contratoId)
        {
            var entity = await GetContrato(contratoId);

            if (entity == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            _context.Remove(entity);
        }

        public void InsertSplit(SplitPagamentoBase split)
        {
            _context.Add(split);
        }

        public void UpdateSplit(SplitPagamentoBase split)
        {
            _context.Update(split);
        }
        public async Task RemoveSplit(int id)
        {
            var entity = await GetSplitByIdAsync(id);

            if (entity == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            _context.Remove(entity);
        }

        public async Task RemoveContratoAdiantamento(int id)
        {
            var entity = await GetContratoByIdAsync(id);

            if (entity == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            _context.Remove(entity);
        }

        public async Task<SplitPagamentoBase> GetSplitByIdAsync(int id)
        {
            IQueryable<SplitPagamentoBase> _queryParcela = _context.Set<SplitPagamentoBase>();                

            return await _queryParcela.AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }
        public async Task<ContratoAdiantamento> GetContratoByIdAsync(int id)
        {
            IQueryable<ContratoAdiantamento> _queryParcela = _context.Set<ContratoAdiantamento>();

            return await _queryParcela.AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

    }
}
