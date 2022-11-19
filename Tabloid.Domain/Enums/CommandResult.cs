namespace Tabloid.Domain.Enums;

public enum CommandResult
{
    Failure = 400,
    NotFound = 404,
    Success = 200,
    InternalServerError = 500,
}
