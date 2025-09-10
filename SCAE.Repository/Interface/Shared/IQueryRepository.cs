using SCAE.Data.Context;
using SCAE.Domain.Interfaces.Shared;
using SCAE.Domain.Models.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.Shared
{
    public interface IQueryRepository<TEntity> where TEntity : class, IEntity
    {
        void ChangeContext(ScaeApiContext context);
        void ChangeBaseContext(ScaeBaseContext context);

        ScaeApiContext GetContext();
        ScaeBaseContext GetBaseContext();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByIdAsync(int id, string include);
        Task<TEntity> GetByIdTrackingAsync(int id);
        Task<TEntity> GetByIdTrackingAsync(int id, string include);
        Task<TEntity> GetByIdNoIncludeAsync(int id);
        Task<TEntity> GetByIdTrackingNoFilterAsync(int id);
        IQueryable<TEntity> GetAll(string include = "");
        IQueryable<TEntity> GetAllNoInclude();
        IQueryable<TEntity> GetAllNoTracking(string include = "");
        IQueryable<TEntity> GetAllNoIncludeNoTracking();
        Task<bool> ChecarIds(int[] ids);
        SessionAppModel SessionApp { get; }
    }
}
