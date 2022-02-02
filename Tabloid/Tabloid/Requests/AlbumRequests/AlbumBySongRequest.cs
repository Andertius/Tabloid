using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Requests.AlbumRequests
{
    public class AlbumBySongRequest
    {
        public SongDto Song { get; set; }
    }
}
