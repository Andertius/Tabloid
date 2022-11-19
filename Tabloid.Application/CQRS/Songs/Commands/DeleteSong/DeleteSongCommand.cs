using System;

using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Songs.Commands.DeleteSong
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
