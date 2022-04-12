using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Songs.Queries.GetAllSongsByGenres
{
    public class GetAllSongsByGenresQuery : IRequest<SongDto[]>
    {
        public GetAllSongsByGenresQuery(ICollection<Guid> ids)
        {
            Ids = ids;
        }

        public ICollection<Guid> Ids { get; set; }
    }
}
