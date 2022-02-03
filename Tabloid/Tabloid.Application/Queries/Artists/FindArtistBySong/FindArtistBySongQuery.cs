using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Queries.Artists.FindArtistBySong
{
    public class FindArtistBySongQuery : IRequest<ArtistDto>
    {
        public FindArtistBySongQuery(SongDto song)
        {
            Song = song;
        }

        public SongDto Song { get; set; }
    }
}
