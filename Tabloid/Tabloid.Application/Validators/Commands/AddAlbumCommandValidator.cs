using FluentValidation;

using Tabloid.Application.Commands.Albums.AddAlbum;

namespace Tabloid.Application.Validators.Commands
{
    public class AddAlbumCommandValidator : AbstractValidator<AddAlbumCommand>
    {
        public AddAlbumCommandValidator()
        {
            RuleFor(x => x.Album)
                .ChildRules(x => x
                    .RuleFor(x => x.Id)
                    .Empty()
                    .WithMessage("The id value must not be predefined"));

            RuleFor(x => x.Album)
                .ChildRules(x => x
                    .RuleFor(x => x.Name)
                    .NotEmpty());

            RuleFor(x => x.Album)
                .ChildRules(x => x
                    .RuleFor(x => x.Year)
                    .NotEmpty());
        }
    }
}
