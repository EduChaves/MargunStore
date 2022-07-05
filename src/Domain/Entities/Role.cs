using Microsoft.AspNetCore.Identity;

namespace MargunStore.Domain.Entities
{
    public class Role : IdentityRole<string>
    {
        public string Description { get; set; }
    }
}
