using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Genres.Queries.GetAllElectroGenres
{
    public class GetAllElectroGenresQuery : IRequest<GenreDto[]>
    {
    }
}
