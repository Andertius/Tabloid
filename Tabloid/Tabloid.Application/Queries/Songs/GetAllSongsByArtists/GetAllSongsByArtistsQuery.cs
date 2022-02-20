using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Queries.Songs.GetAllSongsByArtists
{
    public class GetAllSongsByArtistsQuery : IRequest<SongDto[]>
    {
        public GetAllSongsByArtistsQuery(ICollection<ArtistDto> artists)
        {
            Artists = artists;
        }

        public ICollection<ArtistDto> Artists { get; set; }
    }
}
