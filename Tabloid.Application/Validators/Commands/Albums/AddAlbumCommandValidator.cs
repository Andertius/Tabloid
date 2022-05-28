using FluentValidation;

using Tabloid.Application.CQRS.Albums.Commands.AddAlbum;

namespace Tabloid.Application.Validators.Commands.Albums
{
    public class AddAlbumCommandValidator : AbstractValidator<AddAlbumCommand>
    {
        public AddAlbumCommandValidator()
        {
            RuleFor(x => x.Album)
                .NotEmpty();

            RuleFor(x => x.Album.Id)
                .Empty()
                .WithMessage("The id value must not be predefined");

            RuleFor(x => x.Album.Name)
                .NotEmpty();

            RuleFor(x => x.Album.Year)
                .NotEmpty();
        }
    }
}
