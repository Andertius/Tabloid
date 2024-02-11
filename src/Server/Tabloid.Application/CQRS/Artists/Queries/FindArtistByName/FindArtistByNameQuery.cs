using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Artists.Queries.FindArtistByName;

public class FindArtistByNameQuery : IRequest<ArtistDto>
{
    public FindArtistByNameQuery(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
