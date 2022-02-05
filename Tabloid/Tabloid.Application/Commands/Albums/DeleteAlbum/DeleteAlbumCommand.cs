using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Commands.Albums.DeleteAlbum
{
    public class DeleteAlbumCommand : IRequest<CommandResponse<AlbumDto>>
    {
        public DeleteAlbumCommand(AlbumDto album)
        {
            Album = album;
        }

        public AlbumDto Album { get; set; }
    }
}
