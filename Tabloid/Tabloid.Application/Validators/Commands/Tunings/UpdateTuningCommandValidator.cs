using FluentValidation;

using Tabloid.Application.Commands.Tunings.UpdateTuning;

namespace Tabloid.Application.Validators.Commands.Tunings
{
    public class UpdateTuningCommandValidator : AbstractValidator<UpdateTuningCommand>
    {
        public UpdateTuningCommandValidator()
        {
            RuleFor(x => x.Tuning)
                .NotEmpty();

            RuleFor(x => x.Tuning.Id)
                .NotEmpty();

            RuleFor(x => x.Tuning.Name)
                .NotEmpty();

            RuleFor(x => x.Tuning.Tuning)
                .NotEmpty();
        }
    }
}
