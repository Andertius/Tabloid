using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Commands.Artists.DeleteArtist
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
