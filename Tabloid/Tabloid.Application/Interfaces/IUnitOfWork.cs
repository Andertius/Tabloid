using System.Reflection;

namespace Tabloid.Application.Interfaces
{
    public interface IUnitOfWork<TId>
    {
        TRepository GetRepository<TRepository>();
        void RegisterRepositories(Assembly interfaceAssembly, Assembly implementationAssembly);

        Task Save();
    }
}
