using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Queries.Songs.GetAllSongsByAlbum
{
    public class GetAllSongsByAlbumQuery : IRequest<SongDto[]>
    {
        public GetAllSongsByAlbumQuery(AlbumDto album)
        {
            Album = album;
        }

        public AlbumDto Album { get; set; }
    }
}
