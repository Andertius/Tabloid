using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Queries.Artists.FindArtistByAlbum
{
    public class FindArtistByAlbumQuery : IRequest<ArtistDto>
    {
        public FindArtistByAlbumQuery(AlbumDto album)
        {
            Album = album;
        }

        public AlbumDto Album { get; set; }
    }
}
