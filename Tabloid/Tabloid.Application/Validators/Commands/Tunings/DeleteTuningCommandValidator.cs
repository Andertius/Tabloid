using FluentValidation;

using Tabloid.Application.Commands.Tunings.DeleteTuning;

namespace Tabloid.Application.Validators.Commands.Tunings
{
    public class DeleteTuningCommandValidator : AbstractValidator<DeleteTuningCommand>
    {
        public DeleteTuningCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
