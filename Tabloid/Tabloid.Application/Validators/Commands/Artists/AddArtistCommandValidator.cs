using FluentValidation;

using Tabloid.Application.Commands.Artists.AddArtist;

namespace Tabloid.Application.Validators.Commands.Artists
{
    public class AddArtistCommandValidator : AbstractValidator<AddArtistCommand>
    {
        public AddArtistCommandValidator()
        {
            RuleFor(x => x.Artist)
                .NotEmpty();

            RuleFor(x => x.Artist.Id)
                .Empty()
                .WithMessage("The id value must not be predefined");

            RuleFor(x => x.Artist.Name)
                .NotEmpty();
        }
    }
}
