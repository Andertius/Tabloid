using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;

namespace Tabloid.ServiceConfigurations
{
    public static class ControllerConfiguration
    {
        public static void AddCustomControllers(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.MaxDepth = null;
                });
        }
    }
}
