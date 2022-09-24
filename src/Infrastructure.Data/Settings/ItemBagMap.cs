using MargunStore.CrossCutting.Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MargunStore.Infrastructure.Data.Settings
{
    public class ItemBagMap : IEntityTypeConfiguration<ItemBag>
    {
        public void Configure(EntityTypeBuilder<ItemBag> builder)
        {
            builder.Property(value => value.Active).HasColumnType("BIT").HasDefaultValue(1);
        }
    }
}
