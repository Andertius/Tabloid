using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Songs.Queries.GetAllSongsByArtists
{
    public class GetAllSongsByArtistsQuery : IRequest<SongDto[]>
    {
        public GetAllSongsByArtistsQuery(ICollection<Guid> ids)
        {
            Ids = ids;
        }

        public ICollection<Guid> Ids { get; set; }
    }
}
