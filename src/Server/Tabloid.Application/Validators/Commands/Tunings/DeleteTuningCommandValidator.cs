using FluentValidation;

using Tabloid.Application.CQRS.Tunings.Commands.DeleteTuning;

namespace Tabloid.Application.Validators.Commands.Tunings;

public class DeleteTuningCommandValidator : AbstractValidator<DeleteTuningCommand>
{
    public DeleteTuningCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
