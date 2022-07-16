using FluentValidation.AspNetCore;
using MargunStore.CrossCutting.Configuration.Entities;
using MargunStore.Domain.Commands.v1.Category.Create;
using MargunStore.Domain.Commands.v1.Category.Delete;
using MargunStore.Domain.Commands.v1.Category.Update;
using MargunStore.Domain.Commands.v1.Product.Create;
using MargunStore.Domain.Commands.v1.Product.Delete;
using MargunStore.Domain.Commands.v1.Product.Update;
using MargunStore.Domain.Commands.v1.Role.Create;
using MargunStore.Domain.Commands.v1.Role.Update;
using MargunStore.Domain.Commands.v1.User.Create;
using MargunStore.Domain.MapperProfile;
using MargunStore.Infrastructure.Data;
using MargunStore.Infrastructure.Data.Interfaces;
using MargunStore.Infrastructure.Data.Query.MapperProfile;
using MargunStore.Infrastructure.Data.Query.Queries.v1.Category.GetCategory;
using MargunStore.Infrastructure.Data.Query.Queries.v1.Product.GetProducts;
using MargunStore.Infrastructure.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
                typeof(CreateProductCommandHandler).Assembly,
                typeof(UpdateProductCommandHandler).Assembly,
                typeof(DeleteProductCommandHandler).Assembly,
                typeof(CreateRoleCommandHandler).Assembly,
                typeof(UpdateRoleCommandHandler).Assembly,
                typeof(CreateUserCommandHandler).Assembly,

                typeof(GetCategoryQueryHandler).Assembly,
                typeof(GetProductQueryHandler).Assembly,
            };

            var mapperAssemblies = new Assembly[]
            {
                typeof(CommandEntityProfile).Assembly,
                typeof(EntityQueryResponseProfile).Assembly
            };

            _services.AddScoped<ICategoryRepository, CategoryRepository>();
            _services.AddScoped<IProductRepository, ProductRepository>();
            _services.AddScoped<IRoleRepository, RoleRepository>();
            _services.AddScoped<IUserRepository, UserRepository>();

            _services.AddDbContext<Context>(value => value.UseSqlServer(_configuration.GetConnectionString("DatabaseConnection")).EnableSensitiveDataLogging());
            _services.AddControllers().AddFluentValidation(value => 
            {
                value.RegisterValidatorsFromAssemblyContaining<CreateCategoryCommandValidator>();
                value.RegisterValidatorsFromAssemblyContaining<UpdateCategoryCommandValidator>();
                value.RegisterValidatorsFromAssemblyContaining<DeleteCategoryCommandValidator>();
                value.RegisterValidatorsFromAssemblyContaining<CreateProductCommandValidator>();
                value.RegisterValidatorsFromAssemblyContaining<UpdateProductCommandValidator>();
                value.RegisterValidatorsFromAssemblyContaining<DeleteProductCommandValidator>();
                value.RegisterValidatorsFromAssemblyContaining<CreateRoleCommandValidator>();
                value.RegisterValidatorsFromAssemblyContaining<UpdateRoleCommandValidator>();
                value.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
            });
          
            _services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });
            
            _services.AddAutoMapper(mapperAssemblies);
            _services.AddMediatR(handlerAssemblies);
            
            IdentityInitialize();
        }

        private void IdentityInitialize()
        {
            var builder = _services.AddIdentity<User, Role>(value =>
            {
                value.Password.RequireDigit = false;
                value.Password.RequireLowercase = false;
                value.Password.RequireNonAlphanumeric = false;
                value.Password.RequireUppercase = false;
                value.Password.RequiredLength = 8;
            });
            
            builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
            builder.AddEntityFrameworkStores<Context>();
            builder.AddSignInManager<SignInManager<User>>();
            builder.AddRoleManager<RoleManager<Role>>();
        }
    }
}
