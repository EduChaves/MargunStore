using MargunStore.CrossCutting.Configuration.Entities;
using System.Threading.Tasks;

namespace MargunStore.Infrastructure.Data.Interfaces
{
    public interface IClientRepository
    {
        Task CreateClient(Client entity);
    }
}
