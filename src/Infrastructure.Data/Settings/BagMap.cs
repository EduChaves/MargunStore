using MargunStore.CrossCutting.Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MargunStore.Infrastructure.Data.Settings
{
    public class BagMap : IEntityTypeConfiguration<Bag>
    {
        public void Configure(EntityTypeBuilder<Bag> builder)
        {
            builder.ToTable("Bag");
        }
    }
}
