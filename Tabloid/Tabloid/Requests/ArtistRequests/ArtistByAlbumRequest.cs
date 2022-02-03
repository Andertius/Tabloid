using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Requests.ArtistRequests
{
    public class ArtistByAlbumRequest
    {
        public ArtistByAlbumRequest(AlbumDto album)
        {
            Album = album;
        }

        public AlbumDto Album { get; set; }
    }
}
