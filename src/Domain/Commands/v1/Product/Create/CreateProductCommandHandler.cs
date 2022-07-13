using AutoMapper;
using MargunStore.CrossCutting.Exception;
using MargunStore.Infrastructure.Data.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MargunStore.Domain.Commands.v1.Product.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand,CreateProductCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;

        public CreateProductCommandHandler(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _mapper.Map<CrossCutting.Configuration.Entities.Product>(request);
                await _repository.Add(product);

                return new CreateProductCommandResponse();
            }
            catch (System.Exception ex)
            {
                throw new ProductException(ex.Message, ex);
            }
        }
    }
}
