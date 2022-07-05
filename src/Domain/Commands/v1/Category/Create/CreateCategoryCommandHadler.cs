using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MargunStore.Domain.Commands.v1.Category.Create
{
    public class CreateCategoryCommandHadler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        public Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
