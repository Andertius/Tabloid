using Newtonsoft.Json;

namespace Tabloid.ServiceConfigurations
{
    public static class ControllerConfigurations
    {
        public static void AddCustomControllers(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }
    }
}
