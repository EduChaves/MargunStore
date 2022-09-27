namespace MargunStore.Domain.Commands.v1.User.Login
{
    public class LoginCommandResponse
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
