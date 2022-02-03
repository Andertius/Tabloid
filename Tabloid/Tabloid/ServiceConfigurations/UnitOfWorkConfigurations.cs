using Tabloid.Domain.Interfaces;
using Tabloid.Infrastructure;
using Tabloid.Infrastructure.Repositories;
using Tabloid.Infrastructure.Repositories.Implementations;
using Tabloid.Infrastructure.Repositories.Interfaces;

namespace Tabloid.ServiceConfigurations
{
    public static class UnitOfWorkConfigurations
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services.AddScoped<IUnitOfWork<Guid>, UnitOfWork<Guid>>(serviceProvider =>
            {
                var context = serviceProvider.GetRequiredService<TabDbContext>();
                var unitOfWork = new UnitOfWork<Guid>(context);
                unitOfWork.RegisterRepositories(typeof(IRepository<,>).Assembly, typeof(Repository<,>).Assembly);
                return unitOfWork;
            });
        }
    }
}
