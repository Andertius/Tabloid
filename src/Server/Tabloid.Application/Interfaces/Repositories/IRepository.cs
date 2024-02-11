using System.Collections.Generic;
using System.Threading.Tasks;

using Tabloid.Domain.Entities;

namespace Tabloid.Application.Interfaces.Repositories;

public interface IRepository<TEntity, TId> where TEntity : class, IEntity<TId>
{
    Task<ICollection<TEntity>> GetAll();

    Task<TEntity?> FindById(TId id);

    Task Insert(TEntity entity);

    Task InsertRange(IEnumerable<TEntity> entity);

    void Update(TEntity entity);

    void Remove(TEntity? entity);

    Task<bool> Contains(TEntity? entity);

    Task<bool> HasKey(TId key);
}
