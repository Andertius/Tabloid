using FluentValidation;

using Tabloid.Application.CQRS.Artists.Commands.AddArtist;

namespace Tabloid.Application.Validators.Commands.Artists;

public class AddArtistCommandValidator : AbstractValidator<AddArtistCommand>
{
    public AddArtistCommandValidator()
    {
        RuleFor(x => x.Artist)
            .NotEmpty();

        RuleFor(x => x.Artist.Name)
            .NotEmpty();
    }
}
