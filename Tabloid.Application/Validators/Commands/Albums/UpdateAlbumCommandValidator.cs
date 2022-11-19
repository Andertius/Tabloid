using FluentValidation;

using Tabloid.Application.CQRS.Albums.Commands.UpdateAlbum;

namespace Tabloid.Application.Validators.Commands.Albums;

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
