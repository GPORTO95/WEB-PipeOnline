using Dev.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Dev.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Prospect> Prospects { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Segment> Segments { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<ProspectEmployee> ProspectEmployees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
