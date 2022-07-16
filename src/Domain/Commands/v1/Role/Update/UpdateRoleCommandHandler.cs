using AutoMapper;
using MargunStore.CrossCutting.Exception;
using MargunStore.Infrastructure.Data.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MargunStore.Domain.Commands.v1.Role.Update
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, UpdateRoleCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _repository;

        public UpdateRoleCommandHandler(IMapper mapper, IRoleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var role = _mapper.Map<CrossCutting.Configuration.Entities.Role>(request);
                await _repository.UpdateRole(role);

                return new UpdateRoleCommandResponse();
            }
            catch (Exception ex)
            {
                throw new RoleException(ex.Message, ex);
            }
        }
    }
}
