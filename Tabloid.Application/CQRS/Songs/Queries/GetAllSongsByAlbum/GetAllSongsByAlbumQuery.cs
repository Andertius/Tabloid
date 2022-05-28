using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Songs.Queries.GetAllSongsByAlbum
{
    public class GetAllSongsByAlbumQuery : IRequest<SongDto[]>
    {
        public GetAllSongsByAlbumQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
