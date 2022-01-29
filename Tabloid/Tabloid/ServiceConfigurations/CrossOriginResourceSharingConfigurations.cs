namespace Tabloid.ServiceConfigurations
{
    public static class CrossOriginResourceSharingConfigurations
    {
        public static IApplicationBuilder UseCrossOriginResourceSharing(this IApplicationBuilder app)
        {
            return app.UseCors(x => x
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod());
        }
    }
}
