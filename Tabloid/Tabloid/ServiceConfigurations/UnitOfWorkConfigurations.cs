using Tabloid.Application.Interfaces;
using Tabloid.Infrastructure;

namespace Tabloid.ServiceConfigurations
{
    public static class UnitOfWorkConfigurations
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services.AddScoped<IUnitOfWork<Guid>, UnitOfWork<Guid>>();
        }
    }
}
