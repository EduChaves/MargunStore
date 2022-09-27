using AutoMapper;
using MargunStore.CrossCutting.Configuration.Settings.JWT;
using MargunStore.CrossCutting.Configuration.Shared.Extensions;
using MargunStore.Infrastructure.Data.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MargunStore.Domain.Commands.v1.User.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if(ConfirmPassword(request.Password, request.ConfirmPassword))
            {
                var user = _mapper.Map<CrossCutting.Configuration.Entities.User>(request);
                var response = await _userRepository.CreateUser(user);
                var token = JwtSetting.GenerateToken(user);

                return new CreateUserCommandResponse(new Data { Id = response.Id, UserName = response.UserName, Token = token});
            }
            var nofitication = "";
            return new CreateUserCommandResponse(new List<string>());
        }

        private static bool ConfirmPassword(string password, string confirmPassword) => password.Equals(confirmPassword);
    }
}
