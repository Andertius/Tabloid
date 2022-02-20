using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Queries.Songs.GetAllSongs
{
    public class GetAllSongsQuery : IRequest<SongDto[]>
    {
    }
}
