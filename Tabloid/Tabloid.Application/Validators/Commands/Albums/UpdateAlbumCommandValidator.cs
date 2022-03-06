using FluentValidation;

using Tabloid.Application.Commands.Albums.UpdateAlbum;

namespace Tabloid.Application.Validators.Commands.Albums
{
    public class UpdateAlbumCommandValidator : AbstractValidator<UpdateAlbumCommand>
    {
        public UpdateAlbumCommandValidator()
        {
            RuleFor(x => x.Album)
                .NotEmpty();

            RuleFor(x => x.Album.Id)
                .NotEmpty();

            RuleFor(x => x.Album.Name)
                .NotEmpty();
        }
    }
}
