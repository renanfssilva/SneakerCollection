using FluentAssertions;
using Moq;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Application.Sneakers.Commands.CreateSneaker;
using SneakerCollection.Application.UnitTests.Sneakers.Commands.TestUtils;
using SneakerCollection.Application.UnitTests.TestUtils.Sneakers.Extensions;

namespace SneakerCollection.Application.UnitTests.Sneakers.Commands.CreateSneaker
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
    }
}
