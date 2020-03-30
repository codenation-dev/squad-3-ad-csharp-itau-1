using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;

namespace TryLog.Infraestructure.EF
{
    public class TryLogContext : DbContext
    {
        
        public TryLogContext(DbContextOptions<TryLogContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
