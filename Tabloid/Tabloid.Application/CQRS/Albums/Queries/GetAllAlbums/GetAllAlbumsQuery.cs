using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Albums.Queries.GetAllAlbums
{
    public class GetAllAlbumsQuery : IRequest<AlbumDto[]>
    {
    }
}
