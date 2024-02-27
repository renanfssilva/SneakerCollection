using ErrorOr;
using FluentAssertions;
using Moq;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Application.Sneakers.Commands.UpdateSneaker;
using SneakerCollection.Application.Tests.Sneakers.Commands.TestUtils;
using SneakerCollection.Application.Tests.Sneakers.Utils;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Application.Tests.Sneakers.Commands.UpdateSneaker
{
    public class UpdateSneakerCommandHandlerTests
    {
        private readonly UpdateSneakerCommandHandler _commandHandler;
        private readonly Mock<ISneakerRepository> _mockSneakerRepository;

        public UpdateSneakerCommandHandlerTests()
        {
            _mockSneakerRepository = new Mock<ISneakerRepository>();
            _commandHandler = new UpdateSneakerCommandHandler(_mockSneakerRepository.Object);
        }

        [Fact]
        public async Task HandleUpdateSneakerCommand_WhenSneakerIsValid_ShouldUpdateSneaker()
        {
            // Arrange
            var updateSneakerCommand = UpdateSneakerCommandUtils.UpdateCommand();
            var sneaker = SneakerUtils.CreateSneaker();
            _mockSneakerRepository.Setup(s => s.GetByIdAsync(It.IsAny<SneakerId>(), It.IsAny<UserId>())).ReturnsAsync(sneaker);

            // Act
            var result = await _commandHandler.Handle(updateSneakerCommand, default);

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.Should().BeOfType<Updated>();
            _mockSneakerRepository.Verify(s => s.UpdateAsync(It.IsAny<Sneaker>()), Times.Once);
        }

        [Fact]
        public async Task HandleUpdateSneakerCommand_WhenUserIdIsInvalid_ShouldReturnError()
        {
            // Arrange
            var updateSneakerCommand = UpdateSneakerCommandUtils.UpdateCommand(userId: string.Empty);

            // Act
            var result = await _commandHandler.Handle(updateSneakerCommand, default);

            // Assert
            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);
            _mockSneakerRepository.Verify(s => s.UpdateAsync(It.IsAny<Sneaker>()), Times.Never);
        }

        [Fact]
        public async Task HandleUpdateSneakerCommand_WhenSneakerIsNotFound_ShouldReturnError()
        {
            // Arrange
            var updateSneakerCommand = UpdateSneakerCommandUtils.UpdateCommand();
            _mockSneakerRepository.Setup(s => s.GetByIdAsync(It.IsAny<SneakerId>(), It.IsAny<UserId>())).Returns(Task.FromResult<Sneaker?>(null));

            // Act
            var result = await _commandHandler.Handle(updateSneakerCommand, default);

            // Assert
            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.NotFound);
            _mockSneakerRepository.Verify(s => s.UpdateAsync(It.IsAny<Sneaker>()), Times.Never);
        }
    }
}
