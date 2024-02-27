using ErrorOr;
using FluentAssertions;
using Moq;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Application.Sneakers.Commands.UpsertSneaker;
using SneakerCollection.Application.Tests.Sneakers.Commands.TestUtils;
using SneakerCollection.Application.Tests.Sneakers.Utils;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Application.Tests.Sneakers.Commands.UpsertSneaker
{
    public class UpsertSneakerCommandHandlerTests
    {
        private readonly UpsertSneakerCommandHandler _commandHandler;
        private readonly Mock<ISneakerRepository> _mockSneakerRepository;

        public UpsertSneakerCommandHandlerTests()
        {
            _mockSneakerRepository = new Mock<ISneakerRepository>();
            _commandHandler = new UpsertSneakerCommandHandler(_mockSneakerRepository.Object);
        }

        [Fact]
        public async Task HandleUpsertSneakerCommand_WhenSneakerIsValid_ShouldUpdateSneaker()
        {
            // Arrange
            var upsertSneakerCommand = UpsertSneakerCommandUtils.UpsertCommand();
            var sneaker = SneakerUtils.CreateSneaker();
            _mockSneakerRepository.Setup(s => s.ExistsAsync(It.IsAny<SneakerId>(), It.IsAny<UserId>())).ReturnsAsync(true);
            _mockSneakerRepository.Setup(s => s.UpdateAsync(It.IsAny<Sneaker>())).Returns(Task.CompletedTask);

            // Act
            var result = await _commandHandler.Handle(upsertSneakerCommand, default);

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.Should().BeOfType<UpsertSneakerResponse>();
            _mockSneakerRepository.Verify(s => s.AddAsync(It.IsAny<Sneaker>()), Times.Never);
            _mockSneakerRepository.Verify(s => s.UpdateAsync(It.IsAny<Sneaker>()), Times.Once);
        }

        [Fact]
        public async Task HandleUpsertSneakerCommand_WhenUserIdIsInvalid_ShouldReturnError()
        {
            // Arrange
            var upsertSneakerCommand = UpsertSneakerCommandUtils.UpsertCommand(userId: string.Empty);

            // Act
            var result = await _commandHandler.Handle(upsertSneakerCommand, default);

            // Assert
            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);
            _mockSneakerRepository.Verify(s => s.AddAsync(It.IsAny<Sneaker>()), Times.Never);
            _mockSneakerRepository.Verify(s => s.UpdateAsync(It.IsAny<Sneaker>()), Times.Never);
        }

        [Fact]
        public async Task HandleUpsertSneakerCommand_WhenSneakerIsNotFound_ShouldInsertSneaker()
        {
            // Arrange
            var upsertSneakerCommand = UpsertSneakerCommandUtils.UpsertCommand();
            _mockSneakerRepository.Setup(s => s.ExistsAsync(It.IsAny<SneakerId>(), It.IsAny<UserId>())).ReturnsAsync(false);
            _mockSneakerRepository.Setup(s => s.AddAsync(It.IsAny<Sneaker>())).Returns(Task.CompletedTask);

            // Act
            var result = await _commandHandler.Handle(upsertSneakerCommand, default);

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.Should().BeOfType<UpsertSneakerResponse>();
            _mockSneakerRepository.Verify(s => s.AddAsync(It.IsAny<Sneaker>()), Times.Once);
            _mockSneakerRepository.Verify(s => s.UpdateAsync(It.IsAny<Sneaker>()), Times.Never);
        }

        [Fact]
        public async Task HandleUpsertSneakerCommand_WhenSneakerIsUpdated_ShouldReturnIsNewlyCreatedFalse()
        {
            // Arrange
            var upsertSneakerCommand = UpsertSneakerCommandUtils.UpsertCommand();
            var sneaker = SneakerUtils.CreateSneaker();
            _mockSneakerRepository.Setup(s => s.ExistsAsync(It.IsAny<SneakerId>(), It.IsAny<UserId>())).ReturnsAsync(true);
            _mockSneakerRepository.Setup(s => s.UpdateAsync(It.IsAny<Sneaker>())).Returns(Task.CompletedTask);

            // Act
            var result = await _commandHandler.Handle(upsertSneakerCommand, default);

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.Should().BeOfType<UpsertSneakerResponse>();
            result.Value.IsNewlyCreated.Should().BeFalse();
            _mockSneakerRepository.Verify(s => s.AddAsync(It.IsAny<Sneaker>()), Times.Never);
            _mockSneakerRepository.Verify(s => s.UpdateAsync(It.IsAny<Sneaker>()), Times.Once);
        }

        [Fact]
        public async Task HandleUpsertSneakerCommand_WhenSneakerIsInserted_ShouldReturnIsNewlyCreatedTrue()
        {
            // Arrange
            var upsertSneakerCommand = UpsertSneakerCommandUtils.UpsertCommand();
            var sneaker = SneakerUtils.CreateSneaker();
            _mockSneakerRepository.Setup(s => s.ExistsAsync(It.IsAny<SneakerId>(), It.IsAny<UserId>())).ReturnsAsync(false);
            _mockSneakerRepository.Setup(s => s.AddAsync(It.IsAny<Sneaker>())).Returns(Task.CompletedTask);

            // Act
            var result = await _commandHandler.Handle(upsertSneakerCommand, default);

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.Should().BeOfType<UpsertSneakerResponse>();
            _mockSneakerRepository.Verify(s => s.AddAsync(It.IsAny<Sneaker>()), Times.Once);
            _mockSneakerRepository.Verify(s => s.UpdateAsync(It.IsAny<Sneaker>()), Times.Never);
        }
    }
}
