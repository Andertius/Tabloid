using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tunings.Commands.AddTuning
{
    public class AddTuningCommand : IRequest<CommandResponse<GuitarTuningDto>>
    {
        public AddTuningCommand(GuitarTuningDto tuning)
        {
            Tuning = tuning;
        }

        public GuitarTuningDto Tuning { get; set; }
    }
}
