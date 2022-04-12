using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Genres.Queries.GetAllMetalGenres
{
    public class GetAllMetalGenresQuery : IRequest<GenreDto[]>
    {
    }
}
