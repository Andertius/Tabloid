using System;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Tabloid.Infrastructure.Context;

namespace Tabloid
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            Migrate(host.Services);
            host.Run();
        }

        public static void Migrate(IServiceProvider serviceProvider)
            => serviceProvider
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<TabDbContext>()
                .Database
                .Migrate();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder
                        .UseStartup<Startup>()
                        .UseKestrel(options =>
                        {
                            options.Limits.MaxRequestBodySize = null;
                        }));
    }
}
