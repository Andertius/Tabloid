using Microsoft.AspNetCore.Mvc;

using Tabloid.Application.Commands;
using Tabloid.Domain.Enums;
using Tabloid.Domain.Responses.HttpResponses;

namespace Tabloid.Helpers
{
    public static class ReturnResultHelper
    {
        public static IActionResult ReturnCommandResult<T>(CommandResponse<T> response) where T : class
        {
            return response.Result switch
            {
                CommandResult.Success => new OkObjectResult(new OkHttpResponse<CommandResponse<T>>(response)),
                CommandResult.Failure => new BadRequestObjectResult(
                    new BadRequestHttpResponse<CommandResponse<T>>(
                        response,
                        response.ErrorMessage)),
                _ => throw new NotSupportedException(),
            };
        }

        public static IActionResult ReturnQueryResult<T>(T response)
        {
            return response switch
            {
                null => new OkObjectResult(new OkHttpResponse<T>(response)),
                _ => new BadRequestObjectResult(
                    new BadRequestHttpResponse<T>(
                        response,
                        "Object could not be found")),
            };
        }

        public static IActionResult ReturnQueryResult<T>(T[] response)
        {
            return response.Length switch
            {
                0 => new BadRequestObjectResult(
                    new BadRequestHttpResponse<T[]>(
                        response,
                        "Objects could not be found")),
                _ => new OkObjectResult(new OkHttpResponse<T[]>(response)),
            };
        }
    }
}
