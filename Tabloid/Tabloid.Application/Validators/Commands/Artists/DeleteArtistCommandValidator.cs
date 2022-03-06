using FluentValidation;

using Tabloid.Application.Commands.Artists.DeleteArtist;

namespace Tabloid.Application.Validators.Commands.Artists
{
    public class DeleteArtistCommandValidator : AbstractValidator<DeleteArtistCommand>
    {
        public DeleteArtistCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
