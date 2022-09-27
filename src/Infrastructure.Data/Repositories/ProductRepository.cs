using MargunStore.CrossCutting.Configuration.Entities;
using MargunStore.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MargunStore.Infrastructure.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private Context _context;

        public ProductRepository(Context context) : base(context)
        {
            _context = context;
        }

        public override IQueryable<Product> GetEntities() => _context.Products.Include(value => value.Category).Include(value => value.Images);
        public override IQueryable<Product> GetEntities(int id) => _context.Products.Include(value => value.Category).Include(value => value.Images).Where(value => value.Id.Equals(id));
    }
}
