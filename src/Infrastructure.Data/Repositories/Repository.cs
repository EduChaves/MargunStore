using MargunStore.Infrastructure.Data.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace MargunStore.Infrastructure.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly Context _context;

        public IQueryable<TEntity> GetAll() => _context.Set<TEntity>();

        public async Task<TEntity> GetById(int id) => await _context.Set<TEntity>().FindAsync(id);

        public Repository(Context context) => _context = context;

        public async Task Add(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
