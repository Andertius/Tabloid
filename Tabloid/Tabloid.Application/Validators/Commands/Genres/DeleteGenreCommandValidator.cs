using FluentValidation;

using Tabloid.Application.Commands.Genres.DeleteGenre;

namespace Tabloid.Application.Validators.Commands.Genres
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
