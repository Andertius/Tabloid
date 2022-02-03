using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Queries.Genres.GetEveryOtherGenre
{
    public class GetEveryOtherGenreQuery : IRequest<GenreDto[]>
    {
    }
}
