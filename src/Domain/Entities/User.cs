namespace MargunStore.Domain.Entities
{
    public class User : IdentityUser<string>
    {
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
