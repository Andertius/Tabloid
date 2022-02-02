using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Queries.Albums.GetAllAlbumsByArtist
{
    public class GetAllAlbumsByArtistQuery : IRequest<AlbumDto[]>
    {
        public GetAllAlbumsByArtistQuery(ArtistDto artist)
        {
            Artist = artist;
        }

        public ArtistDto Artist { get; set; }
    }
}
