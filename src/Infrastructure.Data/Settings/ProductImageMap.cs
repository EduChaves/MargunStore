using MargunStore.CrossCutting.Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MargunStore.Infrastructure.Data.Settings
{
    public class ProductImageMap : IEntityTypeConfiguration<ProductImages>
    {
        public void Configure(EntityTypeBuilder<ProductImages> builder)
        {
            builder.Property(value => value.Active).HasColumnType("BIT").HasDefaultValue(1);
            builder.ToTable("ProductImages");
        }
    }
}
