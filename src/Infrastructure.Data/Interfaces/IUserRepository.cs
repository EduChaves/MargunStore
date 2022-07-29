using MargunStore.CrossCutting.Configuration.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace MargunStore.Infrastructure.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user, Role role);
        IQueryable<User> GetUsers();
    }
}
