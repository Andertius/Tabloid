using Tabloid.Application.MapProfiles;

namespace Tabloid.ServiceConfigurations
{
    public static class MapperConfigurations
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            return services.AddAutoMapper(typeof(TuningProfile).Assembly);
        }
    }
}
