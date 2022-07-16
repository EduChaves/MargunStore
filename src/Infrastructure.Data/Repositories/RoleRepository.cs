using MargunStore.CrossCutting.Configuration.Entities;
using MargunStore.Infrastructure.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace MargunStore.Infrastructure.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private RoleManager<Role> _roleManager;

        public RoleRepository(RoleManager<Role> roleManager) => _roleManager = roleManager; 

        public async Task CreateRole(Role role) => await _roleManager.CreateAsync(role);

        public async Task<Role> GetRoleByName(string name) => await _roleManager.FindByNameAsync(name);

        public async Task UpdateRole(Role role)
        {
            var response = await _roleManager.UpdateAsync(role);
            
            if (!response.Succeeded)
                 response.Errors.First();
        }

    }
}
