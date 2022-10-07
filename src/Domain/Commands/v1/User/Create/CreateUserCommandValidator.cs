using FluentValidation;

namespace MargunStore.Domain.Commands.v1.User.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(value => value.Email)
                .NotEmpty()
                    .WithMessage("O campo email é Obrigatório")
                .NotNull()
                    .WithMessage("O campo email é Obrigatório")
                .MinimumLength(10)
                    .WithMessage("Entre com mais caracteres")
                .MaximumLength(50)
                    .WithMessage("Entre com menos caracteres");

            RuleFor(value => value.Password)
                .NotEmpty()
                    .WithMessage("O campo password é Obrigatório")
                .NotNull()
                    .WithMessage("O campo password é Obrigatório")
                .MinimumLength(6)
                    .WithMessage("Entre com mais caracteres")
                .MaximumLength(20)
                    .WithMessage("Entre com menos caracteres");

            RuleFor(value => value.ConfirmPassword)
                .Equal(value => value.Password)
                    .WithMessage("Confirmação de senha incompatível com a senha")
                .NotEmpty()
                    .WithMessage("O campo password é Obrigatório")
                .NotNull()
                    .WithMessage("O campo password é Obrigatório")
                .MinimumLength(6)
                    .WithMessage("Entre com mais caracteres")
                .MaximumLength(20)
                    .WithMessage("Entre com menos caracteres");

        }
    }
}
