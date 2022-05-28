using Tabloid.Domain.Enums;

namespace Tabloid.Application.CQRS
{
    public class CommandResponse<T>  where T : class
    {
        public CommandResponse(
            T obj = null,
            CommandResult result = CommandResult.Success,
            string errorMessage = "")
        {
            Object = obj;
            Result = result;
            ErrorMessage = errorMessage;
        }

        public CommandResult Result { get; set; }

        public T Object { get; set; }

        public string ErrorMessage { get; set; }
    }
}
