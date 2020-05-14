using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

            builder.HasData(
                new Layer(1, "FrontEnd"),
                new Layer(2, "Back-End"),
                new Layer(3, "Mobile"),
                new Layer(4, "Desktop")
            );
        }
    }
}
