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
            try
            {
                var user = _mapper.Map<CrossCutting.Configuration.Entities.User>(request);
                
                if (_userRepository.GetUsers().Count().Equals(0))
                {
                    var roleAdmin = await CreateRoleForUser("Admin", "Administrator of system");
                    user.RoleId = roleAdmin.Id;
                    await _userRepository.CreateUser(user, roleAdmin.Name);
                } else
                {
                    var roleUser = await CreateRoleForUser("User", "User of system");
                    user.RoleId = roleUser.Id;
                    await _userRepository.CreateUser(user, roleUser.Name);
                }
                
                return new CreateUserCommandResponse();
            }
            catch (System.Exception ex)
            {
                throw new UserException(ex.Message, ex);
            }
        }

        private async Task<CrossCutting.Configuration.Entities.Role> CreateRoleForUser(string roleName, string roleDescription)
        {
            await _roleRepository.CreateRole(new CrossCutting.Configuration.Entities.Role { Name = roleName, Description = roleDescription });
            return await _roleRepository.GetRoleByName(roleName);
        }
    }
}
