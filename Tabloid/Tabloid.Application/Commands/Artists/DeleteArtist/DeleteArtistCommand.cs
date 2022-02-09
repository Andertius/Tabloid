using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Commands.Artists.DeleteArtist
{
    public class DeleteArtistCommand : IRequest<CommandResponse<ArtistDto>>
    {
        public DeleteArtistCommand(ArtistDto artist)
        {
            Artist = artist;
        }

        public ArtistDto Artist { get; set; }
    }
}
