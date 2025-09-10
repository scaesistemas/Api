using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SCAE.Data.Interface.Shared;
using SCAE.Domain.Interfaces.Shared;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Shared
{
    public class CrudRepository<TContext, TEntity> : QueryRepository<TContext, TEntity>, ICrudRepository<TEntity> where TContext : DbContext where TEntity : class, IEntity
    {
        public CrudRepository(TContext context) : base(context)
        {

        }
        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public async Task Insert(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task Remove(int id)
        {
            var entity = await GetByIdNoIncludeAsync(id);

            if (entity == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            _context.Remove(entity);
        }

        public void Remove(TEntity entity)
        {
            _context.Remove(entity);
        }

        public void Detached(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        public void Modified(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task SaveChangesAsync()
        {

            await _context.SaveChangesAsync();
        }

        public virtual void Update(TEntity entity)
        {
            _context.Update(entity);
        }
    }
}
