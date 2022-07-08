using AutoMapper;
using MargunStore.CrossCutting.Configuration.Entities;
using MargunStore.Infrastructure.Data.Query.Queries.v1.Category.GetCategory;

namespace MargunStore.Infrastructure.Data.Query.MapperProfile
{
    public class EntityQueryResponseProfile : Profile
    {
        public EntityQueryResponseProfile()
        {
            CreateMap<Category, GetCategoryQueryResponse>();
        }
    }
}
