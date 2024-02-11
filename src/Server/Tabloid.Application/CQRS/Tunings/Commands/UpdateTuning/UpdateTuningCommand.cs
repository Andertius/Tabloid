using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tunings.Commands.UpdateTuning;

public class UpdateTuningCommand : IRequest<CommandResponse<TuningDto>>
{
    public UpdateTuningCommand(TuningDto tuning)
    {
        Tuning = tuning;
    }

    public TuningDto Tuning { get; set; }
}
