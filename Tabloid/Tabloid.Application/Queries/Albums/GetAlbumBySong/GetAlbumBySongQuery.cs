using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Queries.Albums.GetAlbumBySong
{
    public class GetAlbumBySongQuery : IRequest<AlbumDto>
    {
        public GetAlbumBySongQuery(SongDto song)
        {
            Song = song;
        }

        public SongDto Song { get; set; }
    }
}
