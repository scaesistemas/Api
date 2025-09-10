using Microsoft.EntityFrameworkCore.Storage;
using SCAE.Domain.Interfaces.Shared;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.Shared
{
    public interface ICrudRepository<TEntity> : IQueryRepository<TEntity> where TEntity : class, IEntity
    {
        IDbContextTransaction BeginTransaction();
        Task Insert(TEntity entity);
        void Update(TEntity entity);
        Task Remove(int id);
        void Remove(TEntity entity);
        void Detached(TEntity entity);
        void Modified(TEntity entity);
        Task SaveChangesAsync();
    }
}
