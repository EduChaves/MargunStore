using MargunStore.CrossCutting.Configuration.Entities;
using MargunStore.CrossCutting.Exception;
using MargunStore.Infrastructure.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace MargunStore.Infrastructure.Data.Repositories
{
    
    public class UserRepository : IUserRepository
    {
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;

        public UserRepository(SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IQueryable<User> GetUsers() => _signInManager.UserManager.Users.Where(value => value.Active.Equals(true));

        public async Task<User> CreateUser(User user)
        {
            try
            {
                user.Role = await _roleManager.FindByNameAsync("User");
                
                var response = await _signInManager.UserManager.CreateAsync(user);

                if (!response.Succeeded)
                    throw new UserException(response.Errors.First().Description, null);

                await _signInManager.UserManager.AddToRoleAsync(user, user.Role.Name);
                await _signInManager.SignInAsync(user, false);

                return await _signInManager.UserManager.FindByNameAsync(user.UserName);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}
