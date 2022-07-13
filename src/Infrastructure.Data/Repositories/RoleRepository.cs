using MargunStore.CrossCutting.Configuration.Entities;
using MargunStore.Infrastructure.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MargunStore.Infrastructure.Data.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly Context _context;
        private RoleManager<Role> _roleManager;

        public RoleRepository(Context context, RoleManager<Role> roleManager) : base(context)
        {
            _context = context;
            _roleManager = roleManager; 
        }

        public async Task CreateRole(Role role) => await _roleManager.CreateAsync(role);
    }
}
