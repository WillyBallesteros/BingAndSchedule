using Domain.DTOs;
using Domain.Validators.Shared;
using FluentValidation;

namespace Domain.Validators
{
    public class ScheduleValidator : AbstractValidator<ScheduleDto>
    {
        public ScheduleValidator(ICommonValidators commonValidators)
        {
            RuleFor(x => x.Open)
                .NotNull()
                .NotEmpty()
                .Must(str => commonValidators.IsValidString(str))
                .WithMessage("El time ingresado no es válido");

            RuleFor(x => x.Close)
                .NotNull()
                .NotEmpty()
                .Must(str => commonValidators.IsValidString(str))
                .WithMessage("El time ingresado no es válido");
        }


    }
}
