using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Core.Extensions;
using Tabloid.Domain.Entities;

namespace Tabloid.Infrastructure
{
    public class UnitOfWork<TId> : IUnitOfWork<TId>
    {
        private readonly TabDbContext _context;
        private readonly ICollection<object> _repositories;

        public UnitOfWork(TabDbContext context)
        {
            _context = context;
            _repositories = new List<object>();
            GenerateRepositories();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            foreach (var repository in _repositories)
            {
                if (repository is TRepository result)
                {
                    return result;
                }
            }

            throw new NotSupportedException("Specified repository could not be found");
        }

        private void GenerateRepositories()
        {
            var it = typeof(IRepository<IEntity<TId>, TId>);
            var types = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(x => x.FullName.Contains("Tabloid"))
                .SelectMany(x => x.GetLoadableTypes())
                .Where(x => x.IsClass && !x.IsAbstract && x.GetInterfaces().Select(x => x.Name).Where(x => x == it.Name).Any())
                .ToList();

            foreach (var type in types)
            {
                _repositories.Add(Activator.CreateInstance(type, _context));
            }
        }
    }
}
