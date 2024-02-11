using FluentValidation;

using Tabloid.Application.CQRS.Genres.Commands.DeleteGenre;

namespace Tabloid.Application.Validators.Commands.Genres;

public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
{
    public DeleteGenreCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
