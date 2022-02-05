using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Requests.AlbumRequests
{
    public class AlbumRequest
    {
        public AlbumRequest(AlbumDto album)
        {
            Album = album;
        }

        public AlbumDto Album { get; set; }
    }
}
