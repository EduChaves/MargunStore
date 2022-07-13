using MargunStore.CrossCutting.Configuration.Entities;
using System.Threading.Tasks;

namespace MargunStore.Infrastructure.Data.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task CreateRole(Role role);
    }
}
