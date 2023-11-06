using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Order.Infra.Data
{
    public class Context : DbContext
    {
        public static readonly string SCHEMA = "order";
        public static readonly string MIGRATIONS_HISTORY_TABLE = "_EFMigrationHistory";

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SCHEMA);

            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Domain.Aggregates.OrderAggregate.Order> Orders { get; set; }

    }

    public class ContextDesignFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=Order;Trusted_Connection=True;");

            return new Context(optionsBuilder.Options);
        }
    }
}
