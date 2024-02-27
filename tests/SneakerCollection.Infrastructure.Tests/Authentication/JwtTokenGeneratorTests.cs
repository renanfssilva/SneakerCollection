using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using SneakerCollection.Application.Common.Interfaces.Services;
using SneakerCollection.Domain.Tests.TestUtils.Constants;
using SneakerCollection.Domain.UserAggregate;
using SneakerCollection.Infrastructure.Authentication;

namespace SneakerCollection.Infrastructure.Tests.Authentication
{
    public class JwtTokenGeneratorTests
    {
        private readonly Mock<IDateTimeProvider> _dateTimeProvider;

        public JwtTokenGeneratorTests() => _dateTimeProvider = new Mock<IDateTimeProvider>();

        [Fact]
        public void GenerateToken_WithValidUser_ReturnsToken()
        {
            // Arrange
            var user = User.Create(Constants.User.FirstName, Constants.User.LastName, Constants.User.Email, Constants.User.Password);
            _dateTimeProvider.Setup(x => x.UtcNow).Returns(DateTime.UtcNow);
            var jwtOptions = Options.Create(new JwtSettings
            {
                Secret = "super-awesome-secret-key-for-testing",
                Issuer = "issuer",
                Audience = "audience",
                ExpiryMinutes = 60
            });

            var jwtTokenGenerator = new JwtTokenGenerator(_dateTimeProvider.Object, jwtOptions);

            // Act
            var token = jwtTokenGenerator.GenerateToken(user);

            // Assert
            token.Should().NotBeNullOrEmpty();
        }
    }
}
