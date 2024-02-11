using FluentValidation;

using Tabloid.Application.CQRS.Tabs.Commands.AddTab;

namespace Tabloid.Application.Validators.Commands.Tabs;

internal class AddTabCommandValidator : AbstractValidator<AddTabCommand>
{
    public AddTabCommandValidator()
    {
        RuleFor(x => x.Tab)
            .NotEmpty();

        RuleFor(x => x.Tab.Name)
            .NotEmpty();
    }
}
