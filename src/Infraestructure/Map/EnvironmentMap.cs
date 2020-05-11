using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Environment = TryLog.Core.Model.Environment;

namespace TryLog.Infraestructure.Map
{
    public class EnvironmentMap : IEntityTypeConfiguration<Environment>
    {
        public void Configure(EntityTypeBuilder<Environment> builder)
        {
            builder.ToTable("environment");

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

            builder.HasData(
                new Environment(1, "Desenvolvimento"),
                new Environment(2, "Homologação"),
                new Environment(3, "Produção")
            );
        }
    }
}
