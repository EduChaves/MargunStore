using MargunStore.CrossCutting.Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MargunStore.Infrastructure.Data.Settings
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(value => value.Stret).HasColumnType("VARCHAR(50)").IsRequired().HasMaxLength(50);
            builder.Property(value => value.Number).HasColumnType("INT").IsRequired();
            builder.Property(value => value.District).HasColumnType("VARCHAR(50)").IsRequired().HasMaxLength(50);
            builder.Property(value => value.State).HasColumnType("VARCHAR(30)").IsRequired().HasMaxLength(30);
            builder.Property(value => value.Complement).HasColumnType("VARCHAR(30)").IsRequired();
            builder.Property(value => value.Cep).HasColumnType("INT").IsRequired();
            builder.Property(value => value.Active).HasColumnType("BIT").HasDefaultValue(1);
        }
    }
}
