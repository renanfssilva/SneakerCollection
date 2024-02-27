using Microsoft.EntityFrameworkCore;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Infrastructure.Persistence;
using SneakerCollection.Infrastructure.Persistence.Repositories;

namespace SneakerCollection.Infrastructure.Tests.TestUtils
{
    public class DbContextTestHelper
    {
        private readonly SneakerCollectionDbContext _sneakerCollectionDbContext;

        public DbContextTestHelper()
        {
            var builder = new DbContextOptionsBuilder<SneakerCollectionDbContext>();
            builder.UseInMemoryDatabase(databaseName: "SneakerDbInMemory");

            var dbContextOptions = builder.Options;
            _sneakerCollectionDbContext = new SneakerCollectionDbContext(dbContextOptions);

            _sneakerCollectionDbContext.Database.EnsureDeleted();
            _sneakerCollectionDbContext.Database.EnsureCreated();
        }

        public ISneakerRepository GetSneakerInMemoryRepository()
            => new SneakerRepository(_sneakerCollectionDbContext);

        public IUserRepository GetUserInMemoryRepository()
            => new UserRepository(_sneakerCollectionDbContext);
    }
}
