using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

namespace Tabloid.ServiceConfigurations;

public static class MediatrConfiguration
{
    public static IServiceCollection AddMediatr(this IServiceCollection services)
    {
        return services.AddMediatR(conf => conf.RegisterServicesFromAssembly(Assembly.Load("Tabloid.Application")));
    }
}
