using MargunStore.Infrastructure.Service.Interfaces.CorreiosApi;
using MargunStore.Infrastructure.Service.Services.CorreiosApi;
using ServiceReference1;
using System.Threading.Tasks;

namespace MargunStore.Infrastructure.Service.ServiceHandlers.CorreiosApi
{
    public class CorreiosServiceClient : ICorreiosService
    {
        public async Task<CorreiosServiceResponse> FindLocation(string request)
        {
            using (var tt = new AtendeClienteClient())
            {
                var response = await tt.consultaCEPAsync(request);

                return response != null ? new CorreiosServiceResponse
                {
                    Street = response.@return.end,
                    District = response.@return.bairro,
                    State = response.@return.uf,
                    City = response.@return.cidade
                } : null;
            }
        }
    }
}
