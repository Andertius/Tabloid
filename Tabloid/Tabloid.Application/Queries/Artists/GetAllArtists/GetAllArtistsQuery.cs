using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Queries.Artists.GetAllArtists
{
    public class GetAllArtistsQuery : IRequest<ArtistDto[]>
    {
    }
}
