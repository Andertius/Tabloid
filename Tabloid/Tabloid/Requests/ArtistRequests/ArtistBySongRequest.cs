using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Requests.ArtistRequests
{
    public class ArtistBySongRequest
    {
        public ArtistBySongRequest(SongDto song)
        {
            Song = song;
        }

        public SongDto Song { get; set; }
    }
}
