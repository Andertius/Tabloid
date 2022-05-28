using Microsoft.EntityFrameworkCore;

using Tabloid.Infrastructure.Context;
using Tabloid.Infrastructure.DbContextInitializers;

namespace Tabloid.ServiceConfigurations
{
    public static class DataAccessConfiguration
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDbContextInitializer, DefaultDbContextInitializer>();

            return services.AddDbContext<TabDbContext>(opts =>
            {
                opts.UseSqlServer(configuration.GetConnectionString("DatabaseConnection"));
            });
        }
    }
}
