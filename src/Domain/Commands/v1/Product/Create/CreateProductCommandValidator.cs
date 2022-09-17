using FluentValidation;

namespace MargunStore.Domain.Commands.v1.Product.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(value => value.Name)
                .NotEmpty()
                    .WithMessage("O campo name é Obrigatório")
                .NotNull()
                    .WithMessage("O campo name é Obrigatório")
                .MinimumLength(3)
                    .WithMessage("Entre com mais caracteres")
                .MaximumLength(50)
                    .WithMessage("Entre com menos caracteres");


            RuleFor(value => value.Description)
                .NotEmpty()
                    .WithMessage("O campo description é Obrigatório")
                .NotNull()
                    .WithMessage("O campo description é Obrigatório")
                .MinimumLength(5)
                    .WithMessage("Entre com mais caracteres")
                .MaximumLength(150)
                    .WithMessage("Entre com menos caracteres");


            RuleFor(value => value.Quantity)
                .NotEmpty()
                    .WithMessage("O campo quantity é Obrigatório")
                .NotNull()
                    .WithMessage("O campo quantity é Obrigatório");


            RuleFor(value => value.Value)
                .NotEmpty()
                    .WithMessage("O campo value é Obrigatório")
                .NotNull()
                    .WithMessage("O campo value é Obrigatório");


            RuleFor(value => value.Length)
                .NotEmpty()
                    .WithMessage("O campo length é Obrigatório")
                .NotNull()
                    .WithMessage("O campo length é Obrigatório")
                .MaximumLength(15)
                    .WithMessage("Entre com menos caracteres");
        }
    }
}
