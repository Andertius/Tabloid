using System.Reflection;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace Tabloid.ServiceConfigurations
{
    public static class MediatrConfiguration
    {
        public static IServiceCollection AddMediatr(this IServiceCollection services)
        {
            return services.AddMediatR(Assembly.Load("Tabloid.Application"));
        }
    }
}
