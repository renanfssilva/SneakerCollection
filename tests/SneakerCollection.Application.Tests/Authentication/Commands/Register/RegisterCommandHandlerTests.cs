using FluentAssertions;
using Moq;
using SneakerCollection.Application.Authentication.Commands.Register;
using SneakerCollection.Application.Authentication.Common;
using SneakerCollection.Application.Common.Interfaces.Authentication;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Application.Tests.Authentication.Commands.TestUtils;
using SneakerCollection.Application.Tests.Authentication.Utils;
using SneakerCollection.Domain.Common.Errors;
using SneakerCollection.Domain.UserAggregate;

namespace SneakerCollection.Application.Tests.Authentication.Commands.Register
{
    public class RegisterCommandHandlerTests
    {
        private readonly RegisterCommandHandler _handler;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IJwtTokenGenerator> _jwtTokenGenerator;

        public RegisterCommandHandlerTests()
        {
            _jwtTokenGenerator = new Mock<IJwtTokenGenerator>();
            _mockUserRepository = new Mock<IUserRepository>();
            _handler = new RegisterCommandHandler(_jwtTokenGenerator.Object, _mockUserRepository.Object);
        }

        [Fact]
        public async Task HandleRegisterCommand_WhenUserDoesNotExist_ShouldReturnAuthenticationResult()
        {
            // Arrange
            var command = RegisterCommandUtils.RegisterCommand();
            var user = UserUtils.CreateUser();
            _mockUserRepository.Setup(u => u.GetUserByEmailAsync(It.IsAny<string>())).Returns(Task.FromResult((User?)null));
            _mockUserRepository.Setup(u => u.AddAsync(It.IsAny<User>())).Returns(Task.CompletedTask);
            _jwtTokenGenerator.Setup(j => j.GenerateToken(It.IsAny<User>())).Returns("token");

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.Should().BeOfType<AuthenticationResult>();
            _mockUserRepository.Verify(u => u.GetUserByEmailAsync(It.IsAny<string>()), Times.Once);
            _mockUserRepository.Verify(u => u.AddAsync(It.IsAny<User>()), Times.Once);
            _jwtTokenGenerator.Verify(j => j.GenerateToken(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task HandleRegisterCommand_WhenUserExists_ShouldReturnError()
        {
            // Arrange
            var command = RegisterCommandUtils.RegisterCommand();
            var user = UserUtils.CreateUser();
            _mockUserRepository.Setup(u => u.GetUserByEmailAsync(It.IsAny<string>())).ReturnsAsync(user);

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            result.IsError.Should().BeTrue();
            result.FirstError.Should().Be(Errors.User.DuplicateEmail);
            _mockUserRepository.Verify(u => u.GetUserByEmailAsync(It.IsAny<string>()), Times.Once);
            _mockUserRepository.Verify(u => u.AddAsync(It.IsAny<User>()), Times.Never);
            _jwtTokenGenerator.Verify(j => j.GenerateToken(It.IsAny<User>()), Times.Never);
        }
    }
}
