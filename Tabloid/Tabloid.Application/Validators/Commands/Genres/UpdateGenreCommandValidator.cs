using FluentValidation;

using Tabloid.Application.Commands.Genres.UpdateGenre;

namespace Tabloid.Application.Validators.Commands.Genres
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(x => x.Genre)
                .NotEmpty();

            RuleFor(x => x.Genre.Id)
                .NotEmpty();

            RuleFor(x => x.Genre.Name)
                .NotEmpty();
        }
    }
}
