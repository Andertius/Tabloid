using Microsoft.AspNetCore.Mvc;

using Tabloid.Application.Commands;
using Tabloid.Domain.Enums;
using Tabloid.Domain.Responses;

namespace Tabloid.Helpers
{
    public static class ReturnResultHelper
    {
        public static IActionResult ReturnCommandResult<T>(CommandResponse<T> response) where T : class
        {
            return response.Result switch
            {
                CommandResult.Success => new OkObjectResult(new OkResponse<CommandResponse<T>>(response)),
                CommandResult.Failure => new BadRequestObjectResult(
                    new BadRequestResponse<CommandResponse<T>>(
                        response,
                        response.ErrorMessage)),
                CommandResult.NotFound => new NotFoundObjectResult(
                    new NotFoundResponse<CommandResponse<T>>(
                        response,
                        response.ErrorMessage)),
                _ => throw new NotSupportedException(),
            };
        }

        public static IActionResult ReturnQueryResult<T>(T response) where T : class
        {
            return response switch
            {
                null => new NotFoundObjectResult(
                    new NotFoundResponse<T>(
                        response,
                        "Object could not be found")),
                _ => new OkObjectResult(new OkResponse<T>(response)),
            };
        }

        public static IActionResult ReturnQueryResult<T>(T[] response) where T : class
        {
            return response.Length switch
            {
                0 => new NotFoundObjectResult(
                    new NotFoundResponse<T[]>(
                        response,
                        "Objects could not be found")),
                _ => new OkObjectResult(new OkResponse<T[]>(response)),
            };
        }
    }
}
