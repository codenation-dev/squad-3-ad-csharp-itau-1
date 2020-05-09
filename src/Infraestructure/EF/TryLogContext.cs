using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TryLog.Core.Model;
using TryLog.Infraestructure.Map;
using Environment = TryLog.Core.Model.Environment;

namespace TryLog.Infraestructure.EF
{
    public class TryLogContext : IdentityDbContext<User, IdentityRole, string>
    {
        
        public TryLogContext(DbContextOptions<TryLogContext> options) 
            : base(options)
        {
        }
        public DbSet<Environment> Environment{ get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<Layer> Layer { get; set; }
        public DbSet<Severity> Severity { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
         
            modelBuilder.ApplyConfiguration(new EnvironmentMap());
            modelBuilder.ApplyConfiguration(new LayerMap());
            modelBuilder.ApplyConfiguration(new LogMap());
            modelBuilder.ApplyConfiguration(new SeverityMap());
            modelBuilder.ApplyConfiguration(new StatusMap());

            modelBuilder.Entity<User>()
                .ToTable("users")
                .HasKey(x => x.Id);

            modelBuilder.Entity<IdentityRole>()
                .ToTable("roles")
                .HasKey(x => x.Id);

            modelBuilder.Entity<IdentityUserRole<string>>()
                .ToTable("userroles");

            modelBuilder.Entity<IdentityUserToken<string>>()
                .ToTable("usertokens");

            modelBuilder.Entity<IdentityRoleClaim<string>>()
                .ToTable("roleclaims");

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .ToTable("userlogins");

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .ToTable("userclaims");

            modelBuilder.Entity<IdentityRoleClaim<string>>()
                .ToTable("roleclaims");

            modelBuilder.Entity<IdentityUserToken<string>>()
                .ToTable("usertokens");
        }
    }
}
