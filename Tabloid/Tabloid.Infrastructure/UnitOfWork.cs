﻿using Tabloid.Domain.Interfaces;
using Tabloid.Core.Extensions;
using Tabloid.Domain.Entities;
using System.Reflection;
using Tabloid.Infrastructure.Repositories;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Infrastructure
{
    public class UnitOfWork<TId> : IUnitOfWork<TId>
    {
        private readonly TabDbContext _context;
        private IDictionary<Type, Type> _repositories;

        public UnitOfWork(TabDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, Type>();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public TRepository GetRepository<TRepository>()
        {
            var interfaceType = typeof(TRepository);

            if (_repositories.ContainsKey(interfaceType))
            {
                return (TRepository)Activator.CreateInstance(_repositories[interfaceType], _context);
            }

            throw new NotSupportedException("Specified repository could not be found");
        }

        public void RegisterRepositories(Assembly interfaceAssembly, Assembly implementationAssembly)
        {
            _repositories = CreateRepositoryDictionary(
                GetInterfaces(interfaceAssembly),
                GetImplementations(implementationAssembly));
        }

        private static IList<Type> GetInterfaces(Assembly assembly)
        {
            var it = typeof(IRepository<IEntity<TId>, TId>);
            var types = assembly
                .GetLoadableTypes()
                .Where(x => x.IsInterface && x.GetInterfaces()
                    .Select(x => x.Name)
                    .Where(x => x == it.Name)
                    .Any())
                .OrderBy(x => x.Name)
                .ToList();

            return types;
        }

        private static IList<Type> GetImplementations(Assembly assembly)
        {
            var baseClass = typeof(Repository<IEntity<TId>, TId>);
            var types = assembly
                .GetLoadableTypes()
                .Where(x => x.IsClass && !x.IsAbstract && x.BaseType.Name == baseClass.Name)
                .OrderBy(x => x.Name)
                .ToList();

            return types;
        }

        private static IDictionary<Type, Type> CreateRepositoryDictionary(IList<Type> interfaces, IList<Type> implementations)
        {
            if (interfaces.Count != implementations.Count)
            {
                throw new ArgumentException("Number of items in both lists must be the same.");
            }
            else if (interfaces.Any(x => !x.IsInterface))
            {
                throw new ArgumentException("Every item in 'interfaces' must be an interface", nameof(interfaces));
            }
            else if (!CheckPairings(interfaces, implementations))
            {
                throw new ArgumentException("Every item in 'implementations' must implement " +
                    "the corresponding item in 'interfaces'.", nameof(implementations));
            }

            return interfaces
                .Zip(implementations, (it, im) => new { it, im })
                .ToDictionary(item => item.it, item => item.im);
        }

        private static bool CheckPairings(IList<Type> interfaces, IList<Type> implementations)
        {
            for (int i = 0; i < implementations.Count; i++)
            {
                if (!implementations[i].GetInterfaces().Contains(interfaces[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
