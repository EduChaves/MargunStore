using AutoMapper;
using MargunStore.CrossCutting.Configuration.Settings.JWT;
using MargunStore.CrossCutting.Exception;
using MargunStore.Infrastructure.Data.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MargunStore.Domain.Commands.v1.User.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IUserRepository _repository;

        public LoginCommandHandler(IUserRepository repository) => _repository = repository;

        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.SignIn(request.Email, request.Password);

            if (result == null)
                throw new UserException("Usuario ou senha inválidos", null);

            var token = JwtSetting.GenerateToken(result);

            return new LoginCommandResponse { UserId = result.Id, Email = result.Email, Token = token};
        }
    }
}
