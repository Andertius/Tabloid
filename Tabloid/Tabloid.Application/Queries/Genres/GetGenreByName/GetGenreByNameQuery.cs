using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Queries.Genres.GetGenreByName
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
