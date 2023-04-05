using Domain.DTOs;
using Domain.Entities;
using Domain.Validators.Shared;
using FluentValidation;
using Microsoft.VisualBasic;

namespace Domain.Validators
{
    public class SaveLocationPayloadValidator : AbstractValidator<SaveLocationPayload>
    {
        public SaveLocationPayloadValidator(ICommonValidators commonValidators)
        {
            RuleFor(Location => Location.Name)
                .NotEmpty()
                .WithMessage("El campo es requerido")
                .MaximumLength(20)
                .WithMessage("Máximo 20 caracteres");

            RuleFor(Location => Location.Address)
                .NotEmpty()
                .WithMessage("El campo es requerido")
                .MaximumLength(200)
                .WithMessage("Máximo 200 caracteres");

            RuleFor(Location => Location.Email)
                .EmailAddress()
                .WithMessage("Debe ser formato de Correo electrónico")
                .NotEmpty()
                .WithMessage("El campo es requerido")
                .MaximumLength(200)
                .WithMessage("Máximo 200 caracteres");

            RuleFor(Location => Location.WebSite)
                .NotEmpty()
                .WithMessage("El campo es requerido")
                .MaximumLength(200)
                .WithMessage("Máximo 200 caracteres");

            RuleFor(Location => Location.Phone)
               .Must(x => x == null || x.Length <= 15)
               .WithMessage("Máximo 15 caracteres");

            RuleFor(Location => Location.City)
                .NotEmpty()
                .WithMessage("El campo es requerido")
                .MaximumLength(100)
                .WithMessage("Máximo 100 caracteres");

            var scheduleValidator = new ScheduleValidator(commonValidators);

            RuleFor(x => x.Schedules)
                .NotNull()
                .NotEmpty()
                .Custom((list, context) =>
                {
                    foreach (var schedule in list)
                    {
                        var result = scheduleValidator.Validate(schedule);
                        if (!result.IsValid)
                        {
                            foreach (var error in result.Errors)
                            {
                                context.AddFailure($"Schedule: {error.ErrorMessage}");
                            }
                        }
                    }
                });
        }
    }

}
