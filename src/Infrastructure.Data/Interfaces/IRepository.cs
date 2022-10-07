using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MargunStore.Infrastructure.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        IQueryable<TEntity> GetEntities();
        IQueryable<TEntity> GetEntities(int id);
        TEntity GetEntity(int id);
    }
}
