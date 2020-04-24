using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TryLog.Core.Model;

namespace TryLog.Infraestructure.Map
{
    public class LayerMap : IEntityTypeConfiguration<Layer>
    {
        public void Configure(EntityTypeBuilder<Layer> builder)
        {
            builder.ToTable("layer");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                   .HasColumnName("description")
                   .HasColumnType("varchar(500)")
                   .IsRequired();

            builder.Property(x => x.DateRegister)
                   .HasColumnName("date_register")
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(x => x.Deleted)
                   .HasColumnName("deleted")
                   .HasColumnType("bit")
                   .IsRequired();
        }
    }
}
