using AutoMapper;
using MargunStore.CrossCutting.Exception;
using MargunStore.Infrastructure.Data.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MargunStore.Infrastructure.Data.Query.Queries.v1.Product.GetProducts
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, IEnumerable<GetProductQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;

        public GetProductQueryHandler(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<GetProductQueryResponse>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Id.HasValue)
                {
                    var entity = await _repository.GetEntity(request.Id.Value).ToListAsync();
                    return _mapper.Map<IEnumerable<GetProductQueryResponse>>(entity);
                }

                var entityList = await _repository.GetEntity().ToListAsync();
                return _mapper.Map<IEnumerable<GetProductQueryResponse>>(entityList);
            }
            catch (System.Exception ex)
            {
                throw new ProductException(ex.Message, ex);
            }
        }
    }
}
