using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Artists.Queries.GetAllArtists
{
    public class GetAllArtistsQuery : IRequest<ArtistDto[]>
    {
    }
}
