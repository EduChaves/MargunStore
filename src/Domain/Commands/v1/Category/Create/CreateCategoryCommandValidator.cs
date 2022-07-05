﻿using FluentValidation;

namespace MargunStore.Domain.Commands.v1.Category.Create
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(value => value.Name)
                .NotEmpty()
                .NotNull();
        }
    }
}
