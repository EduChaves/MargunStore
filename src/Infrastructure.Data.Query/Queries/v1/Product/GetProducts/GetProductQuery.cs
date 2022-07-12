using MediatR;
using System.Collections.Generic;

namespace MargunStore.Infrastructure.Data.Query.Queries.v1.Product.GetProducts
{
    public class GetProductQuery : IRequest<IEnumerable<GetProductQueryResponse>>
    {
        public int? Id { get; set; }
    }
}
