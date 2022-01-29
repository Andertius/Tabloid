using Microsoft.EntityFrameworkCore;

using Tabloid.Infrastructure;
using Tabloid.Middlewares;
using Tabloid.ServiceConfigurations;

namespace Tabloid
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TabDbContext>(opts => {
                opts.UseSqlServer(
                    Configuration["ConnectionStrings:DatabaseConnection"]);
            });

            services
                .AddRepositories()
                .AddValidation()
                .AddMediatr()
                .AddUnitOfWork();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCrossOriginResourceSharing();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
