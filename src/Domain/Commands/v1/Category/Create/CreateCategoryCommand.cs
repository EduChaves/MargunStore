using MediatR;

namespace MargunStore.Domain.Commands.v1.Category.Create
{
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; }
    }
}
