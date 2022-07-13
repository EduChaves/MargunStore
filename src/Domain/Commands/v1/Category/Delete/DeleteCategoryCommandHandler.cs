using AutoMapper;
using MargunStore.CrossCutting.Exception;
using MargunStore.Infrastructure.Data.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MargunStore.Domain.Commands.v1.Category.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;

        public DeleteCategoryCommandHandler(IMapper mapper, ICategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var category = _mapper.Map<CrossCutting.Configuration.Entities.Category>(request);
                await _repository.Delete(category);

                return new DeleteCategoryCommandResponse();
            }
            catch (System.Exception ex)
            {
                throw new CategoryException(ex.Message, ex);
            }
        }
    }
}
