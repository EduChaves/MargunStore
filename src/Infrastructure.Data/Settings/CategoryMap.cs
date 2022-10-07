using MargunStore.CrossCutting.Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MargunStore.Infrastructure.Data.Settings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(value => value.Name).HasColumnType("VARCHAR(50)").IsRequired().HasMaxLength(50);
            builder.Property(value => value.Active).HasColumnType("BIT").HasDefaultValue(1);

            builder.HasData(new Category { Id = 1, Name = "Categoria 1" });
            builder.HasData(new Category { Id = 2, Name = "Categoria 2" });
            builder.HasData(new Category { Id = 3, Name = "Categoria 3" });
        }
    }
}
