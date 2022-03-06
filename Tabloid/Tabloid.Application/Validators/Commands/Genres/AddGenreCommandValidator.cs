using FluentValidation;

using Tabloid.Application.Commands.Genres.AddGenre;

namespace Tabloid.Application.Validators.Commands.Genres
{
    public class AddGenreCommandValidator : AbstractValidator<AddGenreCommand>
    {
        public AddGenreCommandValidator()
        {
            RuleFor(x => x.Genre)
                .NotEmpty();

            RuleFor(x => x.Genre.Id)
                .Empty();

            RuleFor(x => x.Genre.Name)
                .NotEmpty();
        }
    }
}
