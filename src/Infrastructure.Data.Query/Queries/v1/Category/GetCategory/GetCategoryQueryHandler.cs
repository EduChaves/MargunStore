using AutoMapper;
using AutoMapper.QueryableExtensions;
using MargunStore.CrossCutting.Exception;
using MargunStore.Infrastructure.Data.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MargunStore.Infrastructure.Data.Query.Queries.v1.Category.GetCategory
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery,IEnumerable<GetCategoryQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;

        public GetCategoryQueryHandler(IMapper mapper, ICategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<GetCategoryQueryResponse>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _repository.GetEntity().ToArrayAsync();
                var categoryList = _mapper.Map<IEnumerable<CrossCutting.Configuration.Entities.Category>, IEnumerable<GetCategoryQueryResponse>>(entity);
                var tst = entity.Select(_mapper.Map<CrossCutting.Configuration.Entities.Category, GetCategoryQueryResponse>).Where(value => value.Active == true);

                return tst;
            }
            catch (System.Exception ex)
            {
                throw new CategoryException(ex.Message, ex);
            }
        }
    }
}
