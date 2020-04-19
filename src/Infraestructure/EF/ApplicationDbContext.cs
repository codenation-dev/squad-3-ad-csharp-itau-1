using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TryLog.Core.Model;

namespace TryLog.Infraestructure.EF
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasKey(k=>k.Email);

            modelBuilder.Entity<IdentityUserRole<string>>()
                .ToTable("UserRoles");

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .ToTable("UserLogins");

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .ToTable("UserClaims");

            modelBuilder.Entity<IdentityRole>()
                .ToTable("Roles");
            
            base.OnModelCreating(modelBuilder);
        }

    }
}
