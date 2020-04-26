using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TryLog.Core.Model;

namespace TryLog.Infraestructure.Map
{
    class LogMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("log");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                   .HasColumnName("description")
                   .HasColumnType("varchar(500)")
                   .IsRequired();

            builder.Property(x => x.Token)
                   .HasColumnName("token")
                   .HasColumnType("varchar(500)")
                   .IsRequired();

            builder.Property(x => x.Deleted)
                   .HasColumnName("deleted")
                   .HasColumnType("bit")
                   .IsRequired();

            builder.HasOne(x => x.Environment)
                   .WithMany(x => x.Logs)
                   .HasForeignKey(x => x.IdEnvironment);

            builder.HasOne(x => x.Layer)
                   .WithMany(x => x.Logs)
                   .HasForeignKey(x => x.IdLayer);

            builder.HasOne(x => x.Severity)
                   .WithMany(x => x.Logs)
                   .HasForeignKey(x => x.IdSeverity);

            builder.HasOne(x => x.Status)
                   .WithMany(x => x.Logs)
                   .HasForeignKey(x => x.IdStatus);

        }
    }
}
