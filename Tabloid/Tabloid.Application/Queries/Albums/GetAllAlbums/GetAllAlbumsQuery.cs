using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Queries.Albums.GetAllAlbums
{
    public class GetAllAlbumsQuery : IRequest<AlbumDto[]>
    {
    }
}
