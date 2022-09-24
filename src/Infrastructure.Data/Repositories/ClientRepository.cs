using MargunStore.CrossCutting.Configuration.Entities;
using MargunStore.Infrastructure.Data.Interfaces;
using System.Threading.Tasks;

namespace MargunStore.Infrastructure.Data.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly Context _context;
        
        public ClientRepository(Context context) : base(context) => _context = context;

        public async Task CreateClient(Client entity)
        {
            try
            {
                await _context.Clients.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
