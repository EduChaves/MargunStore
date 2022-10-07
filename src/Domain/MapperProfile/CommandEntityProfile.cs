using AutoMapper;
using MargunStore.CrossCutting.Configuration.Entities;
using MargunStore.Domain.Commands.v1.Category.Create;
using MargunStore.Domain.Commands.v1.Category.Delete;
using MargunStore.Domain.Commands.v1.Category.Update;
using MargunStore.Domain.Commands.v1.Product.Create;
using MargunStore.Domain.Commands.v1.Product.Update;
using MargunStore.Domain.Commands.v1.User.Create;
using MargunStore.Domain.Commands.v1.User.Login;

namespace MargunStore.Domain.MapperProfile
{
    public class CommandEntityProfile : Profile
    {
        public CommandEntityProfile()
        {
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
            CreateMap<DeleteCategoryCommand, Category>();

            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();

            CreateMap<LoginCommand, User>();
            CreateMap<CreateUserCommand, User>()
                .ForMember(dest => dest.UserName, map => map.MapFrom(src => src.Email));

        }
    }
}
