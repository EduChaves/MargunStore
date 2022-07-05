using MargunStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MargunStore.Infrastructure.Data.Settings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(value => value.Name).HasColumnType("VARCHAR(50)").IsRequired().HasMaxLength(50);
            builder.Property(value => value.Active).HasColumnType("BIT").IsRequired();
            builder.ToTable("Category");
        }
    }
}
