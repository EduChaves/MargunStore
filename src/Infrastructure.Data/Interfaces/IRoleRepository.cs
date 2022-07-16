using MargunStore.CrossCutting.Configuration.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace MargunStore.Infrastructure.Data.Interfaces
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleByName(string name);
        Task CreateRole(Role role);
        Task UpdateRole(Role role);
    }
}
