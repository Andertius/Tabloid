using System.Linq.Expressions;

using Tabloid.Domain.Entities;

namespace Tabloid.Application.Interfaces.Repositories
{
    public interface IRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        Task<IList<TEntity>> GetAll(Expression filter = null, IQueryable include = null);

        Task<TEntity> FindById(TId id);

        Task Insert(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }
}
