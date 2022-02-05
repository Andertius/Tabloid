using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Commands.Tunings.UpdateTuning
{
    public class UpdateTuningCommand : IRequest<CommandResponse<GuitarTuningDto>>
    {
        public UpdateTuningCommand(GuitarTuningDto tuning)
        {
            Tuning = tuning;
        }

        public GuitarTuningDto Tuning { get; set; }
    }
}
