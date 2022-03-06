using Microsoft.EntityFrameworkCore;

using Tabloid.Infrastructure;

namespace Tabloid.ServiceConfigurations
{
    public static class DbContextConfigurations
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<TabDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("DatabaseConnection")));
        }
    }
}
