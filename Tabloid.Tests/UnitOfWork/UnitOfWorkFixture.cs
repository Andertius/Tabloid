using System;

using Microsoft.EntityFrameworkCore;

using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Infrastructure.Context;
using Tabloid.Infrastructure.DbContextInitializers;
using Tabloid.Infrastructure.Repositories;

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

            var initializer = new DefaultDbContextInitializer();
            _context = new TabDbContext(opts, initializer);

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
