using MargunStore.CrossCutting.Configuration.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace MargunStore.Infrastructure.Data.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUser(User user, string role);
        IQueryable<User> GetUsers();
    }
}
