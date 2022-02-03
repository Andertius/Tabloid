using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Queries.Genres.GetAllElectroGenres
{
    public class GetAllElectroGenresQuery : IRequest<GenreDto[]>
    {
    }
}
