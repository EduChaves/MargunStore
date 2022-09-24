using Microsoft.AspNetCore.Identity;

namespace MargunStore.CrossCutting.Configuration.Entities
{
    public class User : IdentityUser<string>
    {
        public string Password { get; set; }
        public Role Role { get; set; }
        public Client Client { get; set; }
        public bool Active { get; set; }
    }
}
