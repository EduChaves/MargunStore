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
                user.EmailConfirmed = true;
                
                var response = await _signInManager.UserManager.CreateAsync(user, user.Password);

                if (!response.Succeeded)
                    throw new UserException(response.Errors.First().Description, null);

                await _signInManager.UserManager.SetLockoutEnabledAsync(user, false);
                await _signInManager.UserManager.AddToRoleAsync(user, user.Role.Name);

                return await SignIn(user.Email, user.Password);
            }
            catch (System.Exception ex)
            {

                throw new UserException(ex.Message, ex);
            }
        }

        public async Task<User> SignIn(string email, string password)
        {
            try
            {
                var user = await _signInManager.UserManager.FindByEmailAsync(email);
                var passwordIsValid = await _signInManager.UserManager.CheckPasswordAsync(user, password);

                if(passwordIsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(user.UserName, password, false, false);
                    return result.Succeeded ? user: null;
                }
                return null;
            }
            catch (System.Exception ex)
            {
                throw new UserException(ex.Message, ex);
            }
        }
    }
}
