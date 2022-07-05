using AutoMapper;
using MargunStore.CrossCutting.Configuration.Entities;
using MargunStore.Domain.Commands.v1.Category.Create;

namespace MargunStore.Domain.MapperProfile
{
    public class CommandEntityProfile : Profile
    {
        public CommandEntityProfile()
        {
            CreateMap<CreateCategoryCommand, Category>();
        }
    }
}
