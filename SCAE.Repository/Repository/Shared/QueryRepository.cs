using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Shared;
using SCAE.Domain.Interfaces.Shared;
using SCAE.Domain.Models.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Shared
{
    public class QueryRepository<TContext, TEntity> : BaseRepository<TContext>, IQueryRepository<TEntity> where TContext : DbContext where TEntity : class, IEntity
    {
        //protected IQueryable<TEntity> _query;

        public SessionAppModel SessionApp { get; }

        public QueryRepository(TContext context) : base(context)
        {
            //_query = _context.Set<TEntity>();

            //SessionApp = context.SessionApp;
        }
        private IQueryable<TEntity> SetInclude(IQueryable<TEntity> query, string include)
        {
            if (string.IsNullOrEmpty(include))
                return query;

            var includes = include.Split(",");

            foreach (var item in includes)
                query = query.Include(item.Trim());

            return query;
        }

        public void ChangeContext(ScaeApiContext context)
        {
            if (typeof(ScaeApiContext) != typeof(TContext))
                throw new InvalidOperationException("Não é possível mudar um o Context para um tipo diferente de ScaeApiContext");

            _context = (TContext)(object)context;
        }

        public void ChangeBaseContext(ScaeBaseContext context)
        {
            if (typeof(ScaeBaseContext) != typeof(TContext))
                throw new InvalidOperationException("Não é possível mudar um o Context para um tipo diferente de ScaeBaseContext");

            _context = (TContext)(object)context;
        }

        public ScaeApiContext GetContext()
        {
            return (ScaeApiContext)(object)_context;
        }

        public ScaeBaseContext GetBaseContext()
        {
            return (ScaeBaseContext)(object)_context;
        }

        public IQueryable<TEntity> GetAll(string include = "")
        {
            var query = SetInclude(GetAllNoInclude(), include);

            return string.IsNullOrEmpty(include) ? _context.Set<TEntity>() : query;
        }

        public IQueryable<TEntity> GetAllNoInclude()
        {
            return _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<TEntity> GetByIdAsync(int id, string include)
        {
            var query = SetInclude(GetAllNoInclude(), include);

            return await query.AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<TEntity> GetByIdNoIncludeAsync(int id)
        {
            return await _context.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<TEntity> GetByIdTrackingAsync(int id)
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<TEntity> GetByIdTrackingAsync(int id, string include)
        {
            var query = SetInclude(GetAllNoInclude(), include);

            return await query.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<TEntity> GetByIdTrackingNoFilterAsync(int id)
        {
            return await _context.Set<TEntity>().IgnoreQueryFilters().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public IQueryable<TEntity> GetAllNoTracking(string include = "")
        {
            var query = SetInclude(GetAllNoIncludeNoTracking(), include);

            return string.IsNullOrEmpty(include) ? _context.Set<TEntity>().AsNoTracking() : query;
        }

        public IQueryable<TEntity> GetAllNoIncludeNoTracking()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }

        /// <summary>
        /// Se todos os ids existirem no banco de dados, retorna true. Se não, retorna false.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<bool> ChecarIds(int[] ids)
        {
            var idsValidos = await GetAllNoTracking().Select(e => e.Id).ToListAsync();

            if (ids.Any(id => !idsValidos.Contains(id)))
                return false;
            else
                return true;
        }
    }
}
