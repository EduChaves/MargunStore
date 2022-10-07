using AutoMapper;
using MargunStore.CrossCutting.Configuration.Entities;
using MargunStore.Infrastructure.Data.Query.Queries.v1.Address.GetCep;
using MargunStore.Infrastructure.Data.Query.Queries.v1.Category.GetCategory;
using MargunStore.Infrastructure.Data.Query.Queries.v1.Product.GetProducts;
using MargunStore.Infrastructure.Service.Services.CorreiosApi;

namespace MargunStore.Infrastructure.Data.Query.MapperProfile
{
    public class EntityQueryResponseProfile : Profile
    {
        public EntityQueryResponseProfile()
        {
            CreateMap<Category, GetCategoryQueryResponse>();

            CreateMap<Product, GetProductQueryResponse>();

            CreateMap<CorreiosServiceResponse, GetCepQueryResponse>();
        }
    }
}
