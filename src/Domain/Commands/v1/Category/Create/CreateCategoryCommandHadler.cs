using AutoMapper;
using MargunStore.CrossCutting.Exception;
using MargunStore.Infrastructure.Data.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MargunStore.Domain.Commands.v1.Category.Create
{
    public class CreateCategoryCommandHadler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;

        public CreateCategoryCommandHadler(IMapper mapper, ICategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var category = _mapper.Map<CrossCutting.Configuration.Entities.Category>(request);
                await _repository.Add(category);
                
                return new CreateCategoryCommandResponse();
            }
            catch (System.Exception ex)
            {
                throw new CategoryException(ex.Message);
            }
        }
    }
}
