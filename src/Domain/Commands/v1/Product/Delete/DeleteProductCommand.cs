using MediatR;

namespace MargunStore.Domain.Commands.v1.Product.Delete
{
    public class DeleteProductCommand : IRequest<DeleteProductCommandResponse>
    {
        public int Id { get; set; }
    }
}
