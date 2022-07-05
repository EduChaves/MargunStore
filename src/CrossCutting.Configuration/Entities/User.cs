﻿using Microsoft.AspNetCore.Identity;

namespace MargunStore.CrossCutting.Configuration.Entities
{
    public class User : IdentityUser<string>
    {
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}