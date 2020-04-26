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
            modelBuilder.ApplyConfiguration(new EnvironmentMap());
            modelBuilder.ApplyConfiguration(new LayerMap());
            modelBuilder.ApplyConfiguration(new LogMap());
            modelBuilder.ApplyConfiguration(new SeverityMap());
            modelBuilder.ApplyConfiguration(new StatusMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
