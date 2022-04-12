using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Genres.Queries.GetGenreByName
{
    public class GetGenreByNameQuery : IRequest<GenreDto>
    {
        public GetGenreByNameQuery(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
