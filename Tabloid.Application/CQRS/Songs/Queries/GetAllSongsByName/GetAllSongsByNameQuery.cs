using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Songs.Queries.GetAllSongsByName;

public class GetAllSongsByNameQuery : IRequest<SongDto[]>
{
    public GetAllSongsByNameQuery(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
