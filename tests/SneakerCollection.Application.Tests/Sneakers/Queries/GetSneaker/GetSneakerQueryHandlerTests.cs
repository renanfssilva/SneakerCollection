using ErrorOr;
using FluentAssertions;
using Moq;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Application.Sneakers.Queries.GetSneaker;
using SneakerCollection.Application.Tests.Sneakers.Queries.TestUtils;
using SneakerCollection.Application.Tests.Sneakers.Utils;
using SneakerCollection.Domain.SneakerAggregate;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Application.Tests.Sneakers.Queries.GetSneaker
{
    public class GetSneakerQueryHandlerTests
    {
        private readonly GetSneakerQueryHandler _handler;
        private readonly Mock<ISneakerRepository> _mockSneakerRepository;

        public GetSneakerQueryHandlerTests()
        {
            _mockSneakerRepository = new Mock<ISneakerRepository>();
            _handler = new GetSneakerQueryHandler(_mockSneakerRepository.Object);
        }

        [Fact]
        public async Task HandleGetSneakerQuery_WhenSneakerExists_ShouldReturnSneaker()
        {
            // Arrange
            var sneaker = SneakerUtils.CreateSneaker();
            _mockSneakerRepository.Setup(s => s.GetByIdAsync(It.IsAny<SneakerId>(), It.IsAny<UserId>())).ReturnsAsync(sneaker);
            var query = GetSneakerQueryUtils.GetQuery();

            // Act
            var result = await _handler.Handle(query, default);

            // Assert
            result.IsError.Should().BeFalse();
            result.Value.Should().BeOfType<Sneaker>();
            _mockSneakerRepository.Verify(s => s.GetByIdAsync(It.IsAny<SneakerId>(), It.IsAny<UserId>()), Times.Once);
        }

        [Fact]
        public async Task HandleGetSneakerQuery_WhenSneakerDoesNotExist_ShouldReturnNotFound()
        {
            // Arrange
            _mockSneakerRepository.Setup(s => s.GetByIdAsync(It.IsAny<SneakerId>(), It.IsAny<UserId>())).Returns(Task.FromResult<Sneaker?>(null));
            var query = GetSneakerQueryUtils.GetQuery();

            // Act
            var result = await _handler.Handle(query, default);

            // Assert
            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.NotFound);
            _mockSneakerRepository.Verify(s => s.GetByIdAsync(It.IsAny<SneakerId>(), It.IsAny<UserId>()), Times.Once);
        }

        [Fact]
        public async Task HandleGetSneakerQuery_WhenUserIdIsInvalid_ShouldReturnError()
        {
            // Arrange
            var query = GetSneakerQueryUtils.GetQuery(userId: string.Empty);

            // Act
            var result = await _handler.Handle(query, default);

            // Assert
            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);
            _mockSneakerRepository.Verify(s => s.GetByIdAsync(It.IsAny<SneakerId>(), It.IsAny<UserId>()), Times.Never);
        }
    }
}
