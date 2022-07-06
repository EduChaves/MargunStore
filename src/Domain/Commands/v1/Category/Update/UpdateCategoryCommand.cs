using MediatR;

namespace MargunStore.Domain.Commands.v1.Category.Update
{
    public class UpdateCategoryCommand : IRequest<UpdateCategoryCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
