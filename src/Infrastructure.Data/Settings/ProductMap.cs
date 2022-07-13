using MargunStore.CrossCutting.Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MargunStore.Infrastructure.Data.Settings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(value => value.Name).HasColumnType("VARCHAR(50)").IsRequired().HasMaxLength(50);
            builder.Property(value => value.Description).HasColumnType("VARCHAR(50)").IsRequired().HasMaxLength(50);
            builder.Property(value => value.Length).HasColumnType("VARCHAR(20)").IsRequired().HasMaxLength(20);
            builder.Property(value => value.Value).HasColumnType("NUMERIC(38,2)").IsRequired();
            builder.Property(value => value.Active).HasColumnType("BIT").HasDefaultValue(1);

            builder.ToTable("Product");
        }
    }
}
