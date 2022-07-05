using Microsoft.AspNetCore.Identity;

namespace MargunStore.CrossCutting.Configuration.Entities
{
    public class Role : IdentityRole<string>
    {
        public string Description { get; set; }
    }
}
