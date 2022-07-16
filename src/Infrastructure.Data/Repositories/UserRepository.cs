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
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserRepository(UserManager<User> manager, SignInManager<User> signInManager)
        {
            _userManager = manager;
            _signInManager = signInManager;
        }

        public IQueryable<User> GetUsers() => _userManager.Users.Where(value => value.Active.Equals(true));

        public async Task CreateUser(User user, string role)
        {
            var response = await _userManager.CreateAsync(user);
                        
            if (!response.Succeeded)
                throw new UserException(response.Errors.First().Description, null);

            await _userManager.AddToRoleAsync(user, role);
        }
    }
}
