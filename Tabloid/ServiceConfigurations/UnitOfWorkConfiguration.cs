using System;

using Microsoft.Extensions.DependencyInjection;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Infrastructure.Context;
using Tabloid.Infrastructure.Repositories;

namespace Tabloid.ServiceConfigurations
{
    public static class UnitOfWorkConfiguration
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
