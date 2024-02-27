using FluentAssertions;
using Moq;
using SneakerCollection.Application.Authentication.Common;
using SneakerCollection.Application.Authentication.Queries.Login;
using SneakerCollection.Application.Common.Interfaces.Authentication;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Application.Tests.Authentication.Queries.TestUtils;
using SneakerCollection.Application.Tests.Authentication.Utils;
using SneakerCollection.Domain.Common.Errors;
using SneakerCollection.Domain.UserAggregate;

namespace SneakerCollection.Application.Tests.Authentication.Queries.Login
{
    public class LoginQueryHandlerTests
    {
        private readonly LoginQueryHandler _handler;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IJwtTokenGenerator> _jwtTokenGenerator;

        public LoginQueryHandlerTests()
        {
            _jwtTokenGenerator = new Mock<IJwtTokenGenerator>();
            _mockUserRepository = new Mock<IUserRepository>();
            _handler = new LoginQueryHandler(_jwtTokenGenerator.Object, _mockUserRepository.Object);
        }

        [Fact]
        public async Task HandleLoginQuery_WhenUserExists_ShouldReturnAuthenticationResult()
        {
            // Arrange
            var query = LoginQueryUtils.GetQuery();
            var user = UserUtils.CreateUser();
            _mockUserRepository.Setup(u => u.GetUserByEmailAsync(It.IsAny<string>())).ReturnsAsync(user);
            _jwtTokenGenerator.Setup(j => j.GenerateToken(It.IsAny<User>())).Returns("token");

            // Act
            var result = await _handler.Handle(query, default);

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.Should().BeOfType<AuthenticationResult>();
            _mockUserRepository.Verify(u => u.GetUserByEmailAsync(It.IsAny<string>()), Times.Once);
            _jwtTokenGenerator.Verify(j => j.GenerateToken(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task HandleLoginQuery_WhenUserDoesNotExist_ShouldReturnError()
        {
            // Arrange
            var query = LoginQueryUtils.GetQuery();
            _mockUserRepository.Setup(u => u.GetUserByEmailAsync(It.IsAny<string>())).Returns(Task.FromResult((User?)null));

            // Act
            var result = await _handler.Handle(query, default);

            // Assert
            result.IsError.Should().BeTrue();
            result.FirstError.Should().BeEquivalentTo(Errors.Authentication.InvalidCredentials);
            _mockUserRepository.Verify(u => u.GetUserByEmailAsync(It.IsAny<string>()), Times.Once);
            _jwtTokenGenerator.Verify(j => j.GenerateToken(It.IsAny<User>()), Times.Never);
        }

        [Fact]
        public async Task HandleLoginQuery_WhenPasswordIsInvalid_ShouldReturnError()
        {
            // Arrange
            var query = LoginQueryUtils.GetQuery(password: "invalid");
            var user = UserUtils.CreateUser();
            _mockUserRepository.Setup(u => u.GetUserByEmailAsync(It.IsAny<string>())).ReturnsAsync(user);

            // Act
            var result = await _handler.Handle(query, default);

            // Assert
            result.IsError.Should().BeTrue();
            result.FirstError.Should().BeEquivalentTo(Errors.Authentication.InvalidCredentials);
            _mockUserRepository.Verify(u => u.GetUserByEmailAsync(It.IsAny<string>()), Times.Once);
            _jwtTokenGenerator.Verify(j => j.GenerateToken(It.IsAny<User>()), Times.Never);
        }
    }
}
