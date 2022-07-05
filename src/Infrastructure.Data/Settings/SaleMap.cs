using MargunStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MargunStore.Infrastructure.Data.Settings
{
    public class SaleMap : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.Property(value => value.SaleDate).HasColumnType("DATETIME").IsRequired();
            builder.Property(value => value.Payment).HasColumnType("VARCHAR(50)").IsRequired();
            builder.HasOne(value => value.Bag).WithOne(value => value.Sale).OnDelete(DeleteBehavior.NoAction);
            builder.ToTable("Sale");
        }
    }
}
