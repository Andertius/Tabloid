using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Requests.AlbumRequests
{
    public class AlbumsByArtistRequest
    {
        public AlbumsByArtistRequest(ArtistDto artist)
        {
            Artist = artist;
        }

        public ArtistDto Artist { get; set; }
    }
}
