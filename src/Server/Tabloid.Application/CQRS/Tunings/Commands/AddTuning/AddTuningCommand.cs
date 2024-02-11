using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tunings.Commands.AddTuning;

public class AddTuningCommand : IRequest<CommandResponse<TuningDto>>
{
    public AddTuningCommand(TuningDto tuning)
    {
        Tuning = tuning;
    }

    public TuningDto Tuning { get; set; }
}
