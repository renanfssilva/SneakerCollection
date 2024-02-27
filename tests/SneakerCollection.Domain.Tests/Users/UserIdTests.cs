using FluentAssertions;
using SneakerCollection.Domain.Common.Errors;
using SneakerCollection.Domain.Tests.TestUtils.Constants;
using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Domain.Tests.Users
{
    public class UserIdTests
    {
        [Fact]
        public void UserId_CreateUnique_ReturnsUserId()
        {
            // Arrange
            // Act
            var userId = UserId.CreateUnique();

            // Assert
            userId.Should().BeOfType<UserId>();
            userId.Should().NotBeNull();
            userId.Value.Should().NotBeEmpty();
        }

        [Fact]
        public void UserId_Create_ReturnsUserId()
        {
            // Arrange
            var value = Constants.User.Id.Value;

            // Act
            var userId = UserId.Create(value);

            // Assert
            userId.Should().BeOfType<UserId>();
            userId.Should().NotBeNull();
            userId.Value.Should().Be(value);
        }

        [Fact]
        public void UserId_CreateWithString_ReturnsUserId()
        {
            // Arrange
            var value = Constants.User.Id.Value;

            // Act
            var userId = UserId.Create(value.ToString());

            // Assert
            userId.IsError.Should().BeFalse();
            userId.Value.Should().BeOfType<UserId>();
            userId.Value.Should().NotBeNull();
            userId.Value.Value.Should().Be(value);
        }

        [Fact]
        public void UserId_Create_WithInvalidValue_ReturnsError()
        {
            // Arrange
            var value = "invalid";

            // Act
            var userId = UserId.Create(value);

            // Assert
            userId.IsError.Should().BeTrue();
            userId.FirstError.Should().Be(Errors.User.InvalidUserId);
        }
    }
}
