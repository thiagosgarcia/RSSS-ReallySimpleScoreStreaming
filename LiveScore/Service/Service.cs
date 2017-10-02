using System.Linq;
using System.Threading.Tasks;
using BasicInfrastructure.Persistence;
using BasicInfrastructure.Service;

namespace LiveScoresCore.Service
{
    public class Service<T> : IService<T> 
        where T : Entity
    {
        protected IRepository<T> Repository;

        public Service(IRepository<T> repository)
        {
            Repository = repository;
        }

        public virtual async Task<IQueryable<T>> GetAll()
        {
            return await Repository.GetAll();
        }

        public virtual async Task<T> Get(int id)
        {
            return await Repository.Get(id);
        }

        public virtual async Task<T> Add(T entity)
        {
            OnBeforeAdd(entity);
            entity = await Repository.Add(entity);
            OnAfterAdd(entity);
            var r = entity;
            return r;
        }

        public virtual async Task<T> Update(T entity, int? id = null )
        {
            if (id.HasValue)
                entity.Id = id.Value;

            OnBeforeUpdate(entity);
            entity = await Repository.Update(entity);
            OnAfterUpdate(entity);
            var r = entity;
            return r;
        }

        public virtual async Task<bool> Delete(T entity)
        {
            OnBeforeDelete(entity);
            var r = await Repository.Delete(entity);
            OnAfterDelete(entity);
            return r;
        }

        public virtual async Task<bool> Delete(int id)
        {
            return await Repository.Delete(id);
        }

        protected virtual void OnBeforeAdd(T entity)
        {
            BeforeAdd?.Invoke(entity);
        }

        protected virtual void OnAfterAdd(T entity)
        {
            AfterAdd?.Invoke(entity);
        }

        protected virtual void OnBeforeUpdate(T entity)
        {
            BeforeUpdate?.Invoke(entity);
        }

        protected virtual void OnAfterUpdate(T entity)
        {
            AfterUpdate?.Invoke(entity);
        }

        protected virtual void OnBeforeDelete(T entity)
        {
            BeforeDelete?.Invoke(entity);
        }

        protected virtual void OnAfterDelete(T entity)
        {
            AfterDelete?.Invoke(entity);
        }

        protected event AfterHandler AfterAdd;
        protected event AfterHandler AfterDelete;
        protected event AfterHandler AfterUpdate;
        protected event BeforeHandler BeforeAdd;
        protected event BeforeHandler BeforeDelete;
        protected event BeforeHandler BeforeUpdate;
        protected delegate Task AfterHandler(T entity);
        protected delegate Task BeforeHandler(T entity);
    }
}