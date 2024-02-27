using FluentAssertions;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.UserAggregate.ValueObjects;
using SneakerCollection.Infrastructure.Tests.TestUtils;

namespace SneakerCollection.Infrastructure.Tests.Persistence
{
    public class SneakerRepositoryTests
    {
        [Fact]
        public async Task AddAsync_WithValidSneaker_AddsSneaker()
        {
            // Arrange
            var sneaker = SneakerUtils.GetSneaker();
            var helper = new DbContextTestHelper();
            var repository = helper.GetSneakerInMemoryRepository();

            // Act
            await repository.AddAsync(sneaker);
            var result = await repository.GetByIdAsync(sneaker.Id, sneaker.UserId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(sneaker.Id);
            result.UserId.Should().Be(sneaker.UserId);
        }

        [Fact]
        public async Task GetByIdAsync_WithValidSneakerIdAndUserId_ReturnsSneaker()
        {
            // Arrange
            var sneaker = SneakerUtils.GetSneaker();
            var helper = new DbContextTestHelper();
            var repository = helper.GetSneakerInMemoryRepository();
            await repository.AddAsync(sneaker);

            // Act
            var result = await repository.GetByIdAsync(sneaker.Id, sneaker.UserId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(sneaker.Id);
            result.UserId.Should().Be(sneaker.UserId);
        }

        [Fact]
        public async Task ListAsync_WithValidUserId_ReturnsSneakers()
        {
            // Arrange
            var sneaker = SneakerUtils.GetSneaker();
            var helper = new DbContextTestHelper();
            var repository = helper.GetSneakerInMemoryRepository();
            await repository.AddAsync(sneaker);

            // Act
            var result = await repository.ListAsync(sneaker.UserId);

            // Assert
            result.Should().NotBeEmpty();
            result.Should().HaveCount(1);
            result[0].Id.Should().Be(sneaker.Id);
            result[0].UserId.Should().Be(sneaker.UserId);
        }

        [Fact]
        public async Task DeleteAsync_WithValidSneakerIdAndUserId_DeletesSneaker()
        {
            // Arrange
            var sneaker = SneakerUtils.GetSneaker();
            var helper = new DbContextTestHelper();
            var repository = helper.GetSneakerInMemoryRepository();
            await repository.AddAsync(sneaker);

            // Act
            await repository.DeleteAsync(sneaker.Id, sneaker.UserId);
            var result = await repository.GetByIdAsync(sneaker.Id, sneaker.UserId);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task ExistsAsync_WithValidSneakerIdAndUserId_ReturnsTrue()
        {
            // Arrange
            var sneaker = SneakerUtils.GetSneaker();
            var helper = new DbContextTestHelper();
            var repository = helper.GetSneakerInMemoryRepository();
            await repository.AddAsync(sneaker);

            // Act
            var exists = await repository.ExistsAsync(sneaker.Id, sneaker.UserId);

            // Assert
            exists.Should().BeTrue();
        }

        [Fact]
        public async Task ExistsAsync_WithInvalidSneakerIdAndUserId_ReturnsFalse()
        {
            // Arrange
            var sneaker = SneakerUtils.GetSneaker();
            var helper = new DbContextTestHelper();
            var repository = helper.GetSneakerInMemoryRepository();
            await repository.AddAsync(sneaker);

            // Act
            var exists = await repository.ExistsAsync(SneakerId.Create(Guid.NewGuid()), UserId.Create(Guid.NewGuid()));

            // Assert
            exists.Should().BeFalse();
        }

        [Fact]
        public async Task GetByIdAsync_WithInvalidSneakerIdAndUserId_ReturnsNull()
        {
            // Arrange
            var sneaker = SneakerUtils.GetSneaker();
            var helper = new DbContextTestHelper();
            var repository = helper.GetSneakerInMemoryRepository();
            await repository.AddAsync(sneaker);

            // Act
            var result = await repository.GetByIdAsync(SneakerId.Create(Guid.NewGuid()), UserId.Create(Guid.NewGuid()));

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task ListAsync_WithInvalidUserId_ReturnsEmptyList()
        {
            // Arrange
            var sneaker = SneakerUtils.GetSneaker();
            var helper = new DbContextTestHelper();
            var repository = helper.GetSneakerInMemoryRepository();
            await repository.AddAsync(sneaker);

            // Act
            var result = await repository.ListAsync(UserId.Create(Guid.NewGuid()));

            // Assert
            result.Should().BeEmpty();
        }
    }
}
