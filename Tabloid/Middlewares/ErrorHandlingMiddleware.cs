using System;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;

namespace Tabloid.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        await context.Response.WriteAsync(
            JsonConvert.SerializeObject(new
            {
                context.Response.StatusCode,
                exception.Message
            }));
    }
}
