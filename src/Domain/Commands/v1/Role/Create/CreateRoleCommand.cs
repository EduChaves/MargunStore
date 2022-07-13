using MediatR;

namespace MargunStore.Domain.Commands.v1.Role.Create
{
    public class CreateRoleCommand : IRequest<CreateRoleCommandResponse>
    {
        public string Name { get; set; }
        //public string NormalizedName { get; set; }
        public string Description { get; set; }
    }
}
