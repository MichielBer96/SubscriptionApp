using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionApp.Models
{
    public class DataContext : DbContext
    {
        private readonly DbContextOptions _options;

        public DataContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        public DbSet<Subscription> subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
