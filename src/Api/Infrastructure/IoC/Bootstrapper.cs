using AutoMapper;
using FluentValidation;
using MargunStore.Domain.Commands.v1.Category.Create;
using MargunStore.Domain.MapperProfile;
using MargunStore.Infrastructure.Data;
using MargunStore.Infrastructure.Data.Interfaces;
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

            Init();
        }

        private void Init()
        {
            var assemblies = new Assembly[]
            {
                typeof(CreateCategoryCommandHadler).Assembly
            };

            _services.AddScoped<ICategoryRepository, CategoryRepository>();
            _services.AddScoped<IValidator<CreateCategoryCommand>, CreateCategoryCommandValidator>();

            _services.AddDbContext<Context>(value => value.UseSqlServer(_configuration.GetConnectionString("DatabaseConnection")).EnableSensitiveDataLogging());
            _services.AddMediatR(assemblies);
            _services.AddControllers();
          
            _services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });
            
            AutoMapperConfiguration();
        }
        private void AutoMapperConfiguration()
        {
            var mapper = new MapperConfiguration(value => value.AddProfile(new CommandEntityProfile()));
            _services.AddSingleton(mapper.CreateMapper());
        }
    }
}
