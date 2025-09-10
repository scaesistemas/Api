using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SCAE.Data.Interface.Shared;
using SCAE.Domain.Interfaces.Shared;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Shared;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Shared
{
    public class CrudService<TEntity, TCrudRepository> : QueryService<TEntity, TCrudRepository>, ICrudService<TEntity> where TEntity : class, IEntity where TCrudRepository : ICrudRepository<TEntity>
    {
        public CrudService(TCrudRepository repository) : base(repository)
        {

        }

        public IDbContextTransaction BeginTransaction()
        {
            return _repository.BeginTransaction();
        }

        public async virtual Task Delete(int id)
        {
            await _repository.Remove(id);

            await SaveChangesAsync();
        }

        public async virtual Task Delete(TEntity entity)
        {
            _repository.Remove(entity);

            await SaveChangesAsync();
        }

        public async virtual Task Post(TEntity entity, bool saveChanges = true)
        {
            await _repository.Insert(entity);

            if (saveChanges)
                await _repository.SaveChangesAsync();
        }

        public async virtual Task Post(TEntity entity)
        {
            await Post(entity, true);
        }

        public async virtual Task Put(TEntity entity)
        {
            _repository.Update(entity);

            await SaveChangesAsync();
        }

        public async virtual Task Patch(int id, JsonPatchDocument<TEntity> model, string include)
        {
            var domain = string.IsNullOrEmpty(include) ? await GetTracking(id) : await GetTracking(id, include);

            if (domain == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            model.ApplyTo(domain);

            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }

        public void Modified(TEntity entity)
        {
            _repository.Modified(entity);
        }
    }
}
