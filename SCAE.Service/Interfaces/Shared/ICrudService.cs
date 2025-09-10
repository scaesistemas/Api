using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore.Storage;
using SCAE.Domain.Interfaces.Shared;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Shared
{
    public interface ICrudService<TEntity> : IQueryService<TEntity> where TEntity : class, IEntity
    {
        Task Post(TEntity entity, bool saveChanges = true);
        Task Post(TEntity entity);
        Task Put(TEntity entity);
        Task Patch(int id, JsonPatchDocument<TEntity> model, string include);
        Task Delete(int id);
        Task Delete(TEntity entity);
        Task SaveChangesAsync();
        void Modified(TEntity entity);
        IDbContextTransaction BeginTransaction();
    }
}
