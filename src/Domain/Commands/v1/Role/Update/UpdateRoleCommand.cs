using MediatR;

namespace MargunStore.Domain.Commands.v1.Role.Update
{
    public class UpdateRoleCommand : IRequest<UpdateRoleCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
