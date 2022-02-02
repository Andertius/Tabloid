using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Queries.Genres.GetAllGenres
{
    public class GetAllGenresQuery : IRequest<GenreDto[]>
    {
    }
}
