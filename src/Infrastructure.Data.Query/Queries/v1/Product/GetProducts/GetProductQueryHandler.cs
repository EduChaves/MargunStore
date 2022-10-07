using AutoMapper;
using MargunStore.CrossCutting.Configuration.Shared.Extensions;
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
            IEnumerable<CrossCutting.Configuration.Entities.Product> products;

            if (request.Id.HasValue)
            {
                products = await _repository.GetEntities(request.Id.Value).ToListAsync();
                ConvertImagesToString(products);

                return _mapper.Map<IEnumerable<GetProductQueryResponse>>(products);
            }

            products = await _repository.GetEntities().ToListAsync();
            ConvertImagesToString(products);
            
            return _mapper.Map<IEnumerable<GetProductQueryResponse>>(products);
        }

        public IEnumerable<CrossCutting.Configuration.Entities.Product> ConvertImagesToString(IEnumerable<CrossCutting.Configuration.Entities.Product> products)
        {
            foreach (var product in products)
                foreach (var image in product.Images)
                    image.Image = ConvertExtensions.DecodeToBase64(image.Image);
            
            return products;
        }
    }
}
