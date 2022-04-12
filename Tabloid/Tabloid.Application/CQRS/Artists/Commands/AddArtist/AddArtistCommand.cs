using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Artists.Commands.AddArtist
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
