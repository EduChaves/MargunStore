using MediatR;

namespace MargunStore.Domain.Commands.v1.User.Create
{
    public class CreateUserCommand : IRequest<CreateUserCommandResponse>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public CrossCutting.Configuration.Entities.Client Client { get; set; }
    }
}
