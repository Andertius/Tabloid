using FluentValidation;

using Tabloid.Application.CQRS.Tabs.Commands.UpdateTab;

namespace Tabloid.Application.Validators.Commands.Tabs;

internal class UpdateTabCommandValidator : AbstractValidator<UpdateTabCommand>
{
    public UpdateTabCommandValidator()
    {
        RuleFor(x => x.Tab)
            .NotEmpty();

        RuleFor(x => x.Tab.Id)
            .NotEmpty();

        RuleFor(x => x.Tab.Name)
            .NotEmpty();
    }
}
