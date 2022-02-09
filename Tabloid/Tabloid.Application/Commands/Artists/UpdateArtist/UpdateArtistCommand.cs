using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Commands.Artists.UpdateArtist
{
    public class UpdateArtistCommand : IRequest<CommandResponse<ArtistDto>>
    {
        public UpdateArtistCommand(ArtistDto artist)
        {
            Artist = artist;
        }

        public ArtistDto Artist { get; set; }
    }
}
