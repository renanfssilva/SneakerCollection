using ErrorOr;
using FluentAssertions;
using Moq;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Application.Sneakers.Commands.CreateSneaker;
using SneakerCollection.Application.Tests.Sneakers.Commands.TestUtils;
using SneakerCollection.Application.Tests.TestUtils.Sneakers.Extensions;
using SneakerCollection.Domain.SneakerAggregate;

namespace SneakerCollection.Application.Tests.Sneakers.Commands.CreateSneaker
{
    public class CreateSneakerCommandHandlerTests
    {
        private readonly CreateSneakerCommandHandler _commandHandler;
        private readonly Mock<ISneakerRepository> _mockSneakerRepository;

        public CreateSneakerCommandHandlerTests()
        {
            _mockSneakerRepository = new Mock<ISneakerRepository>();
            _commandHandler = new CreateSneakerCommandHandler(_mockSneakerRepository.Object);
        }

        [Fact]
        public async Task HandleCreateSneakerCommand_WhenSneakerIsValid_ShouldCreateAndReturnSneaker()
        {
            // Arrange
            var createSneakerCommand = CreateSneakerCommandUtils.CreateCommand();

            // Act
            var result = await _commandHandler.Handle(createSneakerCommand, default);

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.ValidateCreatedFrom(createSneakerCommand);
            _mockSneakerRepository.Verify(s => s.AddAsync(result.Value), Times.Once);
        }

        [Fact]
        public async Task HandleCreateSneakerCommand_WhenUserIdIsInvalid_ShouldReturnError()
        {
            // Arrange
            var createSneakerCommand = CreateSneakerCommandUtils.CreateCommand(userId: string.Empty);

            // Act
            var result = await _commandHandler.Handle(createSneakerCommand, default);

            // Assert
            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);
            _mockSneakerRepository.Verify(s => s.AddAsync(It.IsAny<Sneaker>()), Times.Never);
        }
    }
}
