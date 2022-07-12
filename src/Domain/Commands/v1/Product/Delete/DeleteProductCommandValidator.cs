using FluentValidation;

namespace MargunStore.Domain.Commands.v1.Product.Delete
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(value => value.Id)
                .NotNull()
                    .WithMessage("O campo id é Obrigatório")
                .NotEmpty()
                    .WithMessage("O campo id é Obrigatório");
        }
    }
}
