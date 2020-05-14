using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TryLog.Core.Model;

namespace TryLog.Infraestructure.Map
{

    using Environment = Core.Model.Environment;
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
            
            builder.HasData(
                new Log()
                {
                    Id = 1,
                    Description = "System.NotSupportedException: The SMTP server does not support authentication. at MailKit.Net.Smtp.SmtpClient.AuthenticateAsync(Encoding encoding, ICredentials credentials, Boolean doAsync, CancellationToken cancellationToken)",
                    IdStatus = 3,
                    IdLayer = 2,
                    IdSeverity = 1,
                    IdEnvironment = 1,
                    Token = "aasfdjg2jhlb1j2n3k12h3kjçh12jkeasdasd",
                    DateRegister = DateTime.UtcNow,
                    Deleted = false
                }
            );
        }
    }
}
