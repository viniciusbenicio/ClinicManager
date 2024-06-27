using ClinicManager.Application.Commands.CreatePatient;
using FluentValidation;

namespace ClinicManager.Application.Validators
{
    public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientCommandValidator()
        {
            RuleFor(l => l.Bloodtype)
                .MaximumLength(2)
                .WithMessage("Máximo de 2 caracteres ");
        }
    }
}
