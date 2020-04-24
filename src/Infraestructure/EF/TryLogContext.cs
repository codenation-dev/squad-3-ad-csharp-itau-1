using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TryLog.Core.Model;
using Environment = TryLog.Core.Model.Environment;

namespace TryLog.Infraestructure.EF
{
    public class TryLogContext : IdentityDbContext<User, IdentityRole, string>
    {
        public TryLogContext(DbContextOptions<TryLogContext> options)
            : base(options)
        { }
        public DbSet<Environment> Environments { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Layer> Layers { get; set; }
        public DbSet<Severity> Severities { get; set; }
        public DbSet<Status> Statuses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasKey(k => k.Email);

            modelBuilder.Entity<Environment>()
                .ToTable("Environments")
                .HasKey(k => k.Id);

            modelBuilder.Entity<Log>()
                .ToTable("Logs")
                .HasKey(k => k.Id);

            modelBuilder.Entity<Layer>()
               .ToTable("Layers")
               .HasKey(k => k.Id);

            modelBuilder.Entity<Severity>()
               .ToTable("Severities")
               .HasKey(k => k.Id);

            modelBuilder.Entity<Status>()
               .ToTable("Statuses")
               .HasKey(k => k.Id);

            modelBuilder.Entity<IdentityUserRole<string>>()
                .ToTable("UserRoles");

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .ToTable("UserLogins");

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .ToTable("UserClaims");

            modelBuilder.Entity<IdentityRole>()
                .ToTable("Roles");

            modelBuilder.Entity<IdentityRoleClaim<string>>()
                .ToTable("RoleClaims");

            modelBuilder.Entity<IdentityUserToken<string>>()
                .ToTable("UserTokens");

        }
    }
}
