using FluentValidation;

namespace MargunStore.Domain.Commands.v1.Role.Update
{
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            RuleFor(value => value.Id)
                .NotNull()
                    .WithMessage("O campo id é Obrigatório")
                .NotEmpty()
                    .WithMessage("O campo id é Obrigatório");

            RuleFor(value => value.Name)
               .NotEmpty()
                   .WithMessage("O campo name é Obrigatório")
               .NotNull()
                   .WithMessage("O campo name é Obrigatório")
               .MinimumLength(3)
                   .WithMessage("Entre com mais caracteres")
               .MaximumLength(15)
                   .WithMessage("Entre com menos caracteres");

            RuleFor(value => value.Description)
                .NotEmpty()
                    .WithMessage("O campo description é Obrigatório")
                .NotNull()
                    .WithMessage("O campo description é Obrigatório")
                .MinimumLength(5)
                    .WithMessage("Entre com mais caracteres")
                .MaximumLength(30)
                    .WithMessage("Entre com menos caracteres");
        }
    }
}
