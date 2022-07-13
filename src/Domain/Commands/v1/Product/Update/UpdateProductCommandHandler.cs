using AutoMapper;
using MargunStore.CrossCutting.Exception;
using MargunStore.Infrastructure.Data.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MargunStore.Domain.Commands.v1.Product.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        
        public UpdateProductCommandHandler(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _mapper.Map<CrossCutting.Configuration.Entities.Product>(request);
                await _repository.Update(product);

                return new UpdateProductCommandResponse();
            }
            catch (Exception ex)
            {
                throw new ProductException(ex.Message, ex);
            }
        }
    }
}
