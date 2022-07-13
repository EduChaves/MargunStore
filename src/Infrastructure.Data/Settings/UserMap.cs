using MargunStore.CrossCutting.Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MargunStore.Infrastructure.Data.Settings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(value => value.Id).ValueGeneratedOnAdd();
            builder.Property(value => value.Password).HasColumnType("VARCHAR(50)").IsRequired().HasMaxLength(50);
            builder.Property(value => value.Active).HasColumnType("BIT").HasDefaultValue(1);

            builder.ToTable("User");
        }
    }
}
