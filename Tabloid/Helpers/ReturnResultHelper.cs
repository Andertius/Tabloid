using System;

using Microsoft.AspNetCore.Mvc;

using Tabloid.Application.CQRS;
using Tabloid.Domain.Enums;

namespace Tabloid.Helpers
{
    public static class ReturnResultHelper
    {
        public static IActionResult ReturnCommandResult<T>(CommandResponse<T> response) where T : class
        {
            return response.Result switch
            {
                CommandResult.Success => new OkObjectResult(response),
                CommandResult.Failure => new BadRequestObjectResult(response),
                CommandResult.NotFound => new NotFoundObjectResult(response),
                _ => throw new NotSupportedException(),
            };
        }

        public static IActionResult ReturnQueryResult<T>(T response) where T : class
        {
            return response switch
            {
                null => new NotFoundObjectResult(response),
                _ => new OkObjectResult(response),
            };
        }

        public static IActionResult ReturnQueryResult<T>(T[] response) where T : class
        {
            return response.Length switch
            {
                0 => new NotFoundObjectResult(response),
                _ => new OkObjectResult(response),
            };
        }
    }
}
