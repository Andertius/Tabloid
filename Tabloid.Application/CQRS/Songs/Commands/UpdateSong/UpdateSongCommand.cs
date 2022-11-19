using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Songs.Commands.UpdateSong;

public class UpdateSongCommand : IRequest<CommandResponse<SongDto>>
{
    public UpdateSongCommand(SongDto song)
    {
        Song = song;
    }

    public SongDto Song { get; set; }
}
