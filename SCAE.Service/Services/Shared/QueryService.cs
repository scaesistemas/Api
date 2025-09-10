using SCAE.Data.Context;
using SCAE.Data.Interface.Shared;
using SCAE.Domain.Interfaces.Shared;
using SCAE.Domain.Models.Shared;
using SCAE.Service.Interfaces.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Shared
{
    public class QueryService<TEntity, TQueryRepository> : IQueryService<TEntity> where TEntity : class, IEntity where TQueryRepository : IQueryRepository<TEntity>
    {
        protected readonly TQueryRepository _repository;

        public SessionAppModel SessionApp { get; }

        public QueryService(TQueryRepository repository)
        {
            _repository = repository;
            SessionApp = repository.SessionApp;
        }

        public virtual async Task<TEntity> Get(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<TEntity> Get(int id, string include)
        {
            return await _repository.GetByIdAsync(id, include);
        }

        public virtual async Task<TEntity> GetTracking(int id)
        {
            return await _repository.GetByIdTrackingAsync(id);
        }

        public virtual async Task<TEntity> GetTracking(int id, string include)
        {
            return await _repository.GetByIdTrackingAsync(id, include);
        }

        public IQueryable<TEntity> Get(string include = "")
        {
            return _repository.GetAll(include);
        }

        public IQueryable<TEntity> GetNoInclude()
        {
            return _repository.GetAllNoInclude();
        }

        public async Task<TEntity> GetNoInclude(int id)
        {
            return await _repository.GetByIdNoIncludeAsync(id);
        }

        public async Task<TEntity> GetTrackingNoFilter(int id)
        {
            return await _repository.GetByIdTrackingNoFilterAsync(id);
        }

        public IQueryable<TEntity> GetAllNoTracking(string include = "")
        {
            return _repository.GetAllNoTracking(include);
        }

        public void ChangeContext(ScaeApiContext context)
        {
            _repository.ChangeContext(context);
        }

        public void ChangeBaseContext(ScaeBaseContext context)
        {
            _repository.ChangeBaseContext(context);
        }
        public ScaeApiContext GetContext()
        {
            return _repository.GetContext();
        }
        
        public ScaeBaseContext GetBaseContext()
        {
            return _repository.GetBaseContext();
        }
    }
}
