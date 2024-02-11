using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Genres.Queries.GetAllRockGenres;

public class GetAllRockGenresQuery : IRequest<GenreDto[]>
{
}
