using AutoMapper;
using MargunStore.CrossCutting.Exception;
using MargunStore.Infrastructure.Data.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MargunStore.Domain.Commands.v1.Role.Create
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, CreateRoleCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _repository;

        public CreateRoleCommandHandler(IMapper mapper, IRoleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var role = _mapper.Map<CrossCutting.Configuration.Entities.Role>(request);
                await _repository.CreateRole(role);
                
                return new CreateRoleCommandResponse();
            }
            catch (System.Exception ex)
            {

                throw new RoleException(ex.Message, ex);
            }
        }
    }
}
