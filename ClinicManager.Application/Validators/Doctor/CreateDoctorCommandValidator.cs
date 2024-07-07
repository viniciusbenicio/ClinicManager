using ClinicManager.Application.Commands.CreateDoctor;
using ClinicManager.Application.Commands.UpdateDoctor;
using FluentValidation;

namespace ClinicManager.Application.Validators.Doctor
{
    public class CreateDoctorCommandValidator : AbstractValidator<CreateDoctorCommand>
    {
        public CreateDoctorCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .MinimumLength(5)
                .WithMessage("O Primeiro nome deve conter no mínimo 5 caracteres")
                .MaximumLength(30)
                .WithMessage("O Primeiro nome deve conter no máximo 30 caracteres");

            RuleFor(p => p.LastName)
                .MinimumLength(5)
                .WithMessage("O Sobrenome deve conter no mínimo 5 caracteres")
                .MaximumLength(50)
                .WithMessage("O Sobrenome deve conter no máximo 50 caracteres");

            RuleFor(p => p.Telephone)
                .MinimumLength(10)
                .WithMessage("O Telefone deve conter no mínimo 10 caracteres")
                .MaximumLength(11)
                .WithMessage("O Telefone deve conter no máximo 11 caracteres");

            RuleFor(p => p.Email)
                .MinimumLength(5)
                .WithMessage("O Email deve conter no mínimo 5 caracteres")
                .MaximumLength(100)
                .WithMessage("O Email deve conter no máximo 100 caracteres");

            RuleFor(p => p.Document)
                .MinimumLength(11)
                .WithMessage("O Documento deve conter no mínimo 11 caracteres")
                .MaximumLength(11)
                .WithMessage("O Documento deve conter no máximo 11 caracteres");

            RuleFor(p => p.Bloodtype)
                .MinimumLength(2)
                .WithMessage("O Tipo Sanguíneo deve conter no mínimo 2 caracteres")
                .MaximumLength(2)
                .WithMessage("O Tipo Sanguíneo deve conter no máximo 2 caracteres");

            RuleFor(p => p.Height)
                .MinimumLength(2)
                .WithMessage("A Altura deve conter no mínimo 2 caracteres")
                .MaximumLength(10)
                .WithMessage("A Altura deve conter no máximo 10 caracteres");

            RuleFor(p => p.Weight)
                .MinimumLength(2)
                .WithMessage("O Peso deve conter no mínimo 2 caracteres")
                .MaximumLength(10)
                .WithMessage("O Peso deve conter no máximo 10 caracteres");

            RuleFor(p => p.Address)
                .MinimumLength(5)
                .WithMessage("O Endereço deve conter no mínimo 5 caracteres")
                .MaximumLength(100)
                .WithMessage("O Endereço deve conter no máximo 100 caracteres");

            RuleFor(p => p.Specialty)
                .MinimumLength(5)
                .WithMessage("A Especialidade deve conter no mínimo 5 caracteres")
                .MaximumLength(100)
                .WithMessage("A Especialidade deve conter no máximo 100 caracteres");

            RuleFor(p => p.CRMRegistration)
                .MinimumLength(5)
                .WithMessage("O Registro CRM deve conter no mínimo 5 caracteres")
                .MaximumLength(100)
                .WithMessage("O Registro CRM deve conter no máximo 100 caracteres");


        }
    }


    public class UpdateDoctorCommandValidator : AbstractValidator<UpdateDoctorCommand>
    {
        public UpdateDoctorCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .MinimumLength(5)
                .WithMessage("O Primeiro nome deve conter no mínimo 5 caracteres")
                .MaximumLength(30)
                .WithMessage("O Primeiro nome deve conter no máximo 30 caracteres");

            RuleFor(p => p.LastName)
                .MinimumLength(5)
                .WithMessage("O Sobrenome deve conter no mínimo 5 caracteres")
                .MaximumLength(50)
                .WithMessage("O Sobrenome deve conter no máximo 50 caracteres");

            RuleFor(p => p.Telephone)
                .MinimumLength(10)
                .WithMessage("O Telefone deve conter no mínimo 10 caracteres")
                .MaximumLength(11)
                .WithMessage("O Telefone deve conter no máximo 11 caracteres");

            RuleFor(p => p.Email)
                .MinimumLength(5)
                .WithMessage("O Email deve conter no mínimo 5 caracteres")
                .MaximumLength(100)
                .WithMessage("O Email deve conter no máximo 100 caracteres");

            RuleFor(p => p.Document)
                .MinimumLength(11)
                .WithMessage("O Documento deve conter no mínimo 11 caracteres")
                .MaximumLength(11)
                .WithMessage("O Documento deve conter no máximo 11 caracteres");

            RuleFor(p => p.Bloodtype)
                .MinimumLength(2)
                .WithMessage("O Tipo Sanguíneo deve conter no mínimo 2 caracteres")
                .MaximumLength(2)
                .WithMessage("O Tipo Sanguíneo deve conter no máximo 2 caracteres");

            RuleFor(p => p.Height)
                .MinimumLength(2)
                .WithMessage("A Altura deve conter no mínimo 2 caracteres")
                .MaximumLength(10)
                .WithMessage("A Altura deve conter no máximo 10 caracteres");

            RuleFor(p => p.Weight)
                .MinimumLength(2)
                .WithMessage("O Peso deve conter no mínimo 2 caracteres")
                .MaximumLength(10)
                .WithMessage("O Peso deve conter no máximo 10 caracteres");

            RuleFor(p => p.Address)
                .MinimumLength(5)
                .WithMessage("O Endereço deve conter no mínimo 5 caracteres")
                .MaximumLength(100)
                .WithMessage("O Endereço deve conter no máximo 100 caracteres");

            RuleFor(p => p.Specialty)
                .MinimumLength(5)
                .WithMessage("A Especialidade deve conter no mínimo 5 caracteres")
                .MaximumLength(100)
                .WithMessage("A Especialidade deve conter no máximo 100 caracteres");

            RuleFor(p => p.CRMRegistration)
                .MinimumLength(5)
                .WithMessage("O Registro CRM deve conter no mínimo 5 caracteres")
                .MaximumLength(100)
                .WithMessage("O Registro CRM deve conter no máximo 100 caracteres");


        }
    }
}
