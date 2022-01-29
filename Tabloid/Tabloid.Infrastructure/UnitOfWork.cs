using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.Entities;

namespace Tabloid.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public Task<TRepository> GetRepository<TRepository>() where TRepository : IRepository<IEntity<Guid>>
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}
