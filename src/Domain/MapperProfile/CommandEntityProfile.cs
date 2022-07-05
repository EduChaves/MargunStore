using AutoMapper;
using MargunStore.Domain.Commands.v1.Category.Create;
using MargunStore.Domain.Entities;

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
