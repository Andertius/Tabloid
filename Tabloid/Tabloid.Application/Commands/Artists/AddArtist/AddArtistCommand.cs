using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Commands.Artists.AddArtist
{
    public class AddArtistCommand : IRequest<CommandResponse<ArtistDto>>
    {
        public AddArtistCommand(ArtistDto artist)
        {
            Artist = artist;
        }

        public ArtistDto Artist { get; set; }
    }
}
