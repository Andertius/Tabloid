using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Queries.Genres.GetAllMetalGenres
{
    public class GetAllMetalGenresQuery : IRequest<GenreDto[]>
    {
    }
}
