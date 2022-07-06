using FluentValidation;

namespace MargunStore.Domain.Commands.v1.Category.Update
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(value => value.Id)
                .NotEmpty()
                    .WithMessage("Campo id Obrigatório")
                .NotNull()
                    .WithMessage("Campo id Obrigatório");
        }
    }
}
