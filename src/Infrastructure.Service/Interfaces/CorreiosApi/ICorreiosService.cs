using MargunStore.Infrastructure.Service.Services.CorreiosApi;
using System.Threading.Tasks;

namespace MargunStore.Infrastructure.Service.Interfaces.CorreiosApi
{
    public interface ICorreiosService
    {
        Task<CorreiosServiceResponse> FindLocation(string value);
    }
}
