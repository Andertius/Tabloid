using System;

using Microsoft.EntityFrameworkCore;

using Tabloid.Infrastructure;
using Tabloid.Infrastructure.Repositories.Implementations;
using Tabloid.Infrastructure.Repositories.Interfaces;

namespace Tabloid.Tests.UnitOfWork
{
    public class UnitOfWorkFixture : IDisposable
    {
        private readonly TabDbContext _context;

        public UnitOfWorkFixture()
        {
            var opts = new DbContextOptionsBuilder<TabDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new TabDbContext(opts);
            UnitOfWork = new UnitOfWork<Guid>(_context);
            UnitOfWork.RegisterRepositories(typeof(IRepository<,>).Assembly, typeof(Repository<,>).Assembly);
        }

        public UnitOfWork<Guid> UnitOfWork { get; }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
