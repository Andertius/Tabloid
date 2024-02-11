using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Albums.Queries.GetAllAlbumsByName;

public class GetAllAlbumsByNameQuery : IRequest<AlbumDto[]>
{
    public GetAllAlbumsByNameQuery(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
