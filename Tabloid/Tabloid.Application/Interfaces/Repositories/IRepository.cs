using System.Linq.Expressions;

using Tabloid.Domain.Entities;

namespace Tabloid.Application.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : IEntity<Guid> 
    {
        Task<IList<TEntity>> GetAll(Expression filter = null, IQueryable include = null);

        Task<TEntity> FindById(Guid id);

        Task Insert(TEntity entity);

        void Update(TEntity entity);

        Task Delete(TEntity entity);
    }
}
