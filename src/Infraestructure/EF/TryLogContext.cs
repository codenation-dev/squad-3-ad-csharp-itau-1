using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TryLog.Core.Model;
using Environment = TryLog.Core.Model.Environment;

namespace TryLog.Infraestructure.EF
{
    public class TryLogContext : DbContext
    {
        
        public TryLogContext(DbContextOptions<TryLogContext> options) 
            : base(options)
        {
        }
        public DbSet<Environment> Environments{ get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Layer> Layers { get; set; }
        public DbSet<Severity> Severities { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}
