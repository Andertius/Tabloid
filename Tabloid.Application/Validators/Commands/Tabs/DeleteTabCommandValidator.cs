using FluentValidation;

using Tabloid.Application.CQRS.Tabs.Commands.DeleteTab;

namespace Tabloid.Application.Validators.Commands.Tabs;

internal class DeleteTabCommandValidator : AbstractValidator<DeleteTabCommand>
{
    public DeleteTabCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
