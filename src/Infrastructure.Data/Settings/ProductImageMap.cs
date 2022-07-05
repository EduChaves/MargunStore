using MargunStore.CrossCutting.Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MargunStore.Infrastructure.Data.Settings
{
    public class ProductImageMap : IEntityTypeConfiguration<ProductImages>
    {
        public void Configure(EntityTypeBuilder<ProductImages> builder)
        {
            builder.ToTable("ProductImages");
        }
    }
}
