using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.Entities;

namespace Tabloid.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<TRepository> GetRepository<TRepository>() where TRepository : IRepository<IEntity<Guid>>;

        Task Save();
    }
}
