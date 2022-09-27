using FluentValidation.AspNetCore;
using MargunStore.CrossCutting.Configuration.Entities;
using MargunStore.CrossCutting.Configuration.Settings.JWT;
using MargunStore.Domain.Commands.v1.Category.Create;
using MargunStore.Domain.Commands.v1.Category.Delete;
using MargunStore.Domain.Commands.v1.Category.Update;
using MargunStore.Domain.Commands.v1.Product.Create;
using MargunStore.Domain.Commands.v1.Product.Delete;
using MargunStore.Domain.Commands.v1.Product.Update;
using MargunStore.Domain.Commands.v1.User.Create;
using MargunStore.Domain.MapperProfile;
using MargunStore.Infrastructure.Data;
using MargunStore.Infrastructure.Data.Interfaces;
using MargunStore.Infrastructure.Data.Query.MapperProfile;
using MargunStore.Infrastructure.Data.Query.Queries.v1.Category.GetCategory;
using MargunStore.Infrastructure.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace MargunStore.Api.Infrastructure.IoC
{
    public class Bootstrapper
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceCollection _services;
        private readonly string _originName = "WebPageMargun";

        private Assembly DomainCommandAssembly = typeof(CreateCategoryCommandHadler).Assembly;
        private Assembly InfrastructureQueryAssembly = typeof(GetCategoryQueryHandler).Assembly;
        private Assembly MapperCommandProfileAssembly = typeof(CommandEntityProfile).Assembly;
        private Assembly MapperQueryProfileAssemply = typeof(EntityQueryResponseProfile).Assembly;

        public Bootstrapper(IConfiguration configuration, IServiceCollection services)
        {
            _configuration = configuration;
            _services = services;

            Initialize();
        }

        private void Initialize()
        {
            var assemblies = new Assembly[]
            {
               DomainCommandAssembly,
               InfrastructureQueryAssembly,
               MapperCommandProfileAssembly,
               MapperQueryProfileAssemply
            };
            
            _services.AddScoped<ICategoryRepository, CategoryRepository>();
            _services.AddScoped<IProductRepository, ProductRepository>();
            _services.AddScoped<IRoleRepository, RoleRepository>();
            _services.AddScoped<IUserRepository, UserRepository>();
            _services.AddScoped<IClientRepository, ClientRepository>();

            _services.AddDbContext<Context>(value => value.UseSqlServer(_configuration.GetConnectionString("DatabaseConnection")).EnableSensitiveDataLogging());
            _services.AddControllers().AddFluentValidation(value => 
            {
                value.RegisterValidatorsFromAssemblyContaining<CreateCategoryCommandValidator>();
                value.RegisterValidatorsFromAssemblyContaining<UpdateCategoryCommandValidator>();
                value.RegisterValidatorsFromAssemblyContaining<DeleteCategoryCommandValidator>();
                value.RegisterValidatorsFromAssemblyContaining<CreateProductCommandValidator>();
                value.RegisterValidatorsFromAssemblyContaining<UpdateProductCommandValidator>();
                value.RegisterValidatorsFromAssemblyContaining<DeleteProductCommandValidator>();
                value.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
            });
            
            _services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });

            _services.AddAutoMapper(assemblies);
            _services.AddMediatR(assemblies);
            
            AuthenticationSetting();
            ConfigureCORS();
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

        private void ConfigureCORS()
        {
            _services.AddCors(options => 
                options.AddPolicy(name: _originName, policy => 
                    policy.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseCors(_originName);
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
                endpoints.MapControllers()
            );
        }

        private void AuthenticationSetting()
        {
            _services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(value =>
            {
                value.RequireHttpsMetadata = false;
                value.SaveToken = true;
                value.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtSetting.JwtKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
        }
    }
}
