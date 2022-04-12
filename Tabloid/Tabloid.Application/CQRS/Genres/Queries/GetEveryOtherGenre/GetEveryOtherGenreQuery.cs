using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Genres.Queries.GetEveryOtherGenre
{
    public class GetEveryOtherGenreQuery : IRequest<GenreDto[]>
    {
    }
}
