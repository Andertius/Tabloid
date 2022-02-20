using Tabloid.Domain.Enums;

namespace Tabloid.Application.Commands.Tunings
{
    public class TuningCommandResponse<T>  where T : class
    {
        public TuningCommandResponse(
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
