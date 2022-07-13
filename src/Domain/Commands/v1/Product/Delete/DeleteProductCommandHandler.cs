using AutoMapper;
using MargunStore.CrossCutting.Exception;
using MargunStore.Infrastructure.Data.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MargunStore.Domain.Commands.v1.Product.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeleteProductCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;

        public DeleteProductCommandHandler(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _repository.GetEntity(request.Id).FirstAsync();
                await _repository.Delete(product);

                return new DeleteProductCommandResponse();
            }
            catch (Exception ex)
            {

                throw new ProductException(ex.Message, ex);
            }
        }
    }
}
