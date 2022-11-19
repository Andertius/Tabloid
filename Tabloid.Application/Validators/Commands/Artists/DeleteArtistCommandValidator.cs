using FluentValidation;

using Tabloid.Application.CQRS.Artists.Commands.DeleteArtist;

namespace Tabloid.Application.Validators.Commands.Artists;

public class DeleteArtistCommandValidator : AbstractValidator<DeleteArtistCommand>
{
    public DeleteArtistCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
