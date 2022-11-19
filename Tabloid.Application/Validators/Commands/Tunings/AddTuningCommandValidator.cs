using FluentValidation;

using Tabloid.Application.CQRS.Tunings.Commands.AddTuning;

namespace Tabloid.Application.Validators.Commands.Tunings
{
    public class AddTuningCommandValidator : AbstractValidator<AddTuningCommand>
    {
        public AddTuningCommandValidator()
        {
            RuleFor(x => x.Tuning)
                .NotEmpty();

            RuleFor(x => x.Tuning.Name)
                .NotEmpty();

            RuleFor(x => x.Tuning.Strings)
                .NotEmpty();

            RuleFor(x => x.Tuning.Instrument)
                .IsInEnum();
        }
    }
}
