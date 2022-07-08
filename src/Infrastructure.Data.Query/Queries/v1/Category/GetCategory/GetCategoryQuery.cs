using MediatR;
using System.Collections.Generic;

namespace MargunStore.Infrastructure.Data.Query.Queries.v1.Category.GetCategory
{
    public class GetCategoryQuery : IRequest<IEnumerable<GetCategoryQueryResponse>>
    {
    }
}
