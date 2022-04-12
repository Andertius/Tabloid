using FluentValidation;

using Tabloid.Application.CQRS.Albums.Commands.DeleteAlbum;

namespace Tabloid.Application.Validators.Commands.Albums
{
    public class DeleteAlbumCommandValidator : AbstractValidator<DeleteAlbumCommand>
    {
        public DeleteAlbumCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
