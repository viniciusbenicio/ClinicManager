using ClinicManager.Application.Commands.CreateService;
using ClinicManager.Application.Commands.UpdateCare;
using FluentValidation;

namespace ClinicManager.Application.Validators.Service
{
    public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
    {
        public CreateServiceCommandValidator()
        {
          

            RuleFor(p => p.Description)
                .MaximumLength(100)
                .WithMessage("A Descrição deve conter no máximo 100 caracteres");

            RuleFor(p => p.Price)
                .GreaterThan(0)
                .WithMessage("O Preço deve ser maior que 0")
                .ScalePrecision(4, 19)
                .WithMessage("O Preço deve ter no máximo 19 dígitos no total e 4 casas decimais");

            RuleFor(p => p.Duration)
                .GreaterThan(0)
                .WithMessage("A Duração deve ser maior que 0");



        }
    }

    public class UpdateServiceCommandValidator : AbstractValidator<UpdateServiceCommand>
    {
        public UpdateServiceCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("O Nome é obrigatório")
                .MaximumLength(30)
                .WithMessage("O Nome deve conter no máximo 30 caracteres");

            RuleFor(p => p.Description)
                .MaximumLength(100)
                .WithMessage("A Descrição deve conter no máximo 100 caracteres");

            RuleFor(p => p.Price)
                .GreaterThan(0)
                .WithMessage("O Preço deve ser maior que 0")
                .ScalePrecision(4, 19)
                .WithMessage("O Preço deve ter no máximo 19 dígitos no total e 4 casas decimais");

            RuleFor(p => p.Duration)
                .GreaterThan(0)
                .WithMessage("A Duração deve ser maior que 0");



        }
    }
}
