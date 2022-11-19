using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Genres.Queries.GetAllGenres;

public class GetAllGenresQuery : IRequest<GenreDto[]>
{
}
