using gb_active_service_api.Models;
using Microsoft.EntityFrameworkCore;

namespace gb_active_service_api.Data.Contexts
{
    public class ActivesDbContext : DbContext
    {
        public ActivesDbContext(DbContextOptions<ActivesDbContext> options) : base(options) { }

        public DbSet<Active> Actives { get; set; }
        public DbSet<Responsible> Responsibles { get; set; }
        public DbSet<Dependency> Dependencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ActivesDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
