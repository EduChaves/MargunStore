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

        public UserRepository(SignInManager<User> signInManager) => _signInManager = signInManager;

        public IQueryable<User> GetUsers() => _signInManager.UserManager.Users.Where(value => value.Active.Equals(true));

        public async Task<User> CreateUser(User user, Role role)
        {
            user.RoleId = role.Id;
            var response = await _signInManager.UserManager.CreateAsync(user);
                        
            if (!response.Succeeded)
                throw new UserException(response.Errors.First().Description, null);

            await _signInManager.UserManager.AddToRoleAsync(user, role.Name);
            await _signInManager.SignInAsync(user, false);

            return await _signInManager.UserManager.FindByNameAsync(user.UserName);
        }
    }
}
