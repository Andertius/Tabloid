using FluentValidation;

using Tabloid.Application.Commands.Songs.DeleteSong;

namespace Tabloid.Application.Validators.Commands.Songs
{
    public class DeleteSongCommandValidator : AbstractValidator<DeleteSongCommand>
    {
        public DeleteSongCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
