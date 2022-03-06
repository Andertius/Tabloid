using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Commands.Songs.DeleteSong
{
    public class DeleteSongCommand : IRequest<CommandResponse<SongDto>>
    {
        public DeleteSongCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
