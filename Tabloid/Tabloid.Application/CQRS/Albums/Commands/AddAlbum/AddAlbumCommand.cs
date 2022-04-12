using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Albums.Commands.AddAlbum
{
    public class AddAlbumCommand : IRequest<CommandResponse<AlbumDto>>
    {
        public AddAlbumCommand(AlbumDto album)
        {
            Album = album;
        }

        public AlbumDto Album { get; set; }
    }
}
