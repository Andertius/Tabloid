using Microsoft.AspNetCore.Builder;

namespace Tabloid.ServiceConfigurations;

public static class CrossOriginResourceSharingConfiguration
{
    public static IApplicationBuilder UseCrossOriginResourceSharing(this IApplicationBuilder app)
    {
        return app.UseCors(x => x
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod());
    }
}
