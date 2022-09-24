using MargunStore.CrossCutting.Configuration.Entities;
using MargunStore.Infrastructure.Data.Settings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MargunStore.Infrastructure.Data
{
    public class Context : IdentityDbContext<User, Role, string>
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Bag> Bags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<ItemBag> ItemBags { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }

        public Context(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AddressMap());
            builder.ApplyConfiguration(new BagMap());
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new ClientMap());
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new RoleMap());
            builder.ApplyConfiguration(new SaleMap());
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new ItemBagMap());
            builder.ApplyConfiguration(new ProductImageMap());
        }
    }
}
