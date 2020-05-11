using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TryLog.Core.Model;

namespace TryLog.Infraestructure.Map
{
    public class SeverityMap : IEntityTypeConfiguration<Severity>
    {
        public void Configure(EntityTypeBuilder<Severity> builder)
        {
            builder.ToTable("severity");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                   .HasColumnName("description")
                   .HasColumnType("varchar(500)")
                   .IsRequired();

            builder.Property(x => x.DateRegister)
                   .HasColumnName("data_register")
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(x => x.Deleted)
                   .HasColumnName("deleted")
                   .HasColumnType("bit")
                   .IsRequired();

            builder.HasData(
                new Severity(1, "Baixo"),
                new Severity(2, "Médio"),
                new Severity(3, "Alto")
            );
        }
    }
}
