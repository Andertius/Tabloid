using FluentValidation;

using Tabloid.Application.CQRS.Songs.Commands.AddSong;

namespace Tabloid.Application.Validators.Commands.Songs
{
    public class AddSongCommandValidator : AbstractValidator<AddSongCommand>
    {
        public AddSongCommandValidator()
        {
            RuleFor(x => x.Song)
                .NotEmpty();

            RuleFor(x => x.Song.Name)
                .NotEmpty();
        }
    }
}
