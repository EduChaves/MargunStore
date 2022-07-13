using MargunStore.CrossCutting.Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MargunStore.Infrastructure.Data.Settings
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(value => value.Name).HasColumnType("VARCHAR(50)").IsRequired().HasMaxLength(50);
            builder.Property(value => value.Description).HasColumnType("VARCHAR(100)").IsRequired().HasMaxLength(100);
            builder.Property(value => value.Active).HasColumnType("BIT").HasDefaultValue(1);

            builder.ToTable("Role");
        }
    }
}
