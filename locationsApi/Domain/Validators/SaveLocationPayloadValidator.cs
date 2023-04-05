using Domain.DTOs;
using Domain.Validators.Shared;
using FluentValidation;

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
        }

        
    }
}
