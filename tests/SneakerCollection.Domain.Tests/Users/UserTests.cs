using FluentAssertions;
using SneakerCollection.Domain.Tests.TestUtils.Constants;
using SneakerCollection.Domain.UserAggregate;
using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Domain.Tests.Users
{
    public class UserTests
    {
        [Fact]
        public void User_Create_ReturnsUser()
        {
            // Arrange
            // Act
            var user = User.Create(Constants.User.FirstName, Constants.User.LastName, Constants.User.Email, Constants.User.Password);

            // Assert
            user.Should().BeOfType<User>();
            user.Should().NotBeNull();
            user.Id.Should().BeOfType<UserId>();
            user.Id.Should().NotBeNull();
            user.Id.Value.Should().NotBeEmpty();
            user.FirstName.Should().Be(Constants.User.FirstName);
            user.LastName.Should().Be(Constants.User.LastName);
            user.Email.Should().Be(Constants.User.Email);
            user.Password.Should().Be(Constants.User.Password);
        }
    }
}
