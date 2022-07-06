using FluentValidation;

namespace MargunStore.Domain.Commands.v1.Category.Delete
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(value => value.Id)
                .NotNull()
                    .WithMessage("Campo id Obrigatório")
                .NotEmpty()
                    .WithMessage("Campo id Obrigatório");
            
            RuleFor(value => value.Name)
                .NotNull()
                    .WithMessage("Campo name Obrigatório")    
                .NotEmpty()
                    .WithMessage("Campo name Obrigatório");
        }
    }
}
