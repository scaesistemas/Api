using SCAE.Data.Context;
using SCAE.Domain.Interfaces.Shared;
using SCAE.Domain.Models.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Shared
{
    public interface IQueryService<TEntity> where TEntity : class, IEntity
    {
        void ChangeContext(ScaeApiContext context);
        void ChangeBaseContext(ScaeBaseContext context);
        ScaeApiContext GetContext();
        ScaeBaseContext GetBaseContext();
        Task<TEntity> Get(int id);
        Task<TEntity> Get(int id, string include);
        Task<TEntity> GetTracking(int id);
        Task<TEntity> GetTracking(int id, string include);
        Task<TEntity> GetTrackingNoFilter(int id);
        IQueryable<TEntity> Get(string include = "");
        IQueryable<TEntity> GetAllNoTracking(string include = "");
        IQueryable<TEntity> GetNoInclude();
        Task<TEntity> GetNoInclude(int id);
        SessionAppModel SessionApp { get; }
    }
}
