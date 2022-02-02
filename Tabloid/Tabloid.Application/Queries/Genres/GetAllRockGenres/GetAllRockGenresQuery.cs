using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Queries.Genres.GetAllRockGenres
{
    public class GetAllRockGenresQuery : IRequest<GenreDto[]>
    {
    }
}
