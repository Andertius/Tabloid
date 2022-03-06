using FluentValidation;

using Tabloid.Application.Commands.Songs.AddSong;

namespace Tabloid.Application.Validators.Commands.Songs
{
    public class AddSongCommandValidator : AbstractValidator<AddSongCommand>
    {
        public AddSongCommandValidator()
        {
            RuleFor(x => x.Song)
                .NotEmpty();

            RuleFor(x => x.Song.Id)
                .Empty();

            RuleFor(x => x.Song.SongName)
                .NotEmpty();
        }
    }
}
