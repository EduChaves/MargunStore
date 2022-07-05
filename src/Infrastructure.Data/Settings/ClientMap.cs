﻿using MargunStore.CrossCutting.Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MargunStore.Infrastructure.Data.Settings
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(value => value.Name).HasColumnType("VARCHAR(50)").IsRequired().HasMaxLength(50);
            builder.Property(value => value.Cpf).HasColumnType("VARCHAR(11)").IsRequired().HasMaxLength((11));
            builder.Property(value => value.Active).HasColumnType("BIT").IsRequired();
            builder.ToTable("Client");
        }
    }
}
