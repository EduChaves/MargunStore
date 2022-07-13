using AutoMapper;
using MargunStore.CrossCutting.Exception;
using MargunStore.Infrastructure.Data.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MargunStore.Domain.Commands.v1.Category.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;

        public UpdateCategoryCommandHandler(IMapper mapper, ICategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var category = _mapper.Map<CrossCutting.Configuration.Entities.Category>(request);
                await _repository.Update(category);
                
                return new UpdateCategoryCommandResponse();
            }
            catch (System.Exception ex)
            {
                throw new CategoryException(ex.Message, ex);
            }
        }
    }
}
