using System.Reflection;

using MediatR;

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
