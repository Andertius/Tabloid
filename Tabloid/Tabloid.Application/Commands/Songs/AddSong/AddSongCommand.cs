using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Commands.Songs.AddSong
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
