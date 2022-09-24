using AutoMapper;
using MargunStore.CrossCutting.Exception;
using MargunStore.Infrastructure.Data.Interfaces;
using MediatR;
using System.Linq;
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
            var user = _mapper.Map<CrossCutting.Configuration.Entities.User>(request);

            if (!_userRepository.GetUsers().Any() && user.Client == null)
            {
                user.Role = await _roleRepository.CreateRole(new CrossCutting.Configuration.Entities.Role { Name = "Admin", Description = "Admin of System" });
                await _roleRepository.CreateRole(new CrossCutting.Configuration.Entities.Role { Name = "User", Description = "User of System" });

                var response = await _userRepository.CreateUser(user);
                return new CreateUserCommandResponse { Id = response.Id, UserName = response.UserName };
            }
            else
            {
                var response = await _userRepository.CreateUser(user);

                return new CreateUserCommandResponse { Id = response.Id, UserName = response.UserName };
            }
        }
    }
}
