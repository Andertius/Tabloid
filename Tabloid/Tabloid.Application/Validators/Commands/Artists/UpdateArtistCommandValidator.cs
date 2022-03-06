using FluentValidation;

using Tabloid.Application.Commands.Artists.UpdateArtist;

namespace Tabloid.Application.Validators.Commands.Artists
{
    public class UpdateArtistCommandValidator : AbstractValidator<UpdateArtistCommand>
    {
        public UpdateArtistCommandValidator()
        {
            RuleFor(x => x.Artist)
                .NotEmpty();

            RuleFor(x => x.Artist.Name)
                .NotEmpty();
        }
    }
}
