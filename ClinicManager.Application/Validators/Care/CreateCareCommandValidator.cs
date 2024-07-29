using ClinicManager.Application.Commands.CreateCare;
using ClinicManager.Application.Commands.UpdateCare;
using FluentValidation;

namespace ClinicManager.Application.Validators.Care
{
    public class CreateCareCommandValidator : AbstractValidator<CreateCareCommand>
    {
        public CreateCareCommandValidator()
        {

            RuleFor(p => p.PatientId)
                .NotEmpty()
                .WithMessage("O Id do Paciente é obrigatório");

            RuleFor(p => p.ServiceId)
                .NotEmpty()
                .WithMessage("O Id do Serviço é obrigatório");

            RuleFor(p => p.MedicalId)
                .NotEmpty()
                .WithMessage("O Id do Médico é obrigatório");

            RuleFor(p => p.Healthinsurance)
                .MaximumLength(50)
                .WithMessage("O Plano de Saúde deve conter no máximo 50 caracteres");

            RuleFor(p => p.Start)
                .NotEmpty()
                .WithMessage("A Data de Início é obrigatória");

            
            //RuleFor(p => p.TypeService)
            //    .NotEmpty()
            //    .WithMessage("O Tipo de Serviço é obrigatório");


        }


        public class UpdateCareCommandValidator : AbstractValidator<UpdateCareCommand>
        {
            public UpdateCareCommandValidator()
            {

                RuleFor(p => p.PatientId)
                    .NotEmpty()
                    .WithMessage("O Id do Paciente é obrigatório");

                RuleFor(p => p.ServiceId)
                    .NotEmpty()
                    .WithMessage("O Id do Serviço é obrigatório");

                RuleFor(p => p.MedicalId)
                    .NotEmpty()
                    .WithMessage("O Id do Médico é obrigatório");

                RuleFor(p => p.Healthinsurance)
                    .MaximumLength(50)
                    .WithMessage("O Plano de Saúde deve conter no máximo 50 caracteres");

                RuleFor(p => p.Start)
                    .NotEmpty()
                    .WithMessage("A Data de Início é obrigatória");

                RuleFor(p => p.End)
                    .GreaterThan(p => p.Start)
                    .WithMessage("A Data de Término deve ser maior que a Data de Início");

                RuleFor(p => p.TypeService)
                    .NotEmpty()
                    .WithMessage("O Tipo de Serviço é obrigatório");


            }
        }
    }
}