using MargunStore.Infrastructure.Data.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace MargunStore.Infrastructure.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly Context _context;

        public virtual IQueryable<TEntity> GetEntities() => _context.Set<TEntity>();
        public virtual IQueryable<TEntity> GetEntities(int id) => _context.Set<TEntity>();

        public virtual TEntity GetEntity(int id) => null;

        public Repository(Context context) => _context = context;

        public async Task Add(TEntity entity)
        {
            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            
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
