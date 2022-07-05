using MargunStore.Domain.Entities;
using MargunStore.Infrastructure.Data.Interfaces;

namespace MargunStore.Infrastructure.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(Context context) : base(context)
        {
        }
    }
}
