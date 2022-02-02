using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Queries.Albums.GetAllAlbumsByName
{
    public class GetAllAlbumsByNameQuery : IRequest<AlbumDto[]>
    {
        public GetAllAlbumsByNameQuery(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
