using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Albums.Queries.GetAllAlbumsByArtist
{
    public class GetAllAlbumsByArtistQuery : IRequest<AlbumDto[]>
    {
        public GetAllAlbumsByArtistQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
