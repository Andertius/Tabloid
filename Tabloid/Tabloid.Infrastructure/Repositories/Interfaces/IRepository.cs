using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query;

using Tabloid.Domain.Entities;

namespace Tabloid.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        Task<ICollection<TEntity>> GetAll(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        Task<TEntity> FindById(TId id);

        Task Insert(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        Task<bool> Contains(TEntity entity);
    }
}
