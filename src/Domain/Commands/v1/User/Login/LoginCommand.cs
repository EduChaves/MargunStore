using MediatR;

namespace MargunStore.Domain.Commands.v1.User.Login
{
    public class LoginCommand : IRequest<LoginCommandResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
