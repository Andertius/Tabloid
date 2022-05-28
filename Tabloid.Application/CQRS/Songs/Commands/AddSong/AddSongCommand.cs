using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Songs.Commands.AddSong
{
    public class AddSongCommand : IRequest<CommandResponse<SongDto>>
    {
        public AddSongCommand(SongDto song)
        {
            Song = song;
        }

        public SongDto Song { get; set; }
    }
}
