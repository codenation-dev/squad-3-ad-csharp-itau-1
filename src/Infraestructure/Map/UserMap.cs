using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TryLog.Core.Model;

namespace TryLog.Infraestructure.Map
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedAt)
                   .HasColumnName("created_at")
                   .HasColumnType("varchar(500)")
                   .IsRequired();

            builder.Property(x => x.UpdatedAt)
                   .HasColumnName("updated_at")
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(x => x.Deleted)
                   .HasColumnName("deleted")
                   .HasColumnType("bit")
                   .IsRequired();
        }
    }
}
