using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Songs.Queries.GetAllSongs
{
    public class GetAllSongsQuery : IRequest<SongDto[]>
    {
    }
}
