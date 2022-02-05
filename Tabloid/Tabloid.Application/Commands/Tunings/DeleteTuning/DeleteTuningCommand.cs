using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Commands.Tunings.DeleteTuning
{
    public class DeleteTuningCommand : IRequest<CommandResponse<GuitarTuningDto>>
    {
        public DeleteTuningCommand(GuitarTuningDto tuning)
        {
            Tuning = tuning;
        }

        public GuitarTuningDto Tuning { get; set; }
    }
}
