using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Queries.Artists.FindArtistByName
{
    public class FindArtistByNameQuery : IRequest<ArtistDto>
    {
        public FindArtistByNameQuery(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
