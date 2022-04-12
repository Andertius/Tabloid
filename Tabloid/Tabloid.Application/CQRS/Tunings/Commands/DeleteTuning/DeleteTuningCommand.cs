using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tunings.Commands.DeleteTuning
{
    public class DeleteTuningCommand : IRequest<CommandResponse<GuitarTuningDto>>
    {
        public DeleteTuningCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
