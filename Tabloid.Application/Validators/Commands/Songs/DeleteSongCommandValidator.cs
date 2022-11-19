using FluentValidation;

using Tabloid.Application.CQRS.Songs.Commands.DeleteSong;

namespace Tabloid.Application.Validators.Commands.Songs;

public class DeleteSongCommandValidator : AbstractValidator<DeleteSongCommand>
{
    public DeleteSongCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
