using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Artists.Commands.DeleteArtist
{
    public class DeleteArtistCommand : IRequest<CommandResponse<ArtistDto>>
    {
        public DeleteArtistCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
