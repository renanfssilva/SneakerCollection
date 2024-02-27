using ErrorOr;
using FluentAssertions;
using Moq;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Application.Sneakers.Commands.DeleteSneaker;
using SneakerCollection.Application.Tests.Sneakers.Commands.TestUtils;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Application.Tests.Sneakers.Commands.DeleteSneaker
{
    public class DeleteSneakerCommandHandlerTests
    {
        private readonly DeleteSneakerCommandHandler _commandHandler;
        private readonly Mock<ISneakerRepository> _mockSneakerRepository;

        public DeleteSneakerCommandHandlerTests()
        {
            _mockSneakerRepository = new Mock<ISneakerRepository>();
            _commandHandler = new DeleteSneakerCommandHandler(_mockSneakerRepository.Object);
        }

        [Fact]
        public async Task HandleDeleteSneakerCommand_WhenSneakerIsValid_ShouldDeleteSneaker()
        {
            // Arrange
            var deleteSneakerCommand = DeleteSneakerCommandUtils.DeleteCommand();

            // Act
            var result = await _commandHandler.Handle(deleteSneakerCommand, default);

            // Assert
            result.IsError.Should().BeFalse();
            _mockSneakerRepository.Verify(s => s.DeleteAsync(It.IsAny<SneakerId>(), It.IsAny<UserId>()), Times.Once);
        }

        [Fact]
        public async Task HandleDeleteSneakerCommand_WhenUserIdIsInvalid_ShouldReturnError()
        {
            // Arrange
            var deleteSneakerCommand = DeleteSneakerCommandUtils.DeleteCommand(userId: string.Empty);

            // Act
            var result = await _commandHandler.Handle(deleteSneakerCommand, default);

            // Assert
            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);
            _mockSneakerRepository.Verify(s => s.DeleteAsync(It.IsAny<SneakerId>(), It.IsAny<UserId>()), Times.Never);
        }
    }
}
