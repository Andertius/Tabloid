using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Commands.Albums.DeleteAlbum
{
    public class DeleteAlbumCommand : IRequest<CommandResponse<AlbumDto>>
    {
        public DeleteAlbumCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
