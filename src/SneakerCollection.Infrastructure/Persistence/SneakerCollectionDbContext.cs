using Microsoft.EntityFrameworkCore;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.UserAggregate;

namespace SneakerCollection.Infrastructure.Persistence
{
    public class SneakerCollectionDbContext(DbContextOptions<SneakerCollectionDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Sneaker> Sneakers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(SneakerCollectionDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
