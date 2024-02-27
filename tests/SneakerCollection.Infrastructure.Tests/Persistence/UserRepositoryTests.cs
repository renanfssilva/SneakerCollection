using FluentAssertions;
using SneakerCollection.Infrastructure.Tests.TestUtils;

namespace SneakerCollection.Infrastructure.Tests.Persistence
{
    public class UserRepositoryTests
    {
        [Fact]
        public async Task AddAsync_WithValidUser_AddsUser()
        {
            // Arrange
            var user = UserUtils.GetUser();
            var helper = new DbContextTestHelper();
            var repository = helper.GetUserInMemoryRepository();

            // Act
            await repository.AddAsync(user);
            var result = await repository.GetUserByEmailAsync(user.Email);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(user.Id);
        }

        [Fact]
        public async Task GetUserByEmailAsync_WithValidEmail_ReturnsUser()
        {
            // Arrange
            var user = UserUtils.GetUser();
            var helper = new DbContextTestHelper();
            var repository = helper.GetUserInMemoryRepository();
            await repository.AddAsync(user);

            // Act
            var result = await repository.GetUserByEmailAsync(user.Email);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(user.Id);
        }

        [Fact]
        public async Task GetUserByEmailAsync_WithInvalidEmail_ReturnsNull()
        {
            // Arrange
            var user = UserUtils.GetUser();
            var helper = new DbContextTestHelper();
            var repository = helper.GetUserInMemoryRepository();
            await repository.AddAsync(user);

            // Act
            var result = await repository.GetUserByEmailAsync("invalid-email");

            // Assert
            result.Should().BeNull();
        }
    }
}
