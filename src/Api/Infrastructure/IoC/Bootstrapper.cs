using FluentValidation.AspNetCore;
using MargunStore.Domain.Commands.v1.Category.Create;
using MargunStore.Domain.Commands.v1.Category.Delete;
using MargunStore.Domain.Commands.v1.Category.Update;
using MargunStore.Domain.Commands.v1.Product.Create;
using MargunStore.Domain.Commands.v1.Product.Update;
using MargunStore.Domain.MapperProfile;
using MargunStore.Infrastructure.Data;
using MargunStore.Infrastructure.Data.Interfaces;
using MargunStore.Infrastructure.Data.Query.MapperProfile;
using MargunStore.Infrastructure.Data.Query.Queries.v1.Category.GetCategory;
using MargunStore.Infrastructure.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace MargunStore.Api.Infrastructure.IoC
{
    public class Bootstrapper
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceCollection _services;

        public Bootstrapper(IConfiguration configuration, IServiceCollection services)
        {
            _configuration = configuration;
            _services = services;

            Initialize();
        }

        private void Initialize()
        {
            var handlerAssemblies = new Assembly[]
            {
                typeof(CreateCategoryCommandHadler).Assembly,
                typeof(UpdateCategoryCommandHandler).Assembly,
                typeof(DeleteCategoryCommandHandler).Assembly,
                typeof(GetCategoryQueryHandler).Assembly,
                typeof(CreateProductCommandHandler).Assembly,
                typeof(UpdateProductCommandHandler).Assembly
            };

            var mapperAssemblies = new Assembly[]
            {
                typeof(CommandEntityProfile).Assembly,
                typeof(EntityQueryResponseProfile).Assembly
            };

            _services.AddScoped<ICategoryRepository, CategoryRepository>();
            _services.AddScoped<IProductRepository, ProductRepository>();
            
            _services.AddDbContext<Context>(value => value.UseSqlServer(_configuration.GetConnectionString("DatabaseConnection")).EnableSensitiveDataLogging());
            _services.AddControllers().AddFluentValidation(value => 
            {
                value.RegisterValidatorsFromAssemblyContaining<CreateCategoryCommandValidator>();
                value.RegisterValidatorsFromAssemblyContaining<UpdateCategoryCommandValidator>();
                value.RegisterValidatorsFromAssemblyContaining<DeleteCategoryCommandValidator>();
                value.RegisterValidatorsFromAssemblyContaining<CreateProductCommandValidator>();
                value.RegisterValidatorsFromAssemblyContaining<UpdateProductCommandValidator>();
            });
          
            _services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });
            
            _services.AddAutoMapper(mapperAssemblies);
            _services.AddMediatR(handlerAssemblies);
        }
    }
}
